using TestApbd1.Model;
namespace TestApbd1.Services;


public interface IDbService
{
    Task<DeliveryResponseDto> GetDeliveryAsync(int deliveryId);
    Task<int> AddDeliveryAsync(DeliveryRequestDto request);
}