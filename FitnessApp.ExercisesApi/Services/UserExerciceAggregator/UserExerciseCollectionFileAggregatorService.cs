using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Abstractions.Services.CollectionFileAggregator;
using FitnessApp.Common.Abstractions.Services.Configuration;
using FitnessApp.Common.Files;
using FitnessApp.Common.Paged.Models.Output;
using FitnessApp.ExercisesApi.Models.Input;
using FitnessApp.ExercisesApi.Models.Output;
using FitnessApp.ExercisesApi.Services.UserExercisesCollection;
using Microsoft.Extensions.Options;

namespace FitnessApp.ExercisesApi.Services.UserExerciceAggregator
{
    public class UserExerciseCollectionFileAggregatorService(
        IUserExerciseCollectionService collectionService,
        IFilesService filesService,
        IMapper mapper,
        IOptions<CollectionFileAggregatorSettings> fileAggregatorSettings)
        : CollectionFileAggregatorService<
            UserExerciseCollectionFileAggregatorModel,
            UserExerciseCollectionFileAggregatorItemModel,
            UserExerciseCollectionModel,
            UserExerciseCollectionItemModel,
            CreateUserExerciseCollectionFileAggregatorModel,
            CreateUserExerciseCollectionModel,
            UpdateUserExerciseCollectionFileAggregatorModel,
            UpdateUserExerciseCollectionModel>
        (collectionService, filesService, mapper, fileAggregatorSettings.Value),
        IUserExerciseCollectionFileAggregatorService
    {
        public Task<PagedDataModel<UserExerciseCollectionFileAggregatorItemModel>> GetFilteredUserExercises(GetFilteredCollectionItemsModel<UserExerciseCollectionItemModel> model)
        {
            return GetFilteredCollectionItems(model);
        }

        public Task<string> CreateUserExercises(CreateUserExerciseCollectionFileAggregatorModel model)
        {
            return CreateItem(model);
        }

        public Task<UserExerciseCollectionFileAggregatorItemModel> UpdateUserExercises(UpdateUserExerciseCollectionFileAggregatorModel model)
        {
            return UpdateItem(model);
        }

        public Task<string> DeleteUserExercise(string userId)
        {
            return DeleteItem(userId);
        }
    }
}