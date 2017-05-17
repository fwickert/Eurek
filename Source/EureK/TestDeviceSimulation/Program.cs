using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using Microsoft.Azure.Devices;

namespace TestDeviceSimulation
{
    class Program
    {

        private static DeviceClient deviceClient;
        private static string iotHubUri = "<Your IotHub Name>.azure-devices.net";
        private static int lux = 0;
        private static string onoff = "true";
        private static string connectionString = "HostName=<Your IotHub Name>.azure-devices.net;SharedAccessKeyName=registryReadWrite;SharedAccessKey=<Your SAK>";
        private static RegistryManager registryManager;

        static void Main(string[] args)
        {

            Console.WriteLine("Simulated device\n");

            //SendDeviceToCloudMessagesAsync("100152");
            SendBulkMsgDeviceToCloudAsync();
            Console.ReadLine();

        }

        private static async void SendDeviceToCloudMessagesAsync(string deviceID)
        {
            //IOT "Admin" code to get Device Key
            registryManager = RegistryManager.CreateFromConnectionString(connectionString);
            Device device = null;
            device = await registryManager.GetDeviceAsync(deviceID);
            string key = device.Authentication.SymmetricKey.PrimaryKey;

            //Device Simulator
            deviceClient = DeviceClient.Create(iotHubUri,
                new DeviceAuthenticationWithRegistrySymmetricKey(deviceID, key),
                Microsoft.Azure.Devices.Client.TransportType.Http1);

            var telemetryDataPoint = new
            {
                DeviceID = deviceID,
                OnOff = onoff,
                Lux = lux,
                Angle = "10"
            };
            var messageString = JsonConvert.SerializeObject(telemetryDataPoint);
            var message = new Microsoft.Azure.Devices.Client.Message(Encoding.ASCII.GetBytes(messageString));


            await deviceClient.SendEventAsync(message);
            Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageString);

            await Task.Delay(2000);

        }

        //Send Fake data with 20 devices
        private static async void SendBulkMsgDeviceToCloudAsync()
        {
            //List OF 20 Fake devices
            List<string> Devices = new List<string> { "100152", "100159", "100172", "100175", "100182"};


            while (true)
            {
                foreach (var item in Devices)
                {
                    Task.Run(() => SendDeviceToCloudMessagesAsync(item)).Wait();

                    await Task.Delay(2000);
                }

                lux += 5000;
                if (DateTime.Now.Hour >= 6)
                {
                    onoff = "false";
                }

            }
        }
    }
}
