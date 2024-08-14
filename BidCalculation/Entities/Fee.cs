namespace BidCalculation;

public class Fee
{
    public int Id { get; set; }
    public int VehicleTypeId { get; set; }
    public int BuyerTypeId { get; set; }
    public double Value { get; set; }
    public double Minimum { get; set; }
    public double Maximum { get; set; }
}
