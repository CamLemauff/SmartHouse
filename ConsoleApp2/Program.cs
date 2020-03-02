using SmartHouse.Sensor;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var sensorManager = new SensorManager();
            var imperialSensorCreator = new ImperialSensorCreator();
            var internationalSensorCreator = new InternationalSensorCreator();

            sensorManager.AddSensor(imperialSensorCreator.CreateTemperatureSensor());
            sensorManager.AddSensor(internationalSensorCreator.CreateTemperatureSensor());
        }
    }
}
