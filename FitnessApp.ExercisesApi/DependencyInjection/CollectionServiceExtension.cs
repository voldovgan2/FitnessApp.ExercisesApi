using System;
using FitnessApp.Common.Abstractions.Services.Configuration;
using FitnessApp.ExercisesApi.Services.UserExerciceAggregator;
using FitnessApp.ExercisesApi.Services.UserExercisesCollection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.ExercisesApi.DependencyInjection;

public static class CollectionServiceExtension
{
    public static IServiceCollection ConfigureCollectionServices(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.Configure<CollectionFileAggregatorSettings>(configuration.GetSection("CollectionFileAggregatorSettings"));
        services.AddTransient<IUserExerciseCollectionService, UserExerciseCollectionService>();
        services.AddTransient<IUserExerciseCollectionFileAggregatorService, UserExerciseCollectionFileAggregatorService>();

        return services;
    }
}
