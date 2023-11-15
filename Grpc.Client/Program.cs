using Grpc.Net.Client;
using KM.Protobuf.StandardTypes;
using Weather;

using var channel = GrpcChannel.ForAddress("https://localhost:7125");
var client = new WeatherForcaster.WeatherForcasterClient(channel);

var reply = await client.GetTemperatureAsync(new GetTemperatureRequest { Unit = UnitOfTemperature.Celsius });
Console.WriteLine("Current Temperature is {0}", reply.Temperature.Temperature_);

Console.WriteLine("Shutting down");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();