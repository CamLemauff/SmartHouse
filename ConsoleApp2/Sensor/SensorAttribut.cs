using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHouse.Sensor
{
    public enum Unit
    {
        Celsius,
        Fahrenheit,
    }

    public enum TypeMeasure
    {
        Temp
    }
    public class SensorAttribut : System.Attribute
    {
        public Unit unit;

        public TypeMeasure type;

        public SensorAttribut(Unit unit, TypeMeasure type)
        {
            this.unit = unit;
            this.type = type;
        }

    }
}
