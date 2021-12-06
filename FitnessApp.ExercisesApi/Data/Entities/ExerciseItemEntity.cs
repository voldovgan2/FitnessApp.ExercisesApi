using FitnessApp.Abstractions.Db.Entities.Collection;
using System;

namespace FitnessApp.ExercisesApi.Data.Entities
{
    public class ExerciseItemEntity : ICollectionItemEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public double Calories { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    }
}