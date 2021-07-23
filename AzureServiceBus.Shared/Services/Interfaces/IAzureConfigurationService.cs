using System;
using System.Threading.Tasks;
using AzureServiceBus.Shared.Configurations;

namespace AzureServiceBus.Shared.Services.Interfaces
{
    public interface IAzureConfigurationService
    {
        AzureConfigurations SetupConfiguration();
    }
}
