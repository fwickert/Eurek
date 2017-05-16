using System;
using System.Collections.Generic;
using System.Text;

namespace EureK.Device.Model
{
    interface IDeviceMessage
    {
        string DeviceID { get; set; }
        bool OnOff { get; set; }
        int Lux { get; set; }
        int Angle { get; set; }
        
    }
}
