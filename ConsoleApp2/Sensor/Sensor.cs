using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHouse.Sensor
{
    public interface Sensor
    {
        double Measure();
    }

    class SensorTemp : Sensor
    {
        public double Measure() => new Random().Next(500);
    }
}
