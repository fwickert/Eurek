#load "Device.csx"
using System.Net;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices;
using System.Text;
using Newtonsoft.Json;

private static string connectionString = "HostName=EurekIoTHub.azure-devices.net;SharedAccessKeyName=registryReadWrite;SharedAccessKey=GtBWJiQ0+yZfzEvA0UBrPvNBqedzqDgIQxzOjP0aPGs=";
private static RegistryManager registryManager;
static DeviceClient deviceClient;
static string iotHubUri = "EurekIoTHub.azure-devices.net";


public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    //log.Info("C# HTTP trigger function processed a request.");   

    //Get Body Request Data Json to Object
    DeviceMessage data = await req.Content.ReadAsAsync<DeviceMessage>();

    log.Info(data.DeviceID);
    SendDeviceToCloudMessagesAsync(data);

    return req.CreateResponse(HttpStatusCode.OK, $"Message  was processed");
}

private static async void SendDeviceToCloudMessagesAsync(DeviceMessage msg)
{
    //IOT "Admin" code to get Device Key
    registryManager = RegistryManager.CreateFromConnectionString(connectionString);
    Device device = null;
    device = await registryManager.GetDeviceAsync(msg.DeviceID);
    string key = device.Authentication.SymmetricKey.PrimaryKey;

    //Device Simulator
    deviceClient = DeviceClient.Create(iotHubUri,
                new DeviceAuthenticationWithRegistrySymmetricKey(msg.DeviceID, key),
                Microsoft.Azure.Devices.Client.TransportType.Http1);

    var messageString = JsonConvert.SerializeObject(msg);
    var message = new Microsoft.Azure.Devices.Client.Message(Encoding.ASCII.GetBytes(messageString));
    await deviceClient.SendEventAsync(message);

}