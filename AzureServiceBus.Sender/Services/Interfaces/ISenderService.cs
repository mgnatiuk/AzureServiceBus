using System;
using System.Threading.Tasks;
using AzureServiceBus.Shared.Configurations;

namespace AzureServiceBus.Sender.Services.Interfaces
{
    public interface ISenderService
    {
        Task SendMessageAsync<T>(T model, string queueName);
    }
}
