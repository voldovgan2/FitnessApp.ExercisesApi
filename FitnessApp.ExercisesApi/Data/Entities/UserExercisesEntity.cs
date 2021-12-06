using FitnessApp.Abstractions.Db.Entities.Collection;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace FitnessApp.ExercisesApi.Data.Entities
{
    public class UserExercisesEntity : ICollectionEntity
    {
        [BsonId]
        public string UserId { get; set; }
        public Dictionary<string, List<ICollectionItemEntity>> Collection { get; set; }
    }
}
