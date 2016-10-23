using System;
using System.Security.Policy;
using EDeviceClaims.Domain.Models;

namespace EDeviceClaims.WebUi.Models
{
    public class DeviceViewModel
    {
        public DeviceViewModel(PolicyDomainModel thing)
        {
            PolicyId = thing.Id;
            PolicyNumber = thing.Number;
            SerialNumber = thing.SerialNumber;
            Name = thing.DeviceName;
            // test condidtion HasClaim = true;
        }

        public string Name { get; set; }

        public string SerialNumber { get; set; }

        public string PolicyNumber { get; set; }

        public Guid PolicyId { get; set; }

        public bool HasClaim { get; set; }
    }
}