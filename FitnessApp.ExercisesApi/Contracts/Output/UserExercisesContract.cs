using FitnessApp.Common.Paged.Contracts.Output;

namespace FitnessApp.ExercisesApi.Contracts.Output;

public class UserExercisesContract
{
    public string UserId { get; set; }
    public PagedDataContract<ExerciseItemContract> Exercises { get; set; }
}