using System;

namespace BidCalculation.Business.Interfaces;

public interface IBidCalculation
{
    public double GetTotalBasedOnVehicleType(double VehiclePrice, int VehicleTypeId);
}
