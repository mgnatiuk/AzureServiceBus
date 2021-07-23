using System;
using System.Threading.Tasks;
using AzureServiceBus.Receiver.Services;
using AzureServiceBus.Receiver.Services.Interfaces;
using AzureServiceBus.Shared.Configurations;
using AzureServiceBus.Shared.Services;
using AzureServiceBus.Shared.Services.Interfaces;

namespace AzureServiceBus.Receiver
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Click Enter for receiving messages...");
            Console.ReadKey();

            IAzureConfigurationService configService = new AzureConfigurationService();
            AzureConfigurations _configuration = configService.SetupConfiguration();

            IReceiverService receiver = new ReceiverService(_configuration.ConnectionStrings.AzureServiceBus, _configuration.Queues.ClientsQueueName);

            await receiver.ReciveClientMessage();
        }
    }
}
