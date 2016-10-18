using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Interactors;

namespace EDeviceClaims.Domain.Services
{
    public interface IClaimService
    {
        ClaimDomainModel StartClaim(Guid id);
    }

    public class ClaimService : IClaimService
    {
        private IGetPolicyInteractor _getPolicyInteractor = new GetPolicyInteractor();
        private IGetClaimInteractor _createClaimInteractor = new GetClaimsInteractor();

        public ClaimDomainModel StartClaim(Guid id)
        {
            //Get the Policy
            var policy = _getPolicyInteractor.GetById(id);
            if (policy == null) return null;

            //Check the business rules
            //Create the claim
            _createClaimInteractor.PolicyId = policy.Id;
            _createClaimInteractor.UserId = policy.UserId;

            var newClaim = _createClaimInteractor.Execute();

            return new ClaimDomainModel(newClaim);
        }
    }
}