
using System;

namespace CarRental.Api.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
