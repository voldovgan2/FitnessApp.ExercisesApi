using FitnessApp.Abstractions.Models.Collection;
using System.Collections.Generic;

namespace FitnessApp.ExercisesApi.Models.Output
{
    public class UserExercisesModel : ICollectionModel
    {
        public string UserId { get; set; }
        public Dictionary<string, IEnumerable<ICollectionItemModel>> Collection { get; set; }
    }
}
