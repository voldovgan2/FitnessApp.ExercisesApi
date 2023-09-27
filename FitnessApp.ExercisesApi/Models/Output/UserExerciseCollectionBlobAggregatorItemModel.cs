using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Models.BlobImage;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Abstractions.Models.CollectionBlobAggregator;

namespace FitnessApp.ExercisesApi.Models.Output
{
    public class UserExerciseCollectionBlobAggregatorItemModel : ICollectionBlobAggregatorItemModel<ICollectionItemModel>
    {
        public ICollectionItemModel Model { get; set; }
        public List<BlobImageModel> Images { get; set; }
    }
}
