using BidCalculation.Entities;

namespace BidCalculation.Business.Interfaces;

public interface IBidCalculationService
{
    Task<Bid> GetBidAsync(double vehiclePrice, int vehicleTypeId);
}
