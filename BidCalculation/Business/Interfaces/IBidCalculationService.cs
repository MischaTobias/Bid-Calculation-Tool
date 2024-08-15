using BidCalculation.Entities;

namespace BidCalculation.Business.Interfaces;

public interface IBidCalculationService
{
    Task<Bid> GetTotalBasedOnVehicleType(double vehiclePrice, int vehicleTypeId);
}
