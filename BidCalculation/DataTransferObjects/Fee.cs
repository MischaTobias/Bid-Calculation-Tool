﻿namespace BidCalculation.DataTransferObjects;

public class Fee
{
    public int Id { get; set; }
    public int FeeTypeId { get; set; }
    public int? VehicleTypeId { get; set; }
    public double Value { get; set; }
    public double Minimum { get; set; }
    public double Maximum { get; set; }
    public required FeeType FeeType { get; set; }
    public VehicleType? VehicleType { get; set; }
}
