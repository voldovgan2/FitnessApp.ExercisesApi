using System;
using FitnessApp.Common.Serializer.JsonSerializer;
using FitnessApp.ExercisesApi.Services.MessageBus;
using FitnessApp.ExercisesApi.Services.UserExerciceAggregator;
using FitnessApp.ServiceBus.AzureServiceBus.TopicSubscribers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.ExercisesApi.DependencyInjection
{
    public static class ExercisesMessageTopicSubscribersServiceExtension
    {
        public static IServiceCollection AddExercisesMessageTopicSubscribersService(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddTransient<ITopicSubscribers, ExercisesMessageTopicSubscribersService>(
                sp =>
                {
                    var configuration = sp.GetRequiredService<IConfiguration>();
                    var subscription = configuration.GetValue<string>("ServiceBusSubscriptionName");
                    return new ExercisesMessageTopicSubscribersService(
                        sp.GetRequiredService<IUserExerciseCollectionBlobAggregatorService>().CreateUserExercises,
                        subscription,
                        sp.GetRequiredService<IJsonSerializer>()
                    );
                }
            );

            return services;
        }
    }
}