using System;

namespace KM.Protobuf.StandardTypes
{
    public sealed partial class Temperature
    {
        public Temperature ConvertTo(UnitOfTemperature unitOfTemperature)
        {
            return new Temperature
            {
                Unit = unitOfTemperature,
                Temperature_ = (Unit, unitOfTemperature) switch
                {
                    (UnitOfTemperature.Unspecified, UnitOfTemperature.Unspecified) => Temperature_,
                    (UnitOfTemperature.Celsius, UnitOfTemperature.Celsius) => Temperature_,
                    (UnitOfTemperature.Fahrenheit, UnitOfTemperature.Fahrenheit) => Temperature_,
                    (UnitOfTemperature.Kelvin, UnitOfTemperature.Kelvin) => Temperature_,

                    (UnitOfTemperature.Celsius, UnitOfTemperature.Fahrenheit) => (Temperature_ * 9f) / 5f + 32f,
                    (UnitOfTemperature.Celsius, UnitOfTemperature.Kelvin) => Temperature_ + 273.15f,

                    (UnitOfTemperature.Fahrenheit, UnitOfTemperature.Celsius) => (Temperature_ - 32f) * 5f / 9f,
                    (UnitOfTemperature.Fahrenheit, UnitOfTemperature.Kelvin) => ((Temperature_ - 32f) * 5f / 9f) + 273.15f,

                    (UnitOfTemperature.Kelvin, UnitOfTemperature.Celsius) => Temperature_ - 273.15f,
                    (UnitOfTemperature.Kelvin, UnitOfTemperature.Fahrenheit) => ((Temperature_ - 273.15f) * 9f) / 5f + 32f,

                    _ => throw new NotSupportedException(),
                }
            };
        }
    }
}
