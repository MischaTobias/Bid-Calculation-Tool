using BidCalculation.DataTransferObjects;

namespace BidCalculation.Business.Interfaces;

public interface IAdditionalCostService
{
    Task<AdditionalCost?> GetCostBasedOnVehiclePrice(double vehiclePrice);
}
