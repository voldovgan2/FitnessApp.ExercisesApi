using FitnessApp.Common.Abstractions.Db.Repository.Collection;
using FitnessApp.ExercisesApi.Models.Input;
using FitnessApp.ExercisesApi.Models.Output;

namespace FitnessApp.ExercisesApi.Data
{
    public interface IExercisesRepository
        : ICollectionRepository<
            UserExerciseCollectionModel,
            UserExerciseCollectionItemModel,
            CreateUserExerciseCollectionModel,
            UpdateUserExerciseCollectionModel>;
}
