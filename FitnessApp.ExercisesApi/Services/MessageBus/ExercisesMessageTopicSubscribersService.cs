using System;
using System.Threading.Tasks;
using FitnessApp.Common.ServiceBus;
using FitnessApp.Common.ServiceBus.Nats.Services;
using FitnessApp.ExercisesApi.Models.Input;

namespace FitnessApp.ExercisesApi.Services.MessageBus
{
    public class ExercisesMessageTopicSubscribersService(
        IServiceBus serviceBus,
        Func<CreateUserExerciseCollectionFileAggregatorModel, Task<string>> createItemMethod)
        : CollectionFileAggregatorServiceNewUserRegisteredSubscriberService<CreateUserExerciseCollectionFileAggregatorModel>(serviceBus, createItemMethod);
}