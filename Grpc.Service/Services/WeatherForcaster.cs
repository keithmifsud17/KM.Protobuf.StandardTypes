using Grpc.Core;
using KM.Protobuf.StandardTypes;
using Weather;

namespace Grpc.Service.Services
{
    public class WeatherForcaster : Weather.WeatherForcaster.WeatherForcasterBase
    {
        private readonly ILogger<WeatherForcaster> _logger;
        public WeatherForcaster(ILogger<WeatherForcaster> logger)
        {
            _logger = logger;
        }

        public override Task<GetTemperatureReply> GetTemperature(GetTemperatureRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Received Request with unit {unit}", request.Unit);

            return Task.FromResult(new GetTemperatureReply
            {
                Temperature = new Temperature
                {
                    Unit = request.Unit,
                    Temperature_ = Random.Shared.Next(0, 100)
                }
            });
        }
    }
}