using FitnessApp.Common.Abstractions.Services.Collection;
using FitnessApp.Common.Abstractions.Services.Search;
using FitnessApp.ExercisesApi.Data;
using FitnessApp.ExercisesApi.Models.Input;
using FitnessApp.ExercisesApi.Models.Output;

namespace FitnessApp.ExercisesApi.Services.UserExercisesCollection
{
    public class UserExerciseCollectionService
        : CollectionService<UserExerciseCollectionModel, UserExerciseCollectionItemModel, CreateUserExerciseCollectionModel, UpdateUserExerciseCollectionModel>,
        IUserExerciseCollectionService
    {
        public UserExerciseCollectionService(IExercisesRepository repository, ISearchService searchService)
            : base(repository, searchService)
        { }
    }
}