using CarRental.Api.Command;
using CarRental.Api.Service;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace CarRental.Api.Handler
{
    public class CreateCarRentalReservationCommandHandler : IRequestHandler<CreateCarRentalReservationCommand, int>
    {
        private readonly ICarRentalDataService _carRentalDataService;
        private readonly ILogger _logger;


        public CreateCarRentalReservationCommandHandler(ICarRentalDataService carRentalDataService, ILogger<CreateCarRentalReservationCommandHandler> logger)
        {
            _carRentalDataService = carRentalDataService ?? throw new ArgumentNullException(nameof(carRentalDataService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task<int> Handle(CreateCarRentalReservationCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call db service to create transaction");

            // consider using Automapper if object is more complex
            return await _carRentalDataService.CreateReservationAsync(command.VehicleType, command.PickupDate, command.ReturnDate);
        }
    }
}
