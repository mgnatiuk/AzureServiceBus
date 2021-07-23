using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using AzureServiceBus.Shared.Models;

namespace AzureServiceBus.Receiver.Services.Interfaces
{
    public interface IReceiverService
    {
        Task<ClientDto> ReciveClientMessage();
        Task<ClientDto> PeekClientMessage();
        ServiceBusReceiver CreateReceiver();
    }
}
