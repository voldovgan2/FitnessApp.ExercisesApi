using FitnessApp.Common.Paged.Contracts.Input;

namespace FitnessApp.ExercisesApi.Contracts.Input;

public class GetUserExercisesContract : GetPagedSearchDataContract
{
    public string UserId { get; set; }
}
