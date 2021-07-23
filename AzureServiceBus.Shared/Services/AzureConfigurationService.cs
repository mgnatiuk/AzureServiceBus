using System;
using System.Threading.Tasks;
using AzureServiceBus.Shared.Configurations;
using AzureServiceBus.Shared.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AzureServiceBus.Shared.Services
{
    public class AzureConfigurationService : IAzureConfigurationService
    {
        public AzureConfigurations SetupConfiguration()
        {
            var settings = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();

            AzureConfigurations configuration = settings.GetSection(nameof(AzureConfigurations))
                .Get<AzureConfigurations>();

            return configuration;
        }
    }
}
