

namespace primeiroservico.Config
{

    // informações de conexão com o banco
    public static class AppSettings
    {
        /// <summary>
        ///  dados de conexão com o azure db 
        /// </summary>
        public static readonly string ENDPOINT_URI = "https://e60ae7fb-0ee0-4-231-b9ee.documents.azure.com:443/";
        public static readonly string PRIMARY_KEY = "sEmiF3PDGzzLhIFr2HLi4HjwWcrNpaw3HlTGE3XwgNNIewVzA9mXYlAGoHDymq1HvEJajPnB5cWiACDbV92TSQ==";
        public static readonly string DATABASE_NAME = "dbbemol";
        public static readonly string CONTAINER_NAME = "usuario";



        /// <summary>
        /// dados de conexão com Azure service bus
        /// </summary>
        public static readonly string CONNECTION_STRING = "Endpoint=sb://msgdesafio.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Jk5c4HPmrI1tM+FwVPcPOvFkCAGuVc1I4+ASbK/Fo1Y=";
        public static readonly string QUEUE_NAME = "filadesafio";

    }
}