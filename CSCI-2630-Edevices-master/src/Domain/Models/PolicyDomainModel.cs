﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Domain.Models
{
    public class PolicyDomainModel
    {
        public PolicyDomainModel(PolicyEntity policyEntity)
        {
            Id = policyEntity.Id;
            Number = policyEntity.Number;
            SerialNumber = policyEntity.SerialNumber;
            DeviceName = policyEntity.DeviceName;
        }

        public Guid Id { get; set; }//properties of the device(phone/tablet)
        public string Number { get; set; }
        public string DeviceName { get; set; }
        public string SerialNumber { get; set; }
    }
}
