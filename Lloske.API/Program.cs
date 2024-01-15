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
    string connectionString = builder.Configuration.GetConnectionString("Technobel");
    return new SqlConnection(connectionString);
});


//Service

builder.Services.AddScoped<Lloske.BLL._1._1_Interfaces.IUserContractInformation, UserContractInformationService>();
builder.Services.AddScoped<Lloske.BLL._1._1_Interfaces.IUserHumanRessourcesInformation, UserHumanRessourcesInformationService>();
builder.Services.AddScoped<Lloske.BLL._1._1_Interfaces.IUserPayrollData, UserPayrollDataService>();
builder.Services.AddScoped<Lloske.BLL._1._1_Interfaces.IUserPersonnalInformation, UserPersonnalInformationService>();

//Repositories

builder.Services.AddScoped<Lloske.DAL._1._1_Interfaces.IUserContractInformationRepository, UserContractInformationRepository>();
builder.Services.AddScoped<Lloske.DAL._1._1_Interfaces.IUserHumanRessourcesInformationRepository, UserHumanRessourcesInformationRepository>();
builder.Services.AddScoped<Lloske.DAL._1._1_Interfaces.IUserPayrollDataRepository, UserPayrollDataRepository>();
builder.Services.AddScoped<Lloske.DAL._1._1_Interfaces.IUserPersonnalInformationRepository, UserPersonnalInformationRepository>();


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
