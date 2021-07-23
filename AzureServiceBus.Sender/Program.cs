using System;
using System.Threading.Tasks;
using AzureServiceBus.Sender.Services;
using AzureServiceBus.Sender.Services.Interfaces;
using AzureServiceBus.Shared.Configurations;
using AzureServiceBus.Shared.Models;
using AzureServiceBus.Shared.Services;
using AzureServiceBus.Shared.Services.Interfaces;

namespace AzureServiceBus.Sender
{
    class Program
    {
        static async Task Main(string[] args)
        {

            IAzureConfigurationService configService = new AzureConfigurationService();
            AzureConfigurations _configuration = configService.SetupConfiguration();

            ClientDto model = GetClient();

            ISenderService sender = new SenderService(_configuration.ConnectionStrings.AzureServiceBus);
            await sender.SendMessageAsync(model, _configuration.Queues.ClientsQueueName);

            Console.WriteLine($"--- Client was sended successfully to queue: {_configuration.Queues.ClientsQueueName} ---");
            Console.ReadKey();
        }

        public static ClientDto GetClient()
        {
            Console.WriteLine("Please enter client first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Please enter client last name:");
            string lastName = Console.ReadLine();

            ClientDto dto = new ClientDto(firstName, lastName);

            return dto;
        }
    }
}
