using System;
namespace AzureServiceBus.Shared.Configurations
{
    public class AzureConfigurations
    {
        public ConnectionStrings ConnectionStrings { get; set; }

        public Queue Queues { get; set; }
    }

    public class ConnectionStrings
    {
        public string AzureServiceBus { get; set; }
    }

    public class Queue
    {
        public string ClientsQueueName { get; set; }
    }
}
