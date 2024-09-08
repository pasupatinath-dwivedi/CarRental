using CarRental.Api.Command;
using CarRental.Api.Model;
using CarRental.Api.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarRentalController 

    {
        private readonly IMediator _mediator;
        private readonly ILogger<CarRentalController> _logger;

        public CarRentalController(IMediator mediator, ILogger<CarRentalController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("availability")]
        public async Task<IActionResult> GetAvailabilityAsync(DateTime pickupDate, DateTime returnDate, [FromQuery] IEnumerable<VehicleType> vehicleTypes = null)
        {
            _logger.LogInformation("Get Availability api call.");
            var response = await _mediator.Send(new GetVehicleTypesQuery() { PickupDate = pickupDate, ReturnDate = returnDate, VehicleType = vehicleTypes});

            return new OkObjectResult(response);
        }

        [HttpPost("reserve")]
        public async Task<IActionResult> ReserveVehicleAsync(CreateCarRentalReservationCommand req)
        {
            _logger.LogInformation("ReserveVehicle api call started a request.");

            if (req == null)
            {
                return new BadRequestResult();
            }

            var response = await _mediator.Send(req);
            if(response > 0)
            return new OkObjectResult(response);
            else
            {
                return new BadRequestObjectResult("No vehicles of the requested type are available for the specified date range");
            }
        }
    }


}
//}
