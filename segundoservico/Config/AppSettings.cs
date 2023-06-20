

namespace primeiroservico.Config
{

    // informações de conexão com o banco
    public static class AppSettings
    {

        /// <summary>
        /// dados de conexão com Azure service bus
        /// </summary>
        public static readonly string CONNECTION_STRING = "Endpoint=sb://msgdesafio.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Jk5c4HPmrI1tM+FwVPcPOvFkCAGuVc1I4+ASbK/Fo1Y=";
        public static readonly string QUEUE_NAME = "filadesafio";

    }
}