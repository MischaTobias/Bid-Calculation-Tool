using BidCalculation.DataTransferObjects;

namespace BidCalculation.Business.Interfaces;

public interface IFeeTypeService
{
    Task<FeeType?> GetFeeTypeByName(string name);
}
