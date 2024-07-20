using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Abstractions.Models.CollectionFileAggregator;

namespace FitnessApp.ExercisesApi.Models.Output;

public class UserExerciseCollectionFileAggregatorModel : ICollectionFileAggregatorModel
{
    public string UserId { get; set; }
    public Dictionary<string, List<ICollectionFileAggregatorItemModel<ICollectionItemModel>>> Collection { get; set; }
}
