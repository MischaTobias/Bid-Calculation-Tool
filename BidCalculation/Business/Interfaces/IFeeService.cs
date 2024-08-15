using BidCalculation.DataTransferObjects;

namespace BidCalculation.Business.Interfaces;

public interface IFeeService
{
    Task<Fee?> GetFeeByFeeTypeIdAndVehicleTypeId(int feeTypeId, int vehicleTypeId);
}
