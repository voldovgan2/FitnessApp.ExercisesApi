using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Models.Collection;

namespace FitnessApp.ExercisesApi.Models.Output;

public class UserExerciseCollectionModel : ICollectionModel
{
    public string UserId { get; set; }
    public Dictionary<string, List<ICollectionItemModel>> Collection { get; set; }
}
