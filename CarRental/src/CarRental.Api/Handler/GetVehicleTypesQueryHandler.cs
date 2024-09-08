using CarRental.Api.Model;
using CarRental.Api.Query;
using CarRental.Api.Service;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Api.Handler
{
    public class GetVehicleTypesQueryHandler : IRequestHandler<GetVehicleTypesQuery, IEnumerable<VehicleType>>
    {
        private readonly ICarRentalDataService _carRentalDataService;
        private readonly ILogger _logger;

        public GetVehicleTypesQueryHandler(ILogger<GetVehicleTypesQueryHandler> logger, ICarRentalDataService carRentalDataService)
        {
            _carRentalDataService = carRentalDataService ?? throw new ArgumentNullException(nameof(carRentalDataService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<VehicleType>> Handle(GetVehicleTypesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call service to get vehicle types");
            var vehicleTypes = request.VehicleType.Any() ? request.VehicleType : null;
            return await _carRentalDataService.GetAvailableVehicleTypesAsync(request.PickupDate, request.ReturnDate, vehicleTypes);

        }
    }
}
