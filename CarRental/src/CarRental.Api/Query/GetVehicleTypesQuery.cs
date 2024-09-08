using CarRental.Api.Model;
using MediatR;
using System;
using System.Collections.Generic;

namespace CarRental.Api.Query
{
    public class GetVehicleTypesQuery : IRequest<IEnumerable<VehicleType>>
    {
        public IEnumerable<VehicleType> VehicleType { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
