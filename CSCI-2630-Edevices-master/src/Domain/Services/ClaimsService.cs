using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Domain.Models;//added namespaces
using EDeviceClaims.Interactors;//added for IGetPolicyInteractor and IGetClaimsInteractor which
//the file still needs to be created in the interactors folder I only see Class1.cs with an IGetPolicy Interactor

namespace EDeviceClaims.Domain.Services
{
    public interface IClaimsService//
    {
        ClaimDomainModel StartClaim(Guid policyId);//
    }

    public class ClaimsService : IClaimsService// dependancy injection
    {
        private IGetPolicyInteractor GetPolicyInteractor
        {
            get { return _getPolicyInteractor ?? (_getPolicyInteractor = new GetPolicyInteractor()); }
            set { _getPolicyInteractor = value; }
        }
        private IGetPolicyInteractor _getPolicyInteractor;

        private IGetClaimsInteractor GetClaimsInteractor//missing Interactor
        {
            get { return _getClaimsInteractor ?? (_getClaimsInteractor = new GetClaimsInteractor()); }
            set { _getClaimsInteractor = value; }
        }
        private IGetClaimsInteractor _getClaimsInteractor;
        // above and below this comment are 2 policy interactors one for claims and the other for policy.

        public ClaimDomainModel StartClaim(Guid policyId)//
        {
            var policy = _getPolicyInteractor.GetById(policyId);//get the policy
            if (policy == null) throw new ArgumentException("Policy for that Policy Id does not exist");

            var existingClaim = _getClaimsInteractor.GetByPolicyId(policyId);//if the policy does not have a claim, create a claim and return the claim

            return new ClaimDomainModel();//if the policy has a claim return it
        }
    }
}
