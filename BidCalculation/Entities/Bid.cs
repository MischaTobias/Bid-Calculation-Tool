namespace BidCalculation.Entities;

public class Bid
{
    public double Total { get; set; }
    public required List<FeeDetail> Fees { get; set; }
}
