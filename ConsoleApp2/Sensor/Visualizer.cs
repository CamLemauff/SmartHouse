using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHouse.Sensor
{
    public interface Visualizer
    {
        void UpdateSensor();

        void SetSensor(Sensor sensor);
    }

    [SensorAttribut(Unit.Celsius, TypeMeasure.Temp)]
    public class TempVisualizer : Visualizer
    {
        public Sensor sensor;

        public void UpdateSensor()
        {
            Console.WriteLine("La température est de " + sensor.Measure() + "°C");
        }

        public void SetSensor(Sensor sensor)
        {
            this.sensor = sensor;
        }
    }
}
