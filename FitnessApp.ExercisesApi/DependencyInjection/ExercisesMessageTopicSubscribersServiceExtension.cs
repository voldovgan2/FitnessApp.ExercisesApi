using System;
using FitnessApp.Common.ServiceBus.Nats.Services;
using FitnessApp.ExercisesApi.Services.MessageBus;
using FitnessApp.ExercisesApi.Services.UserExerciceAggregator;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.ExercisesApi.DependencyInjection;

public static class ExercisesMessageTopicSubscribersServiceExtension
{
    public static IServiceCollection AddExercisesMessageTopicSubscribersService(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddTransient(sp =>
            {
                return new ExercisesMessageTopicSubscribersService(
                    sp.GetRequiredService<IServiceBus>(),
                    sp.GetRequiredService<IUserExerciseCollectionFileAggregatorService>().CreateUserExercises);
            }
        );

        return services;
    }
}