using BidCalculation.Business.Interfaces;
using BidCalculation.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace BidCalculation.Business.Implements;

public class FeeTypeService(BidCalculationDbContext bidCalculationDbContext) : IFeeTypeService
{
    private readonly BidCalculationDbContext _bidCalculationDbContext = bidCalculationDbContext;

    public async Task<FeeType?> GetFeeTypeByName(string name) => await _bidCalculationDbContext.FeeType.Where(ft => ft.Name == name).FirstOrDefaultAsync();
}
