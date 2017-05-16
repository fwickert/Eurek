using System;
using System.Collections.Generic;
using System.Text;

namespace EureK.Device.Model
{
    interface IDeviceState : IDeviceMessage
    {
        string ID { get; set; }
        DateTime StateDateTime { get; set; }
        
    }
}
