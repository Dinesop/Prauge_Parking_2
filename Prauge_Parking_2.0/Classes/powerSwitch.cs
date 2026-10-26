using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class PowerSwitch
    {
        public bool IsOn { get; set; }
        // Constructor
        public PowerSwitch()
        {
            IsOn = true;
        }

        public void TurnOff()
        {
            IsOn = false;
        }

        public void TurnOn()
        {
            IsOn = true;
        }
    }
}
