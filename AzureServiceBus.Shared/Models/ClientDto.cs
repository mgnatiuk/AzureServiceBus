using System;
namespace AzureServiceBus.Shared.Models
{
    public class ClientDto
    {
        public ClientDto(string firstName, string lastName)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
