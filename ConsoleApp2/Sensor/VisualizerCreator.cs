using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHouse.Sensor
{
    public class VisualizerCreator
    {
        public Visualizer CreateVisualizer(TypeMeasure visType, Unit visUnit)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var assemblyTypes = assembly.GetTypes();
                foreach (var type in assemblyTypes)
                {
                    if (typeof(Visualizer).IsAssignableFrom(type) && type.IsDefined(typeof(SensorAttribut), true))
                    {
                        var attribut = (SensorAttribut)Attribute.GetCustomAttribute(type, typeof(SensorAttribut));
                        if (attribut.type == visType)
                        {
                            return (Visualizer)Activator.CreateInstance(type);
                        }
                    }
                }
            }
            return null;
        }
    }
}
