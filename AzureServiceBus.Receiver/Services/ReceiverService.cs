using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using AzureServiceBus.Receiver.Services.Interfaces;
using AzureServiceBus.Shared.Models;
using Newtonsoft.Json;

namespace AzureServiceBus.Receiver.Services
{
    public class ReceiverService : IReceiverService
    {

        private string _connectionStrings { get; set; }

        private string _queueName { get; set; }

        public ReceiverService(string connectionStrings, string queueName)
        {
            _connectionStrings = connectionStrings;
            _queueName = queueName;
        }

        public ServiceBusReceiver CreateReceiver()
        {
            ServiceBusClient client = new ServiceBusClient(_connectionStrings);

            ServiceBusReceiver receiver = client.CreateReceiver(_queueName);

            return receiver;
        }

        public async Task<ClientDto> ReciveClientMessage()
        {
            ServiceBusReceivedMessage receivedMessage = await CreateReceiver().ReceiveMessageAsync();

            ClientDto dto = JsonConvert.DeserializeObject<ClientDto>(receivedMessage.Body.ToString());

            Console.WriteLine($"--- Client was received successfully from queue: {_queueName} ---");
            Console.WriteLine($"Welcome: {dto.FirstName} {dto.LastName}. Your code: {dto.Id}.\n");

            return dto;
        }

        public async Task<ClientDto> PeekClientMessage()
        {
            ServiceBusReceivedMessage peekedMessage = await CreateReceiver().PeekMessageAsync();

            ClientDto dto = JsonConvert.DeserializeObject<ClientDto>(peekedMessage.Body.ToString());

            Console.WriteLine($"--- Client was peeked successfully from queue: {_queueName} ---");
            Console.WriteLine($"Welcome: {dto.FirstName} {dto.LastName}. Your code: {dto.Id}.\n");

            return dto;
        }
    }
}
