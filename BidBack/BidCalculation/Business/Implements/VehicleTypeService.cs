using BidCalculation.Business.Interfaces;
using BidCalculation.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace BidCalculation.Business.Implements;

public class VehicleTypeService(BidCalculationDbContext bidCalculationDbContext) : IVehicleTypeService
{
    private readonly BidCalculationDbContext _bidCalculationDbContext = bidCalculationDbContext;

    public async Task<List<VehicleType>> GetAllVehicleTypesAsync() => await _bidCalculationDbContext.VehicleType.ToListAsync();
}
