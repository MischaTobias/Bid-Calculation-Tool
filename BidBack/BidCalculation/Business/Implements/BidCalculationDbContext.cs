using BidCalculation.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace BidCalculation.Business.Implements;

public class BidCalculationDbContext(DbContextOptions<BidCalculationDbContext> context) : DbContext(context)
{
    public DbSet<AdditionalCost> AdditionalCost { get; set; }
    public DbSet<Fee> Fee { get; set; }
    public DbSet<FeeType> FeeType { get; set; }
    public DbSet<VehicleType> VehicleType { get; set; }
}
