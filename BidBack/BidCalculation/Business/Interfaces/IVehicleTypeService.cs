using BidCalculation.DataTransferObjects;

namespace BidCalculation.Business.Interfaces;

public interface IVehicleTypeService
{
    Task<List<VehicleType>> GetAllVehicleTypesAsync();
}
