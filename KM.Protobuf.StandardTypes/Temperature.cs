using System;

namespace KM.Protobuf.StandardTypes;

public sealed partial class Temperature
{
    public Temperature ConvertTo(UnitOfTemperature unitOfTemperature)
    {
        return new Temperature
        {
            Unit = unitOfTemperature,
            Value = (Unit, unitOfTemperature) switch
            {
                (UnitOfTemperature.Unspecified, UnitOfTemperature.Unspecified) => Value,
                (UnitOfTemperature.Celsius, UnitOfTemperature.Celsius) => Value,
                (UnitOfTemperature.Fahrenheit, UnitOfTemperature.Fahrenheit) => Value,
                (UnitOfTemperature.Kelvin, UnitOfTemperature.Kelvin) => Value,

                (UnitOfTemperature.Celsius, UnitOfTemperature.Fahrenheit) => (Value * 9f) / 5f + 32f,
                (UnitOfTemperature.Celsius, UnitOfTemperature.Kelvin) => Value + 273.15f,

                (UnitOfTemperature.Fahrenheit, UnitOfTemperature.Celsius) => (Value - 32f) * 5f / 9f,
                (UnitOfTemperature.Fahrenheit, UnitOfTemperature.Kelvin) => ((Value - 32f) * 5f / 9f) + 273.15f,

                (UnitOfTemperature.Kelvin, UnitOfTemperature.Celsius) => Value - 273.15f,
                (UnitOfTemperature.Kelvin, UnitOfTemperature.Fahrenheit) => ((Value - 273.15f) * 9f) / 5f + 32f,

                _ => throw new NotSupportedException(),
            }
        };
    }
}
