using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using user_task_api.Data;
using user_task_api.Repositorios;
using user_task_api.Repositorios.Interfaces;

// Carregar variáveis de ambiente do arquivo .env
Env.Load();

// Construir a string de conexão a partir das variáveis de ambiente
string server = Environment.GetEnvironmentVariable("MYSQL_SERVER");
string port = Environment.GetEnvironmentVariable("MYSQL_PORT");
string user = Environment.GetEnvironmentVariable("MYSQL_USER");
string password = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
string database = Environment.GetEnvironmentVariable("MYSQL_DATABASE");

string connectionString = $"Server={server};Port={port};User Id={user};Password={password};Database={database}";

// Exibir a string de conexão no console
Console.WriteLine($"Teste variavel de ambiente: {Environment.GetEnvironmentVariable("TESTE_ENV_VAR")}");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Adicionar serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataBaseContext>(options =>
                options.UseMySql(connectionString,
                new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();

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




