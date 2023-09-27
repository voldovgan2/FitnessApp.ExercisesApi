using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Abstractions.Models.CollectionBlobAggregator;

namespace FitnessApp.ExercisesApi.Models.Input
{
    public class CreateUserExerciseCollectionBlobAggregatorModel : ICreateCollectionBlobAggregatorModel
    {
        public string UserId { get; set; }
        public Dictionary<string, IEnumerable<ICollectionItemModel>> Collection { get; set; }
    }
}
