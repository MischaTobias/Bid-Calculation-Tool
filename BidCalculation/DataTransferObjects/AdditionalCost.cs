namespace BidCalculation.DataTransferObjects;

public class AdditionalCost
{
    public int Id { get; set; }
    public string? Criteria { get; set; }
    public double LowerLimit { get; set; }
    public double UpperLimit { get; set; }
    public double Value { get; set; }
}
