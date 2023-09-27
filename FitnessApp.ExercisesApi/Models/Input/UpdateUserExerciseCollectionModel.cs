using FitnessApp.Common.Abstractions.Db.Enums.Collection;
using FitnessApp.Common.Abstractions.Models.Collection;

namespace FitnessApp.ExercisesApi.Models.Input
{
    public class UpdateUserExerciseCollectionModel : IUpdateCollectionModel
    {
        public string UserId { get; set; }
        public string CollectionName { get; set; }
        public UpdateCollectionAction Action { get; set; }
        public ICollectionItemModel Model { get; set; }
    }
}