using FitnessApp.Abstractions.Db.Entities.Collection;
using FitnessApp.Abstractions.Models.Collection;
using FitnessApp.Abstractions.Services.Collection;
using FitnessApp.ExercisesApi.Data;
using FitnessApp.Serializer.JsonMapper;
using Microsoft.Extensions.Logging;

namespace FitnessApp.ExercisesApi.Services.UserExercises
{
    public class ExercisesService<Entity, CollectionItemEntity, Model, CollectionItemModel, CreateModel, UpdateModel> :
        CollectionService<Entity, CollectionItemEntity, Model, CollectionItemModel, CreateModel, UpdateModel>,
        IExercisesService<Entity, CollectionItemEntity, Model, CollectionItemModel, CreateModel, UpdateModel>
        where Entity : ICollectionEntity
        where CollectionItemEntity : ICollectionItemEntity
        where Model : ICollectionModel
        where CollectionItemModel : ISearchableCollectionItemModel
        where CreateModel : ICreateCollectionModel
        where UpdateModel : IUpdateCollectionModel
    {
        public ExercisesService
        (
            IExercisesRepository<Entity, CollectionItemEntity, Model, CollectionItemModel, CreateModel, UpdateModel> repository,
            IJsonMapper mapper,
            ILogger<CollectionService<Entity, CollectionItemEntity, Model, CollectionItemModel, CreateModel, UpdateModel>> log
        )
           : base(repository, mapper, log)
        {
            DefaultCollectionName = "Exercises";
        }
    }
}
