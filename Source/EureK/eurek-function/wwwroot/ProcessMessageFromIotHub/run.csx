#load "Device.csx"
#load "DeviceService.csx"
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;


public static void Run(string myEventHubMessage, TraceWriter log)
{
    //deserialize string to DeviceMessage
    DeviceMessage deviceMsg = JsonConvert.DeserializeObject<DeviceMessage>(myEventHubMessage);

    //Check if for this deviceID, attributes was different, if so, insert new doc. else nothing
    Task<DeviceState> deviceState = Task.Run(() =>
                DeviceService.GetLastDeviceStateAsync(deviceMsg.DeviceID));
    deviceState.Wait();

    DeviceState ds = deviceState.Result;

    if (ds == null)
    {
        //Create Document
        CreateDeviceState(deviceMsg);
    }
    else
    {
        //Check difference and create DOc if different
        bool update = false;

        update = !(deviceMsg.OnOff == ds.OnOff);
        update = update || !(deviceMsg.Lux == ds.Lux);
        update = update || !(deviceMsg.Angle == ds.Angle);
        if (update)
        {
            //Create new document
            CreateDeviceState(deviceMsg);
        }

    }

    log.Info($"message {DateTime.UtcNow.ToString()} : {deviceMsg.DeviceID}");
}

private static void CreateDeviceState(DeviceMessage deviceMsg)
{
    DeviceState ds = new DeviceState()
    {
        id = Guid.NewGuid().ToString(),
        DeviceID = deviceMsg.DeviceID,
        OnOff = deviceMsg.OnOff,
        Angle = deviceMsg.Angle,
        Lux = deviceMsg.Lux,
        StateDateTime = DateTime.UtcNow
    };
    Task.Run(() => DeviceService.CreateDeviceStateAsync(ds));

}




