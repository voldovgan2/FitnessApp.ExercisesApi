using System;
using System.Threading.Tasks;
using FitnessApp.Common.Serializer.JsonSerializer;
using FitnessApp.Common.ServiceBus;
using FitnessApp.ExercisesApi.Models.Input;

namespace FitnessApp.ExercisesApi.Services.MessageBus
{
    public class ExercisesMessageTopicSubscribersService : CollectionBlobAggregatorServiceNewUserRegisteredSubscriberService<CreateUserExerciseCollectionBlobAggregatorModel>
    {
        public ExercisesMessageTopicSubscribersService(
            Func<CreateUserExerciseCollectionBlobAggregatorModel, Task<string>> createItemMethod,
            string subscription,
            IJsonSerializer serializer)
            : base(createItemMethod, subscription, serializer)
        { }
    }
}