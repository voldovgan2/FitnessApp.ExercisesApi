using FitnessApp.Common.Abstractions.Db.Enums.Collection;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Abstractions.Models.CollectionBlobAggregator;

namespace FitnessApp.ExercisesApi.Models.Input
{
    public class UpdateUserExerciseCollectionBlobAggregatorModel : IUpdateCollectionBlobAggregatorModel
    {
        public string UserId { get; set; }
        public string CollectionName { get; set; }
        public UpdateCollectionAction Action { get; set; }
        public ICollectionBlobAggregatorItemModel<ICollectionItemModel> Model { get; set; }
    }
}
