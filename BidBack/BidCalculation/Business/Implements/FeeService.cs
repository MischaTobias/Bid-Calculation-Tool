using BidCalculation.Business.Interfaces;
using BidCalculation.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace BidCalculation.Business.Implements;

public class FeeService(BidCalculationDbContext bidCalculationDbContext) : IFeeService
{
    private readonly BidCalculationDbContext _bidCalculationDbContext = bidCalculationDbContext;

    public async Task<Fee?> GetFeeByFeeTypeIdAndVehicleTypeId(int feeTypeId, int vehicleTypeId) => 
        await _bidCalculationDbContext.Fee.Where(f => (vehicleTypeId != 0 && f.FeeTypeId == feeTypeId && f.VehicleTypeId == vehicleTypeId)
                                                   || (vehicleTypeId == 0 && f.FeeTypeId == feeTypeId)).FirstOrDefaultAsync();
}
