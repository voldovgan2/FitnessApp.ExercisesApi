using System;
using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Common.Paged.Contracts.Output;
using FitnessApp.ExercisesApi.Contracts.Input;
using FitnessApp.ExercisesApi.Contracts.Output;
using FitnessApp.ExercisesApi.Models.Input;
using FitnessApp.ExercisesApi.Services.UserExerciceAggregator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExercisesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]

[Authorize]
public class ExercisesController(IUserExerciseCollectionFileAggregatorService exercisesService, IMapper mapper) : Controller
{
    [HttpGet("GetExercises")]
    public async Task<UserExercisesContract> GetExercises([FromQuery] GetUserExercisesContract contract)
    {
        var model = mapper.Map<GetUserExercisesFilteredCollectionItemsModel>(contract);
        var response = await exercisesService.GetFilteredUserExercises(model);
        return new UserExercisesContract
        {
            UserId = contract.UserId,
            Exercises = mapper.Map<PagedDataContract<ExerciseItemContract>>(response)
        };
    }

    [HttpPost("CreateExercises")]
    public async Task<string> CreateExercise([FromBody] CreateUserExerciseContract contract)
    {
        var model = mapper.Map<CreateUserExerciseCollectionFileAggregatorModel>(contract);
        var response = await exercisesService.CreateUserExercises(model);
        return response;
    }

    [HttpPut("AddExercise")]
    public async Task<ExerciseItemContract> AddExercise([FromBody] AddUserExerciseContract contract)
    {
        var updateCollectionFileAggregatorUserFoodModel = mapper.Map<UpdateUserExerciseCollectionFileAggregatorModel>(contract);
        var response = await exercisesService.UpdateUserExercises(updateCollectionFileAggregatorUserFoodModel);
        return mapper.Map<ExerciseItemContract>(response);
    }

    [HttpPut("EditExercise")]
    public async Task<ExerciseItemContract> EditExercise([FromBody] UpdateUserExerciseContract contract)
    {
        var updateCollectionFileAggregatorUserFoodModel = mapper.Map<UpdateUserExerciseCollectionFileAggregatorModel>(contract);
        var response = await exercisesService.UpdateUserExercises(updateCollectionFileAggregatorUserFoodModel);
        return mapper.Map<ExerciseItemContract>(response);
    }

    [HttpDelete("RemoveExercise/{userId}/{exerciseId}")]
    public async Task<string> RemoveExercise([FromRoute] string userId, [FromRoute] string exerciseId)
    {
        var updateCollectionFileAggregatorUserFoodModel = mapper.Map<UpdateUserExerciseCollectionFileAggregatorModel>(new Tuple<string, string>(userId, exerciseId));
        var response = await exercisesService.UpdateUserExercises(updateCollectionFileAggregatorUserFoodModel);
        return response.Model.Id;
    }

    [HttpDelete("DeleteExercises/{userId}")]
    public async Task<string> DeleteExercises([FromRoute] string userId)
    {
        var response = await exercisesService.DeleteUserExercise(userId);
        return response;
    }
}