using CarRental.Api.Model;
using MediatR;
using System;

namespace CarRental.Api.Command
{
    public class CreateCarRentalReservationCommand : IRequest<int>
    {
        //public int Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}