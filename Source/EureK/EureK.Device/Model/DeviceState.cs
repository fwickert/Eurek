using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EureK.Device.Model
{
    public class DeviceState : DeviceMessage, IDeviceState
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "StateDateTime")]
        public DateTime StateDateTime { get; set; }

    }
}
