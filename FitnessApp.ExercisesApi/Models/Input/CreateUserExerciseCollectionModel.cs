using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Models.Collection;

namespace FitnessApp.ExercisesApi.Models.Input
{
    public class CreateUserExerciseCollectionModel : ICreateCollectionModel
    {
        public string UserId { get; set; }
        public Dictionary<string, IEnumerable<ICollectionItemModel>> Collection { get; set; }
    }
}
