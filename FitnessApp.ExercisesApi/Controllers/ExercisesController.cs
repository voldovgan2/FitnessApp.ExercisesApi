using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Common.Paged.Contracts.Output;
using FitnessApp.ExercisesApi.Contracts.Input;
using FitnessApp.ExercisesApi.Contracts.Output;
using FitnessApp.ExercisesApi.Models.Input;
using FitnessApp.ExercisesApi.Services.UserExerciceAggregator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExercisesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]

    // [Authorize]
    public class ExercisesController : Controller
    {
        private readonly IUserExerciseCollectionBlobAggregatorService _exercisesService;
        private readonly IMapper _mapper;

        public ExercisesController(
            IUserExerciseCollectionBlobAggregatorService exercisesService,
            IMapper mapper
        )
        {
            _exercisesService = exercisesService;
            _mapper = mapper;
        }

        [HttpGet("GetExercises")]
        public async Task<IActionResult> GetExercises([FromQuery] GetUserExercisesContract contract)
        {
            var model = _mapper.Map<GetUserExercisesFilteredCollectionItemsModel>(contract);
            var data = await _exercisesService.GetFilteredUserExercises(model);
            if (data != null)
            {
                var result = new UserExercisesContract
                {
                    UserId = contract.UserId,
                    Exercises = _mapper.Map<PagedDataContract<ExerciseItemContract>>(data)
                };
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("CreateExercises")]
        public async Task<IActionResult> CreateExercise([FromBody] CreateUserExerciseContract contract)
        {
            var model = _mapper.Map<CreateUserExerciseCollectionBlobAggregatorModel>(contract);
            var created = await _exercisesService.CreateUserExercises(model);
            if (created != null)
            {
                var result = created;
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("AddExercise")]
        public async Task<IActionResult> AddExercise([FromBody] AddUserExerciseContract contract)
        {
            var updateCollectionBlobAggregatorUserFoodModel = _mapper.Map<UpdateUserExerciseCollectionBlobAggregatorModel>(contract);
            var updated = await _exercisesService.UpdateUserExercises(updateCollectionBlobAggregatorUserFoodModel);
            if (updated != null)
            {
                var result = _mapper.Map<ExerciseItemContract>(updated);
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("EditExercise")]
        public async Task<IActionResult> EditExercise([FromBody] UpdateUserExerciseContract contract)
        {
            var updateCollectionBlobAggregatorUserFoodModel = _mapper.Map<UpdateUserExerciseCollectionBlobAggregatorModel>(contract);
            var updated = await _exercisesService.UpdateUserExercises(updateCollectionBlobAggregatorUserFoodModel);
            if (updated != null)
            {
                var result = _mapper.Map<ExerciseItemContract>(updated);
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("RemoveExercise/{userId}/{exerciseId}")]
        public async Task<IActionResult> RemoveExercise([FromRoute] string userId, [FromRoute] string exerciseId)
        {
            var updateCollectionBlobAggregatorUserFoodModel = _mapper.Map<UpdateUserExerciseCollectionBlobAggregatorModel>(new Tuple<string, string>(userId, exerciseId));
            var updated = await _exercisesService.UpdateUserExercises(updateCollectionBlobAggregatorUserFoodModel);
            if (updated != null)
            {
                var result = updated.Model.Id;
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("DeleteExercises/{userId}")]
        public async Task<IActionResult> DeleteExercises([FromRoute] string userId)
        {
            var deleted = await _exercisesService.DeleteUserExercise(userId);
            if (deleted != null)
            {
                return Ok(deleted);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}