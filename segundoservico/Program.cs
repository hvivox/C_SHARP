using primeiroservico.Config;
using segundoservico.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registra a classe de Integração com Azure Service Bus
builder.Services.AddSingleton<IFilaService, FilaService>(sp =>
{
    string connectionString = AppSettings.CONNECTION_STRING;
    string queueName = AppSettings.QUEUE_NAME;
    return new FilaService(connectionString, queueName);
});


//builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
//builder.Services.AddScoped<IFilaService, FilaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
