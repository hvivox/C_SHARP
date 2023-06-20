

namespace primeiroservico.Config
{

    // informações de conexão com o banco
    public static class AppSettings_fake
    {
        /// <summary>
        ///  dados de conexão com o azure db 
        /// </summary>
        public static readonly string ENDPOINT_URI = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
        public static readonly string PRIMARY_KEY = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
        public static readonly string DATABASE_NAME = "xxxx";
        public static readonly string CONTAINER_NAME = "xxxxxx";



        /// <summary>
        /// dados de conexão com Azure service bus
        /// </summary>
        public static readonly string CONNECTION_STRING = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
        public static readonly string QUEUE_NAME = "XXXXXXXXXX";

    }
}