
using Azure.Messaging.ServiceBus;

namespace primeiroservico.Repository
{
    public class ServiceBusIntegrationRepository
    {
        private readonly ServiceBusSender _sender;

        public ServiceBusIntegrationRepository(string connectionString, string queueName)
        {
            ServiceBusClient client = new ServiceBusClient(connectionString);
            _sender = client.CreateSender(queueName);
        }

        public async Task EnviarMensagemParaFilaAsync(string mensagem)
        {
            ServiceBusMessage message = new ServiceBusMessage(mensagem);

            await _sender.SendMessageAsync(message);
        }
    }
}