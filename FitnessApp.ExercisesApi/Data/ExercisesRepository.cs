using AutoMapper;
using FitnessApp.Common.Abstractions.Db.DbContext;
using FitnessApp.Common.Abstractions.Db.Repository.Collection;
using FitnessApp.ExercisesApi.Data.Entities;
using FitnessApp.ExercisesApi.Models.Input;
using FitnessApp.ExercisesApi.Models.Output;

namespace FitnessApp.ExercisesApi.Data
{
    public class ExercisesRepository
        : CollectionRepository<UserExerciseCollectionEntity, ExerciseCollectionItemEntity, UserExerciseCollectionModel, UserExerciseCollectionItemModel, CreateUserExerciseCollectionModel, UpdateUserExerciseCollectionModel>,
        IExercisesRepository
    {
        public ExercisesRepository(
            IDbContext<UserExerciseCollectionEntity> context,
            IMapper mapper)
            : base(context, mapper)
        { }
    }
}
