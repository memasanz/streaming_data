using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.EventHubs;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;

namespace ptn_generate_events
{


    class Program
    {
        private static EventHubClient eventHubClient;
        private static string EventHubConnectionString;
        private static string EventHubName;
        private static int val;
        static void Main(string[] args)
        {
            ReadConfiguration();
            Console.WriteLine("Going to Event Hub Name: " + EventHubName);
            Console.WriteLine("******************************************");
            Console.WriteLine("Max Record count to send:");
            MainAsync(args).GetAwaiter().GetResult();
            val = 0;
        }

        private static async Task MainAsync(string[] args)
        {
            int maxRecordCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Seconds delay each call:");
            int delay = Convert.ToInt32(Console.ReadLine());

            // Creates an EventHubsConnectionStringBuilder object from the connection string, and sets the EntityPath.
            // Typically, the connection string should have the entity path in it, but for the sake of this simple scenario
            // we are using the connection string from the namespace.
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(EventHubConnectionString)
            {
                EntityPath = EventHubName
            };

            eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
            var messageCount = maxRecordCount;

            await SendMessagesToEventHub(messageCount, delay);

            await eventHubClient.CloseAsync();

            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }

        private static string CreatePNTObject()
        {
            //var recordsString = "";
            var ptnObj = new PTNDevice();
            ptnObj.Date = System.DateTimeOffset.UtcNow;

            ptnObj.DeviceId = new Random().Next(0, 50);
            ptnObj.Value = new Random().Next(0, 100).ToString();
            ptnObj.Value_Quality = 192;
            ptnObj.Summary = "Demo";


            return JsonSerializer.Serialize<PTNDevice>(ptnObj);
    
        }
        private static async Task SendMessagesToEventHub(int messageCount, int delay)
        {
            for (var i = 0; i < messageCount; i++)
                try
                {
                    
                    var recordString = CreatePNTObject();

                    EventData eventData = new EventData(Encoding.UTF8.GetBytes(recordString));

                    var message = $"Message {i}";
                    Console.WriteLine($"Sending message: {recordString}");
                    await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(recordString)));
                    await Task.Delay(TimeSpan.FromSeconds(delay));
                }
 

 
                    catch (Exception exception)
                    {
                        Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
                    }

   
                }

        private static void ReadConfiguration()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            EventHubConnectionString = config["EventHubNamespaceConnectionString"];
            EventHubName = config["EventHubName"];


            if (String.IsNullOrEmpty(EventHubConnectionString)
                || String.IsNullOrEmpty(EventHubName))
            {
                throw new Exception();
            }
        }
    }
}
