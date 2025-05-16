
using TestApbd1.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IDbService, Dbservice>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();