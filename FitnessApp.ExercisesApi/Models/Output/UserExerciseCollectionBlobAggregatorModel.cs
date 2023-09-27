using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Abstractions.Models.CollectionBlobAggregator;

namespace FitnessApp.ExercisesApi.Models.Output
{
    public class UserExerciseCollectionBlobAggregatorModel : ICollectionBlobAggregatorModel
    {
        public string UserId { get; set; }
        public Dictionary<string, List<ICollectionBlobAggregatorItemModel<ICollectionItemModel>>> Collection { get; set; }
    }
}
