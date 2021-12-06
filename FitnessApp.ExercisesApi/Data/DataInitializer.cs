using FitnessApp.ExercisesApi.Data.Entities;
using FitnessApp.ExercisesApi.Models.Input;
using FitnessApp.ExercisesApi.Models.Output;
using FitnessApp.ExercisesApi.Services.UserExercises;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ExercisesApi.Data
{
    public class DataInitializer
    {
        public static async Task EnsureExercisesCreatedAsync(IServiceProvider serviceProvider, bool create = false, bool delete = false)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var service = services.GetRequiredService<IExercisesService<UserExercisesEntity, ExerciseItemEntity, UserExercisesModel, ExerciseItemModel, CreateUserExercisesModel, UpdateUserExerciseModel>>();
                for (int k = 0; k < 200; k++)
                {
                    var userEmail = $"user{k}@hotmail.com";
                    var userId = $"ApplicationUser_{userEmail}";
                    if (delete)
                    {
                        await service.DeleteItemAsync(userId);
                    }
                    if (create)
                    {
                        await service.CreateItemAsync(new CreateUserExercisesModel { UserId = userId });
                    }
                }
                var adminEmail = "admin@hotmail.com";
                var adminId = $"ApplicationUser_{adminEmail}";
                if (delete)
                {
                    await service.DeleteItemAsync(adminId);
                }
                if (create)
                {
                    await service.CreateItemAsync(new CreateUserExercisesModel { UserId = adminId });
                }
            }
        }
    }
}
