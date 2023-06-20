using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using primeiroservico.Config;
using primeiroservico.Model;


namespace primeiroservico.Repository
{
    public class UsuarioCosmosRepository : IUsuarioCosmosRepository
    {
        // informações de conexão com o banco
        private static readonly string EndpointUri = AppSettings.ENDPOINT_URI;
        private static readonly string PrimaryKey = AppSettings.PRIMARY_KEY;
        private readonly string databaseName = AppSettings.DATABASE_NAME;
        private readonly string containerName = AppSettings.CONTAINER_NAME;

        // classes de conexão
        private readonly CosmosClient cosmosClient;
        private readonly Database database;
        private readonly Container _container;



        public UsuarioCosmosRepository()
        {
            cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);
            database = cosmosClient.GetDatabase(databaseName);
            _container = database.GetContainer(containerName);

        }


        // ENVIA AS INFORMAÇÕES PARA SEREM GRAVADAS NO AZURE COSMOS BD
        public async Task SalvarUsuarioAsync([FromHeader] Usuario usuario)
        {
            await _container.CreateItemAsync(usuario);
        }


    }



}


