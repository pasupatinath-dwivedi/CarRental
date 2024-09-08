using System;
using System.Runtime.Serialization;

namespace CarRental.Api.Model
{
    [Flags]
    public enum VehicleType
    {
        [EnumMember(Value = "Compact")]
        Compact,

        [EnumMember(Value = "Sedan")]
        Sedan,
        [EnumMember(Value = "SUV")]
        SUV,
        
        [EnumMember(Value = "Van")] 
        Van
    }
}
