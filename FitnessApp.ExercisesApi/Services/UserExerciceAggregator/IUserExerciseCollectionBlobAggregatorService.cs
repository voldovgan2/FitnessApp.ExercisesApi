using System.Threading.Tasks;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Paged.Models.Output;
using FitnessApp.ExercisesApi.Models.Input;
using FitnessApp.ExercisesApi.Models.Output;

namespace FitnessApp.ExercisesApi.Services.UserExerciceAggregator
{
    public interface IUserExerciseCollectionBlobAggregatorService
    {
        Task<PagedDataModel<UserExerciseCollectionBlobAggregatorItemModel>> GetFilteredUserExercises(GetFilteredCollectionItemsModel<UserExerciseCollectionItemModel> model);
        Task<string> CreateUserExercises(CreateUserExerciseCollectionBlobAggregatorModel model);
        Task<UserExerciseCollectionBlobAggregatorItemModel> UpdateUserExercises(UpdateUserExerciseCollectionBlobAggregatorModel model);
        Task<string> DeleteUserExercise(string userId);
    }
}
