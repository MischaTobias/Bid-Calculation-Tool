using BidCalculation.Business.Implements; // Adjust namespace as needed
using BidCalculation.Business.Interfaces; // Assuming these interfaces are in your project
using BidCalculation.DataTransferObjects;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;

public class BidCalculationServiceTests
{
    private readonly BidCalculationService _service;
    private readonly Mock<IFeeTypeService> _mockFeeTypeService;
    private readonly Mock<IFeeService> _mockFeeService;
    private readonly Mock<IAdditionalCostService> _mockAdditionalCostService;

    public BidCalculationServiceTests()
    {
        // Initialize the mocks
        _mockFeeTypeService = new Mock<IFeeTypeService>();
        _mockFeeService = new Mock<IFeeService>();
        _mockAdditionalCostService = new Mock<IAdditionalCostService>();

        // Setup a service collection and add the mocked dependencies
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddScoped(_ => _mockFeeTypeService.Object);
        serviceCollection.AddScoped(_ => _mockFeeService.Object);
        serviceCollection.AddScoped(_ => _mockAdditionalCostService.Object);

        // Add the BidCalculationService with the mocked dependencies
        serviceCollection.AddScoped<BidCalculationService>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        _service = serviceProvider.GetService<BidCalculationService>();
    }

    [Fact]
    public async Task CalculateBid_ShouldReturnCorrectResult_ForValidInput()
    {
        // Arrange
        var basePrice = 1000;
        var vehicleType = 1; // Common

        // Mocking the dependencies behavior (if needed)
        _mockFeeTypeService.Setup(x => x.GetFeeTypeByName("Basic Buyer")).ReturnsAsync(new FeeType() { Id = 1, Name = "Basic Buyer" }); // Mock a valid fee type
        _mockFeeService.Setup(x => x.GetFeeByFeeTypeIdAndVehicleTypeId(1, 1)).ReturnsAsync(new Fee() { Value = 0.1, FeeType = new FeeType() { Id = 1, Name = "Basic Buyer" }, Minimum = 10, Maximum = 50 }); // Mock the fee calculation

        _mockFeeTypeService.Setup(x => x.GetFeeTypeByName("Seller Special")).ReturnsAsync(new FeeType() { Id = 2, Name = "Seller Special" }); // Mock a valid fee type
        _mockFeeService.Setup(x => x.GetFeeByFeeTypeIdAndVehicleTypeId(2, 1)).ReturnsAsync(new Fee() { Value = 0.02, FeeType = new FeeType() { Id = 2, Name = "Seller Special" } }); // Mock the fee calculation

        _mockFeeTypeService.Setup(x => x.GetFeeTypeByName("Fixed Storage")).ReturnsAsync(new FeeType() { Id = 3, Name = "Fixed Storage" }); // Mock a valid fee type
        _mockFeeService.Setup(x => x.GetFeeByFeeTypeIdAndVehicleTypeId(3, 0)).ReturnsAsync(new Fee() { Value = 100, FeeType = new FeeType() { Id = 3, Name = "Fixed Storage" } }); // Mock the fee calculation

        _mockAdditionalCostService.Setup(x => x.GetCostBasedOnVehiclePrice(1000)).ReturnsAsync(new AdditionalCost() { Value = 10 }); // Mock a valid fee type        

        // Act
        var result = await _service.GetBidAsync(basePrice, vehicleType);

        // Assert
        result.Total.Should().Be(1180); // Assuming 1000 base price + 180 fee = 1180 total
    }

    [Fact]
    public async Task CalculateBid_ShouldHandleInvalidInputsGracefully()
    {
        // Arrange
        var basePrice = -100; // Assuming negative value is invalid
        var vehicleType = 1; // Common

        // Act
        Func<Task>  act = async () => await _service.GetBidAsync(basePrice, vehicleType);

        // Assert
        await act.Should().ThrowAsync<Exception>()
            .WithMessage("Vehicle price should be higher than 0.");
    }
}
