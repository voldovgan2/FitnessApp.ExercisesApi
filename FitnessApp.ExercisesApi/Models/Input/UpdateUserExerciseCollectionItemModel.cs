﻿using System;
using FitnessApp.Common.Abstractions.Models.Collection;

namespace FitnessApp.ExercisesApi.Models.Input;

public class UpdateUserExerciseCollectionItemModel : ICollectionItemModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Photo { get; set; }
    public double Calories { get; set; }
    public DateTime? AddedDate { get; set; }
}
