using FitnessApp.Common.Abstractions.Services.Collection;
using FitnessApp.ExercisesApi.Data;
using FitnessApp.ExercisesApi.Models.Input;
using FitnessApp.ExercisesApi.Models.Output;

namespace FitnessApp.ExercisesApi.Services.UserExercisesCollection;

public class UserExerciseCollectionService(IExercisesRepository repository) :
    CollectionService<
        UserExerciseCollectionModel,
        UserExerciseCollectionItemModel,
        CreateUserExerciseCollectionModel,
        UpdateUserExerciseCollectionModel>(repository),
    IUserExerciseCollectionService;