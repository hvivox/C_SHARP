using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using primeiroservico.Model;
using System.Text;


namespace segundoservico.Services
{
    public class FilaService : IFilaService
    {
        private QueueClient _queueClient;


        public FilaService(string connectionString, string queueName)
        {
            _queueClient = new QueueClient(connectionString, queueName);

        }

        public async Task IniciarConsumoFila()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            _queueClient.RegisterMessageHandler(ProcessMessageAsync, messageHandlerOptions);
        }


        // RECEBE A MENSAGEM DA FILA
        private async Task ProcessMessageAsync(Message message, CancellationToken cancellationToken)
        {
            var messageBody = Encoding.UTF8.GetString(message.Body);


            // Cancela chamada em caso de timeout
            await Task.Delay(Timeout.Infinite, cancellationToken);
            // Marcar a mensagem como concluída (completa) após processá-la com sucesso            
            await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }


        // TRATA A EXCEPTION
        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            // Tratar exceções ocorridas durante o consumo da fila
            Console.WriteLine($"Erro na fila: {exceptionReceivedEventArgs.Exception.StackTrace}");
            return Task.CompletedTask;
        }



        private Usuario ObterUsuarioDoCorpoDaMensagem(string messageBody)
        {
            // Implemente a lógica para extrair os dados do objeto de usuário do corpo da mensagem            
            var usuario = JsonConvert.DeserializeObject<Usuario>(messageBody);
            // Modificar o status para "PROCESSADO"
            usuario.status = "PROCESSADO";

            return usuario;
        }

        public List<Usuario> ObterMensagensConcluidas()
        {
            throw new NotImplementedException();
        }


    }
}