using System.Threading.Tasks;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Paged.Models.Output;
using FitnessApp.ExercisesApi.Models.Input;
using FitnessApp.ExercisesApi.Models.Output;

namespace FitnessApp.ExercisesApi.Services.UserExerciceAggregator;

public interface IUserExerciseCollectionFileAggregatorService
{
    Task<PagedDataModel<UserExerciseCollectionFileAggregatorItemModel>> GetFilteredUserExercises(GetFilteredCollectionItemsModel<UserExerciseCollectionItemModel> model);
    Task<string> CreateUserExercises(CreateUserExerciseCollectionFileAggregatorModel model);
    Task<UserExerciseCollectionFileAggregatorItemModel> UpdateUserExercises(UpdateUserExerciseCollectionFileAggregatorModel model);
    Task<string> DeleteUserExercise(string userId);
}
