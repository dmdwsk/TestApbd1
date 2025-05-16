using TestApbd1.Exceptions;
using TestApbd1.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TestApbd1.Services;

public class Dbservice : IDbService
{
    private readonly IConfiguration _configuration;
    public DbService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<DeliveryResponseDto> GetDeliveryAsync(int deliveryId)
    {
        var response = new DeliveryRequestDto();
        var services = new List<DeliverysServiceDto>();

        await using var connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        await connection.OpenAsync();
        var command = new SqlCommand(@"
            SELECT c.first_name, c.last_name, d.first_name, d.last_name, d.date
            FROM Delivery d
            JOIN CustomerDto c ON d.customer_id = c.customer_id
            JOIN DriverDto d1  ON  d.driver_id = d1.driver_id
            JOIN DeliverysServiceDto dls ON dls.delivery_id = d.delivery_id
            Where d.delivery_id = @deliveryId
    }
    }

      public async Task<int> AddDeliveryAsync(DeliveryRequestDto request)
      {
        await using var connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        await connection.OpenAsync();
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync();


        var command = connection.CreateCommand();
        command.Transaction = transaction;
        try
        {
            command.CommandText = "SELECT 1 FROM Delivery WHERE customer_id = @Cid";
            command.Parameters.AddWithValue("@Cid", request.CustomerId);
            if (await command.ExecuteScalarAsync() is null)
                throw new NotFoundException("Delivery not found");
            
            command.Parameters.Clear();
            command.CommandText = "SELECT 1 FROM Delivery WHERE driver_id = @Did";
            command.Parameters.AddWithValue("@Did", request.DriverId);
            if (await command.ExecuteScalarAsync() is null)
                throw new NotFoundException("Doctor not found");
        }
        
    }

    
}