namespace BidCalculation.Business.Interfaces;

public interface IBidCalculationService
{
    Task<double> GetTotalBasedOnVehicleType(double vehiclePrice, int vehicleTypeId);
}
