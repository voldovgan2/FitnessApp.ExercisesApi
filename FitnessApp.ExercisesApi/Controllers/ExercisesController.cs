using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FitnessApp.ExercisesApi.Services.UserExercises;
using FitnessApp.ExercisesApi.Data.Entities;
using FitnessApp.ExercisesApi.Models.Output;
using FitnessApp.ExercisesApi.Models.Input;
using FitnessApp.Serializer.JsonMapper;
using FitnessApp.ExercisesApi.Contracts.Input;
using FitnessApp.ExercisesApi.Contracts.Output;
using FitnessApp.Paged.Contracts.Output;
using FitnessApp.Abstractions.Db.Enums.Collection;

namespace ExercisesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize]
    public class ExercisesController : Controller
    {
        private readonly IExercisesService<UserExercisesEntity, ExerciseItemEntity, UserExercisesModel, ExerciseItemModel, CreateUserExercisesModel, UpdateUserExerciseModel> _exercisesService;
        private readonly IJsonMapper _mapper;

        public ExercisesController
        (
            IExercisesService<UserExercisesEntity, ExerciseItemEntity, UserExercisesModel, ExerciseItemModel, CreateUserExercisesModel, UpdateUserExerciseModel> exercisesService,
            IJsonMapper mapper
        )
        {
            _exercisesService = exercisesService;
            _mapper = mapper;
        }

        [HttpGet("GetExercises")]
        public async Task<IActionResult> GetExercisesAsync([FromQuery] GetUserExercisesContract contract)
        {
            var model = _mapper.Convert<GetUserExercisesModel>(contract);
            model.CollectionName = _exercisesService.DefaultCollectionName;
            var data = await _exercisesService.GetFilteredCollectionItemsAsync(model);
            if (data != null)
            {
                var result = new UserExercisesContract
                {
                    UserId = contract.UserId,
                    Exercises = _mapper.Convert<PagedDataContract<ExerciseItemContract>>(data)
                };
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
                
        [HttpPost("CreateExercises")]
        public async Task<IActionResult> CreateExerciseAsync([FromBody] CreateUserExercisesContract contract)
        {
            var model = _mapper.Convert<CreateUserExercisesModel>(contract);
            var created = await _exercisesService.CreateItemAsync(model);
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
        public async Task<IActionResult> AddExerciseAsync([FromBody] AddUserExerciseContract contract)
        {
            var model = _mapper.Convert<UpdateUserExerciseModel>(contract);
            model.CollectionName = _exercisesService.DefaultCollectionName;
            model.Action = UpdateCollectionAction.Add;
            var updateFoodItemModel = _mapper.Convert<UpdateExerciseItemModel>(contract);
            updateFoodItemModel.AddedDate = DateTime.UtcNow;
            model.Model = updateFoodItemModel;
            var updated = await _exercisesService.UpdateItemAsync(model);
            if (updated != null)
            {
                var result = _mapper.Convert<ExerciseItemContract>(updated);
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("EditExercise")]
        public async Task<IActionResult> EditExerciseAsync([FromBody] UpdateUserExerciseContract contract)
        {
            var model = _mapper.Convert<UpdateUserExerciseModel>(contract);
            model.CollectionName = _exercisesService.DefaultCollectionName;
            model.Action = UpdateCollectionAction.Update;
            model.Model = _mapper.Convert<UpdateExerciseItemModel>(contract);
            var updated = await _exercisesService.UpdateItemAsync(model);
            if (updated != null)
            {
                var result = _mapper.Convert<ExerciseItemContract>(updated);
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("RemoveExercise/{userId}/{exerciseId}")]
        public async Task<IActionResult> RemoveExerciseAsync([FromRoute] string userId, [FromRoute] string exerciseId)
        {
            var model = new UpdateUserExerciseModel
            {
                UserId = userId,
                Action = UpdateCollectionAction.Remove,
                CollectionName = _exercisesService.DefaultCollectionName,
                Model = new UpdateExerciseItemModel
                {
                    Id = exerciseId
                }
            };
            var updated = await _exercisesService.UpdateItemAsync(model);
            if (updated != null)
            {
                var result = updated.Id;
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("DeleteExercises/{userId}")]
        public async Task<IActionResult> DeleteExercisesAsync([FromRoute] string userId)
        {
            var deleted = await _exercisesService.DeleteItemAsync(userId);
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