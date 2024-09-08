using CarRental.Api.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Api.Service
{
    public class CarRentalDataService :ICarRentalDataService
    {
        private readonly ILogger _log;
        private readonly List<Reservation> _reservations = new List<Reservation>();
        public CarRentalDataService(ILogger log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));

        }

        private readonly Dictionary<VehicleType, int> _inventory = new Dictionary<VehicleType, int>
        {
            { VehicleType.Compact, 2 },
            { VehicleType.Sedan, 5 },
            { VehicleType.SUV, 3 },
            { VehicleType.Van, 4 }
        };

        

        public Task<IEnumerable<VehicleType>> GetAvailableVehicleTypesAsync(DateTime pickupDate, DateTime returnDate, IEnumerable<VehicleType> vehicleTypes = null)
        {
            vehicleTypes ??= _inventory.Keys;

            return Task.Run(()=> vehicleTypes.Where(type =>
                _reservations.Count(r => r.VehicleType == type &&
                                         r.PickupDate < returnDate &&
                                         r.ReturnDate > pickupDate) < _inventory[type]));
        }

        public async Task<int> CreateReservationAsync(VehicleType vehicleType, DateTime pickupDate, DateTime returnDate)
        {
            _log.LogInformation("Create reservation");

            // Check if there are available vehicles of the requested type
            var availableCount = _inventory[vehicleType] - _reservations.Count(r => r.VehicleType.Equals(vehicleType) &&
                                                                                   r.PickupDate < returnDate &&
                                                                                   r.ReturnDate > pickupDate);
            if (availableCount > 0 )
            {
                var id = _reservations.Count + 1;
                _reservations.Add(new Reservation
                {
                    Id = id,
                    VehicleType = vehicleType,
                    PickupDate = pickupDate,
                    ReturnDate = returnDate
                });
                return await Task.Run(()=>id);
            }
            return -1;
        }


    }
}
