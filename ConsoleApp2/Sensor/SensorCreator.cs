using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SmartHouse.Sensor
{
    public interface SensorCreator
    {
        Sensor CreateTemperatureSensor();
    }

    public class ImperialSensorCreator : SensorCreator
    {
        public Sensor CreateTemperatureSensor()
        {
            var sensor = new SensorTemp();
            TypeDescriptor.AddAttributes(sensor, new SensorAttribut(Unit.Fahrenheit, TypeMeasure.Temp));

            return sensor;
        }
    }

    public class InternationalSensorCreator : SensorCreator
    {
        public Sensor CreateTemperatureSensor()
        {
            var sensor = new SensorTemp();
            TypeDescriptor.AddAttributes(sensor, new SensorAttribut(Unit.Celsius, TypeMeasure.Temp));

            return sensor;
        }
    }
}
