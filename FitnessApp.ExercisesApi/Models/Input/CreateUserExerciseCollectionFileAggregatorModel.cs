﻿using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Abstractions.Models.CollectionFileAggregator;

namespace FitnessApp.ExercisesApi.Models.Input;

public class CreateUserExerciseCollectionFileAggregatorModel : ICreateCollectionFileAggregatorModel
{
    public string UserId { get; set; }
    public Dictionary<string, IEnumerable<ICollectionItemModel>> Collection { get; set; }
}
