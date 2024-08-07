﻿using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Abstractions.Models.CollectionFileAggregator;
using FitnessApp.Common.Abstractions.Models.FileImage;

namespace FitnessApp.ExercisesApi.Models.Output;

public class UserExerciseCollectionFileAggregatorItemModel : ICollectionFileAggregatorItemModel<ICollectionItemModel>
{
    public ICollectionItemModel Model { get; set; }
    public List<FileImageModel> Images { get; set; }
}
