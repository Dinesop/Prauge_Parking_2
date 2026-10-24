using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public interface ISwitch
    {
        bool IsOn { get; set; }
        void TurnOn();
        void TurnOff();
    }
}
