
// CLASSE E INICIALIZAÇÃO DOS SERVIÇOS
using primeiroservico.Config;
using primeiroservico.Filter;
using primeiroservico.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// registra o filtro de exceção
builder.Services.AddControllers(
    options =>
           {
               options.Filters.Add<TokenAuthorizationFilter>();
               options.Filters.Add<JsonExceptionFilter>();
           }
);

//Registra a classe de Integração com Azure Service Bus
builder.Services.AddSingleton<ServiceBusIntegrationRepository>(sp =>
{
    string connectionString = AppSettings.CONNECTION_STRING;
    string queueName = AppSettings.QUEUE_NAME;
    return new ServiceBusIntegrationRepository(connectionString, queueName);
});

//builder.Services.AddScoped<ServiceBusIntegration>();

// Regitra a classe de customização do swagger para entrada de dados no cabeçalho da requisição
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "PrimeiroServiço", Version = "v1.0" });
    // Configurar o Swagger para incluir o cabeçalho de autorização
    options.OperationFilter<HeaderParameterOperationFilter>();
});


// injeção de dependencia do UsuarioRepository
builder.Services.AddScoped<IUsuarioCosmosRepository, UsuarioCosmosRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseRouting(); // Adicione esta linha

app.UseAuthorization();

app.MapControllers();

app.Run();
