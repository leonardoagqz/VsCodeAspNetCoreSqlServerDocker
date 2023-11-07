using livraria.Models;
using livraria.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*
Outra forma de obter a string de conexão. Mesmo já estando configurado no appsettings.json
Utilizando variaveis de ambiente do container DbServer, DbPort, DbUser, Password, Database
*/
var server = builder.Configuration["DbServer"] ?? "localhost";
var port = builder.Configuration["DbPort"] ?? "1450"; 
var user = builder.Configuration["DbUser"] ?? "SA"; 
var password = builder.Configuration["Password"] ?? "Numsey#2023";
var database = builder.Configuration["Database"] ?? "LivrosDb";

//Posso pegar a strinf de conexão daqui do Program.cs
// var connectionString = $"Server={server}, {port};Initial Catalog={database};User ID={user};Password={password}";

//Como também posso pegar a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Registrando o Contexto como um serviço  e acessando o banco de dados sqlserver
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));
 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//aqui, estamos passando a instancia app, para o método que irá criar a Migration(banco de dados e as tabelas)
DatabaseManagementService.MigrationInitialisation(app);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
