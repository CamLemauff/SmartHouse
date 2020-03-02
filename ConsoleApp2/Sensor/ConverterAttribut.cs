using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHouse.Sensor
{
    class ConverterAttribut : Attribute
    {
        public Unit startUnit;

        public Unit endUnit;

        public ConverterAttribut(Unit startUnit, Unit endUnit)
        {
            this.startUnit = startUnit;

            this.endUnit = endUnit;
        }
    }
}
