using System.Reflection;
using FitnessApp.Common.Configuration;
using FitnessApp.ExercisesApi;
using FitnessApp.ExercisesApi.Contracts.Output;
using FitnessApp.ExercisesApi.DependencyInjection;
using FitnessApp.ExercisesApi.Models.Output;
using FitnessApp.ExercisesApi.Services.MessageBus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureMapper(new MappingProfile<ExerciseItemContract, UserExerciseCollectionFileAggregatorItemModel>());
builder.Services.ConfigureMongo(builder.Configuration);
builder.Services.ConfigureVault(builder.Configuration);
builder.Services.ConfigureExercisesRepository();
builder.Services.ConfigureFilesService(builder.Configuration);
builder.Services.ConfigureNats(builder.Configuration);
builder.Services.AddExercisesMessageTopicSubscribersService();
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureSwagger(Assembly.GetExecutingAssembly().GetName().Name);
builder.Services.ConfigureCollectionServices(builder.Configuration);
if ("false".Contains("true"))
    builder.Services.AddHostedService<ExercisesMessageTopicSubscribersService>();

builder.Services.AddHealthChecks();
builder.Host.ConfigureAppConfiguration();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerAndUi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");
app.Run();
public partial class Program { }
