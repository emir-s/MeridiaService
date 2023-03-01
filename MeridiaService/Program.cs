﻿using System.Diagnostics;
using Meridia.Persistence.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var appSettings = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .Build();

// Add services to the container.
Meridia.Application.DependencyResolver.DependencyResolverService.Register(builder.Services);
Meridia.Infrastructure.DependencyResolver.DependencyResolverService.Register(builder.Services);
Meridia.Persistence.DependencyResolver.DependencyResolverService.Register(builder.Services, appSettings);


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
using (var scope = app.Services.CreateScope())
{
    Meridia.Persistence.DependencyResolver.DependencyResolverService.MigrateDatabase(scope.ServiceProvider);
}

app.Run();

