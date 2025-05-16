namespace TestApbd1.Model;

public class DeliveryResponseDto
{
    public DateTime Date { get; set; }
    public CustomerDto Customer { get; set; } = null!;
    public DriverDto Driver { get; set; } = null!;
    public List<ProductDto> Products { get; set; } = new();
}