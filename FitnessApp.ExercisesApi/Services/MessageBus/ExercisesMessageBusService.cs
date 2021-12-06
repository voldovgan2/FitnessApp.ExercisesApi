using FitnessApp.ExercisesApi.Data.Entities;
using FitnessApp.ExercisesApi.Models.Input;
using FitnessApp.ExercisesApi.Models.Output;
using FitnessApp.ExercisesApi.Services.UserExercises;
using FitnessApp.IntegrationEvents;
using FitnessApp.NatsServiceBus;
using FitnessApp.Serializer.JsonSerializer;

namespace FitnessApp.ExercisesApi.Services.MessageBus
{
    public class ExercisesMessageBusService : MessageBusService
    {
        private readonly IExercisesService<UserExercisesEntity, ExerciseItemEntity, UserExercisesModel, ExerciseItemModel, CreateUserExercisesModel, UpdateUserExerciseModel> _service;

        public ExercisesMessageBusService
        (
            IServiceBus serviceBus,
            IExercisesService<UserExercisesEntity, ExerciseItemEntity, UserExercisesModel, ExerciseItemModel, CreateUserExercisesModel, UpdateUserExerciseModel> service,
            IJsonSerializer serializer
        )
            : base(serviceBus, serializer)
        {
            _service = service;
        }

        protected override void HandleNewUserRegisteredEvent(NewUserRegisteredEvent integrationEvent)
        {
            _service.CreateItemAsync(new CreateUserExercisesModel { UserId = integrationEvent.UserId });
        }
    }
}