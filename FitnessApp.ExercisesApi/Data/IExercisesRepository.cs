using FitnessApp.Abstractions.Db.Entities.Collection;
using FitnessApp.Abstractions.Db.Repository.Collection;
using FitnessApp.Abstractions.Models.Collection;

namespace FitnessApp.ExercisesApi.Data
{
    public interface IExercisesRepository<Entity, CollectionItemEntity, Model, CollectionItemModel, CreateModel, UpdateModel>
        : ICollectionRepository<Entity, CollectionItemEntity, Model, CollectionItemModel, CreateModel, UpdateModel>
        where Entity : ICollectionEntity
        where CollectionItemEntity : ICollectionItemEntity
        where Model : ICollectionModel
        where CollectionItemModel : ISearchableCollectionItemModel
        where CreateModel : ICreateCollectionModel
        where UpdateModel : IUpdateCollectionModel
    {
    }
}
