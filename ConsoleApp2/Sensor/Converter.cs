using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHouse.Sensor
{
    public abstract class Converter : Sensor
    {
        public Sensor sensorConverted;

        public Converter(Sensor sensor)
        {
            sensorConverted = sensor;
        }

        public abstract double Measure();

    }

    [ConverterAttribut(startUnit: Unit.Celsius, endUnit: Unit.Fahrenheit)]
    public class CelsiusToFahrenheit : Converter
    {
        public CelsiusToFahrenheit(Sensor sensor) : base(sensor)
        {

        }

        public override double Measure()
        {
            var measure = sensorConverted.Measure();
            return (measure * (9 / 5)) + 32;
        }
    }

    [ConverterAttribut(startUnit: Unit.Fahrenheit, endUnit: Unit.Celsius)]
    public class FahrenheitToCelsius : Converter
    {
        public FahrenheitToCelsius(Sensor sensor) : base(sensor)
        {

        }

        public override double Measure()
        {
            var measure = sensorConverted.Measure();
            return (measure - 32) * (5 / 9);
        }
    }
}
