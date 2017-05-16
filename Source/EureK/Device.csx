using System;
using Newtonsoft.Json;

interface IDeviceMessage
{
    string DeviceID { get; set; }
    bool OnOff { get; set; }
    int Lux { get; set; }
    int Angle { get; set; }

}

interface IDeviceState : IDeviceMessage
{
    string id { get; set; }
    DateTime StateDateTime { get; set; }

}

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