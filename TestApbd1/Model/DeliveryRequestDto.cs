namespace TestApbd1.Model;

public class DeliveryRequestDto
{
    public int DeliveryId { get; set; }
    public int CustomerId { get; set; }
    public string LicenceNumber { get; set; } = null!;
    public List<ProductInputDto> Products { get; set; } = new();
}