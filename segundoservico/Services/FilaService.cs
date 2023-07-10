using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using segundoservico.Model;
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

            try
            {
                var messageBody = Encoding.UTF8.GetString(message.Body);
                Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
                // Simulação de atraso para fins ilustrativos(500 ms)
                //await Task.Delay(500);
                //await Task.Delay(TimeSpan.FromSeconds(1));

                // Cancela chamada em caso de timeout
                await Task.Delay(Timeout.Infinite, cancellationToken);

                // Marcar a mensagem como concluída (completa) após processá-la com sucesso            
                await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
            }
            catch (Exception ex)
            {
                // Tratar exceções ocorridas durante o processamento da mensagem
                Console.WriteLine($"Erro ao processar a mensagem: {ex.Message}");
                // Registrar a falha do processamento da mensagem, para que ela possa ser retentada ou enviada para a fila de erro, conforme necessário
                await _queueClient.AbandonAsync(message.SystemProperties.LockToken);
            }

        }


        // TRATA A EXCEPTION
        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            // Tratar exceções ocorridas durante o consumo da fila
            // Console.WriteLine($"Erro na fila: {exceptionReceivedEventArgs.Exception.StackTrace}");
            Console.WriteLine($"ERRRO NA FILA {exceptionReceivedEventArgs.Exception}.");
            return Task.CompletedTask;
        }


    }
}





















