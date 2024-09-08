using CarRental.Api.Handler;
using CarRental.Api.Model;
using CarRental.Api.Service;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CarRental.Api.Tests
{
    public class Tests
    {
        [Fact]
        public async Task CommandHandler_HandleHappyPath()
        {
            //Arrange
            var carRentalDataService = new Mock<ICarRentalDataService>();
            var logger = new Mock<ILogger<CreateCarRentalReservationCommandHandler>>();

            carRentalDataService.Setup(x => x.CreateReservationAsync(It.IsAny<VehicleType>(),It.IsAny<DateTime>(), It.IsAny<DateTime>())).
                            Returns(Task.FromResult(It.IsAny<int>()))
                            .Verifiable();

            var handler = new CreateCarRentalReservationCommandHandler(carRentalDataService.Object, logger.Object);

            //Act
            var response = await handler.Handle(new Command.CreateCarRentalReservationCommand(), default);

            //Assert
            carRentalDataService.Verify();
            response.Should().BeGreaterThan(-1);
        }
    }
}