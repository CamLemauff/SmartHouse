using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace SmartHouse.Sensor
{
    public class SensorManager
    {
        private Dictionary<Sensor, Visualizer> _sensors;
        private Dictionary<Unit, Type> _converters;
        private VisualizerCreator _visualizerCreator;

        public SensorManager()
        {
            _sensors = new Dictionary<Sensor, Visualizer>();
            _converters = new Dictionary<Unit, Type>();
            _visualizerCreator = new VisualizerCreator();
            RetrieveConverters();
            new Thread(Sense).Start();
        }

        public void AddSensor(Sensor sensor)
        {
            var sensorAttribut = GetSensorAttribut(sensor);
            var visualizer = _visualizerCreator.CreateVisualizer(sensorAttribut.type, sensorAttribut.unit);
            sensor = WrapSensor(sensor, visualizer);

            visualizer.SetSensor(sensor);
            _sensors[sensor] = visualizer;
        }

        public void RemoveSensor(Sensor sensor)
        {
            _sensors.Remove(sensor);
        }

        public SensorAttribut GetSensorAttribut(Sensor sensor)
        {
            var attributes = TypeDescriptor.GetAttributes(sensor);

            SensorAttribut sensorAttribut = null;

            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == typeof(SensorAttribut))
                {
                    sensorAttribut = (SensorAttribut)attribute;
                    break;
                }
            }
            return sensorAttribut;
        }

        private Sensor WrapSensor(Sensor sensor, Visualizer visualizer)
        {
            var sensorAttribute = GetSensorAttribut(sensor);
            var visualizerAttribute = (SensorAttribut)Attribute.GetCustomAttribute(visualizer.GetType(), typeof(SensorAttribut));
            if (visualizerAttribute.unit != sensorAttribute.unit)
            {
                var converter = _converters[sensorAttribute.unit];
                sensor = (Converter)Activator.CreateInstance(converter, sensor);
                Console.WriteLine($"Apply converter : {converter}");
            }
            return sensor;
        }
        private void RetrieveConverters()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var assemblyTypes = assembly.GetTypes();

                foreach (var type in assemblyTypes)
                {
                    if (typeof(Converter).IsAssignableFrom(type) && type.IsDefined(typeof(ConverterAttribut), true))
                    {
                        var attribut = (ConverterAttribut)Attribute.GetCustomAttribute(type, typeof(ConverterAttribut));
                        _converters[attribut.startUnit] = type;
                    }
                }
            }
        }


        public void Sense()
        {
            while (true)
            {
                foreach (var sensors in _sensors)
                    sensors.Value.UpdateSensor();
                Thread.Sleep(500);
            }
        }
    }
}
