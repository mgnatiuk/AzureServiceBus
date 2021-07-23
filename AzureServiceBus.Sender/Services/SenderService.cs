using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using AzureServiceBus.Sender.Services.Interfaces;
using AzureServiceBus.Shared.Configurations;
using Newtonsoft.Json;

namespace AzureServiceBus.Sender.Services
{
    public class SenderService : ISenderService
    {
        private string _serviceBusConnectionStrings { get; set; }

        public SenderService(string serviceBusConnectionStrings)
        {
            _serviceBusConnectionStrings = serviceBusConnectionStrings;
        }

        public async Task SendMessageAsync<T>(T model, string queueName)
        {
            try
            {
                await using var client = new ServiceBusClient(_serviceBusConnectionStrings);

                ServiceBusSender sender = client.CreateSender(queueName);

                string messageBody = JsonConvert.SerializeObject(model);

                ServiceBusMessage message = new ServiceBusMessage(Encoding.UTF8.GetBytes(messageBody));

                await sender.SendMessageAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}");
            }
        }
    }
}
