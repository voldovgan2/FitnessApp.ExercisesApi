using FitnessApp.Common.Abstractions.Services.Collection;
using FitnessApp.ExercisesApi.Models.Input;
using FitnessApp.ExercisesApi.Models.Output;

namespace FitnessApp.ExercisesApi.Services.UserExercisesCollection;

public interface IUserExerciseCollectionService :
    ICollectionService<
        UserExerciseCollectionModel,
        UserExerciseCollectionItemModel,
        CreateUserExerciseCollectionModel,
        UpdateUserExerciseCollectionModel>;
