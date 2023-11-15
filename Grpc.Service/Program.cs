using Grpc.Service.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();

var app = builder.Build();
app.MapGrpcService<WeatherForcaster>();
app.Run();
