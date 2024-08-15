using BidCalculation.Business.Interfaces;

namespace BidCalculation.Business.Implements;

public class BidCalculationService(IFeeTypeService feeTypeService, IFeeService feeService, IAdditionalCostService additionalCostService) : IBidCalculationService
{
    private readonly IFeeTypeService _feeTypeService = feeTypeService;
    private readonly IFeeService _feeService = feeService;
    private readonly IAdditionalCostService _additionalCostService = additionalCostService;

    public async Task<double> GetTotalBasedOnVehicleType(double vehiclePrice, int vehicleTypeId)
    {
        // Vehicle Price + Basic Buyer Fee + Special Fee + Association Fee + Storage Fee
        var total = vehiclePrice;

        // Basic Buyer Fee        
        var basicBuyerFeeType = await _feeTypeService.GetFeeTypeByName("Basic Buyer") ?? throw new Exception("No basic buyer fee type found.");
        var basicBuyerFee = await _feeService.GetFeeByFeeTypeIdAndVehicleTypeId(basicBuyerFeeType.Id, vehicleTypeId) ?? throw new Exception("No basic buyer fee found.");
        var basicBuyerFeeValue = vehiclePrice * basicBuyerFee.Value;

        basicBuyerFeeValue = Math.Min(Math.Max(basicBuyerFeeValue, basicBuyerFee.Minimum), basicBuyerFee.Maximum);
        total += basicBuyerFeeValue;

        // Special Fee        
        var sellerSpecialFeeType = await _feeTypeService.GetFeeTypeByName("Seller Special") ?? throw new Exception("No seller special fee type found.");
        var sellerSpecialFee = await _feeService.GetFeeByFeeTypeIdAndVehicleTypeId(sellerSpecialFeeType.Id, vehicleTypeId) ?? throw new Exception("No seller special fee found.");
        var sellerSpecialFeeValue = vehiclePrice * sellerSpecialFee.Value;
        
        total += sellerSpecialFeeValue;

        // Added costs for association       
        var associationCost = await _additionalCostService.GetCostBasedOnVehiclePrice(vehiclePrice) ?? throw new Exception("Error while trying to get association cost.");
        var associationCostValue = associationCost.Value;
        
        total += associationCostValue;

        // Fixed storage fee       
        var fixedStorageFeeType = await _feeTypeService.GetFeeTypeByName("Fixed Storage") ?? throw new Exception("No basic fixed storage fee type found.");
        var fixedStorageFee = await _feeService.GetFeeByFeeTypeIdAndVehicleTypeId(fixedStorageFeeType.Id, 0) ?? throw new Exception("No basic buyer fee found.");
        var fixedStorageFeeValue = fixedStorageFee.Value;

        total += fixedStorageFeeValue;

        return total;
    }
}
