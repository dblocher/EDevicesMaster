using System;
using System.Collections.Generic;
using EDeviceClaims.Domain.Models;

namespace EDeviceClaims.WebUi.Models
{
    public class ClaimViewModel
    {
        public ClaimViewModel()
        {
        }

        public ClaimViewModel(ClaimDomainModel domainModel) : this()
        {
            Id = domainModel.Id;
            //Status = domainModel.Status.ToString();

            SetPolicyProperties(domainModel.PolicyEntity);
        }

        private void SetPolicyProperties(PolicyDomainModel policy)
        {
            if (policy == null) return;
            PolicyNumber = policy.Number;
            DeviceName = policy.DeviceName;
            SerialNumber = policy.SerialNumber;
        }

        public Guid Id { get; set; }

        public string PolicyNumber { get; set; }
        public string DeviceName { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }
    }
}