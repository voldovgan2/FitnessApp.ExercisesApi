using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Abstractions.Services.CollectionBlobAggregator;
using FitnessApp.Common.Abstractions.Services.Configuration;
using FitnessApp.Common.Blob;
using FitnessApp.Common.Paged.Models.Output;
using FitnessApp.ExercisesApi.Models.Input;
using FitnessApp.ExercisesApi.Models.Output;
using FitnessApp.ExercisesApi.Services.UserExercisesCollection;
using Microsoft.Extensions.Options;

namespace FitnessApp.ExercisesApi.Services.UserExerciceAggregator
{
    public class UserExerciseCollectionBlobAggregatorService : CollectionBlobAggregatorService<UserExerciseCollectionBlobAggregatorModel, UserExerciseCollectionBlobAggregatorItemModel, UserExerciseCollectionModel, UserExerciseCollectionItemModel, CreateUserExerciseCollectionBlobAggregatorModel, CreateUserExerciseCollectionModel, UpdateUserExerciseCollectionBlobAggregatorModel, UpdateUserExerciseCollectionModel>,
        IUserExerciseCollectionBlobAggregatorService
    {
        public UserExerciseCollectionBlobAggregatorService(
            IUserExerciseCollectionService collectionService,
            IBlobService blobService,
            IMapper mapper,
            IOptions<CollectionBlobAggregatorSettings> blobAggregatorSettings)
           : base(collectionService, blobService, mapper, blobAggregatorSettings.Value)
        { }

        public Task<PagedDataModel<UserExerciseCollectionBlobAggregatorItemModel>> GetFilteredUserExercises(GetFilteredCollectionItemsModel<UserExerciseCollectionItemModel> model)
        {
            return GetFilteredCollectionItems(model);
        }

        public Task<string> CreateUserExercises(CreateUserExerciseCollectionBlobAggregatorModel model)
        {
            return CreateItem(model);
        }

        public Task<UserExerciseCollectionBlobAggregatorItemModel> UpdateUserExercises(UpdateUserExerciseCollectionBlobAggregatorModel model)
        {
            return UpdateItem(model);
        }

        public Task<string> DeleteUserExercise(string userId)
        {
            return DeleteItem(userId);
        }
    }
}