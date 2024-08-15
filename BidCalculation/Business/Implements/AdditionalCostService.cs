using BidCalculation.Business.Interfaces;
using BidCalculation.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace BidCalculation.Business.Implements;

public class AdditionalCostService(BidCalculationDbContext bidCalculationDbContext) : IAdditionalCostService
{
    private readonly BidCalculationDbContext _bidCalculationDbContext = bidCalculationDbContext;

    public async Task<AdditionalCost?> GetCostBasedOnVehiclePrice(double vehiclePrice) {
        return await _bidCalculationDbContext.AdditionalCost
        .Where(ac => 
            (ac.UpperLimit != 0 && ac.LowerLimit <= vehiclePrice && ac.UpperLimit >= vehiclePrice) || 
            (ac.UpperLimit == 0 && ac.LowerLimit <= vehiclePrice)
        )
        .FirstOrDefaultAsync();
    } 
}
