using System;
using AutoMapper;
using FitnessApp.Common.Abstractions.Db.DbContext;
using FitnessApp.ExercisesApi.Data;
using FitnessApp.ExercisesApi.Data.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.ExercisesApi.DependencyInjection;

public static class ExercisesRepositoryExtension
{
    public static IServiceCollection ConfigureExercisesRepository(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddTransient<IDbContext<UserExerciseCollectionEntity>, DbContext<UserExerciseCollectionEntity>>();
        services.AddTransient<IExercisesRepository, ExercisesRepository>(sp =>
            {
                return new ExercisesRepository(sp.GetRequiredService<IDbContext<UserExerciseCollectionEntity>>(), sp.GetRequiredService<IMapper>());
            }
        );

        return services;
    }
}