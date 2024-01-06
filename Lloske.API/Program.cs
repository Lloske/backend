using Lloske.BLL._1._1_Interfaces;
using Lloske.BLL._1._Services;
using Lloske.DAL._1._1_Interfaces;
using Lloske.DAL._1._Repositories;
using Microsoft.Data.SqlClient;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DbConnection
builder.Services.AddTransient<DbConnection>(service =>
{
    string connectionString = builder.Configuration.GetConnectionString("Default");
    return new SqlConnection(connectionString);
});


//Service

builder.Services.AddScoped<IUserPersonnalInformation, UserPersonnalInformationService>();

//Repositories

builder.Services.AddScoped<IUserPersonnalInformationRepository, UserPersonnalInformationRepository>();


// Suite

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
