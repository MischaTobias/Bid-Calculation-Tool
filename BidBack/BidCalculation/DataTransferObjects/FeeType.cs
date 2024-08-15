namespace BidCalculation.DataTransferObjects;

public class FeeType
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Fee>? Fee { get; set; }
}
