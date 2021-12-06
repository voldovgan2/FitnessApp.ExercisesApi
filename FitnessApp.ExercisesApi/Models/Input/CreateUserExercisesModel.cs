using FitnessApp.Abstractions.Models.Collection;
using System.Collections.Generic;

namespace FitnessApp.ExercisesApi.Models.Input
{
    public class CreateUserExercisesModel : ICreateCollectionModel
    {
        public string UserId { get; set; }
        public Dictionary<string, IEnumerable<ICollectionItemModel>> Collection { get; set; }
    }
}
