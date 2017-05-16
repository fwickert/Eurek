using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EureK.Device.Model
{
    public class DeviceMessage : IDeviceMessage
    {
        [JsonProperty(PropertyName = "DeviceID")]
        public string DeviceID { get; set; }

        [JsonProperty(PropertyName = "OnOff")]
        public bool OnOff { get; set; }

        [JsonProperty(PropertyName = "Lux")]
        public int Lux { get; set; }

        [JsonProperty(PropertyName = "Angle")]
        public int Angle { get; set; }
    }
}
