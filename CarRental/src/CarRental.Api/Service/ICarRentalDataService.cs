using CarRental.Api.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.Api.Service
{
    public interface ICarRentalDataService
    {
        Task<int> CreateReservationAsync(VehicleType vehicleType, DateTime pickupDate, DateTime returnDate);
        Task<IEnumerable<VehicleType>> GetAvailableVehicleTypesAsync(DateTime pickupDate, DateTime returnDate, IEnumerable<VehicleType> vehicleTypes = null);
      }
}
