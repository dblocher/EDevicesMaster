using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;


namespace EDeviceClaims.Interactors
{
    public interface IGetClaimInteractor
    {
        Guid PolicyId { get; set; }
        string UserId { get; set; }
        ClaimEntity Execute();
    }

    public class GetClaimInteractor : IGetClaimInteractor
    {
        private IClaimsRepository _claimsRepo = new ClaimsRepository();

        public Guid PolicyId { get; set; }
        public string UserId { get; set; }

        public ClaimEntity Execute()
        {
            var newClaim = new ClaimEntity
            {
                Status = "NEW",
                PolicyId = PolicyId,
                UserId = UserId
            };

            return _claimsRepo.Create(newClaim);
        }
    }
}

/*namespace EDeviceClaims.Interactors
{   
    public interface IGetClaimsInteractor
    {
        ClaimEntity GetByPolicyId(Guid policyId);
    }
    public class GetClaimsInteractor : IGetClaimsInteractor
    {
        private IClaimsRepository Repo
        {
            get { return _repo ?? (_repo = new ClaimsRepository()); }
            set { _repo = value; }
        }
        private IClaimsRepository _repo;


        public GetClaimsInteractor() { }

        public GetClaimsInteractor(IClaimsRepository claimsRepo)
        {
            _repo = claimsRepo;
        }


        public ClaimEntity GetByPolicyId(Guid policyId)
        {
            return Repo.GetByPolicyId(policyId);
        }
    }
}
*/
