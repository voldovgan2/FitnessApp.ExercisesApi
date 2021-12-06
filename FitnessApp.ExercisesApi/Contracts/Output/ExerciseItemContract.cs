﻿using System;

namespace FitnessApp.ExercisesApi.Contracts.Output
{
    public class ExerciseItemContract
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public double Calories { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
