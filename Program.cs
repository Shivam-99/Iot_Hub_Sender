using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;

namespace IoT_Hub_Sender
{
    class Program
    {
        static ServiceClient serviceClient;
        static string connectionString = "HostName=DemoIoTHubApp.azure-devices.net;DeviceId=IotDeviceDemo;SharedAccessKey=f103jW1XArqRi4ZILkQ0/Zx7mqXBxbsmBBU/yopRMaY=";
        static void Main(string[] args)
        {
            Console.WriteLine("Send Cloud-to-Device message\n");
            serviceClient = ServiceClient.CreateFromConnectionString(connectionString);

            Console.WriteLine("Press any key to send a C2D message.");
            Console.ReadLine();
            SendCloudToDeviceMessageAsync().Wait();
            Console.ReadLine();
        }
        private static async Task SendCloudToDeviceMessageAsync()
        {
            var commandMessage = new
                Message(Encoding.ASCII.GetBytes("Cloud to device message."));
            await serviceClient.SendAsync("myFirstDevice", commandMessage);
        }
    }
}
