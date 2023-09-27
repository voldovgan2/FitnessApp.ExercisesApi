using System;
using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Db.Enums.Collection;
using FitnessApp.Common.Abstractions.Models.BlobImage;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Mapping;
using FitnessApp.ExercisesApi.Contracts.Input;
using FitnessApp.ExercisesApi.Contracts.Output;
using FitnessApp.ExercisesApi.Data.Entities;
using FitnessApp.ExercisesApi.Models.Input;
using FitnessApp.ExercisesApi.Models.Output;

namespace FitnessApp.ExercisesApi
{
    public class MappingProfile<TContract, TModel> : PagedMappingProfile<TContract, TModel>
        where TContract : class
        where TModel : class
    {
        public MappingProfile()
        {
            #region Contract 2 GenericBlobAggregatorModel
            CreateMap<GetUserExercisesContract, GetUserExercisesFilteredCollectionItemsModel>()
                .ForMember(m => m.CollectionName, c => c.MapFrom(c => _defaultCollectionName))
                .AfterMap((c, m) =>
                {
                    m.Predicate = new Func<UserExerciseCollectionItemModel, bool>(item =>
                    {
                        return string.IsNullOrWhiteSpace(c.Search)
                            || item.Name.Contains(c.Search)
                            || item.Description.Contains(c.Search);
                    });
                });
            CreateMap<CreateUserExerciseContract, CreateUserExerciseCollectionBlobAggregatorModel>()
                .ForMember(m => m.Collection, c => c.MapFrom(c => new Dictionary<string, IEnumerable<CreateUserExerciseCollectionBlobAggregatorModel>>
                {
                    { _defaultCollectionName, new List<CreateUserExerciseCollectionBlobAggregatorModel>() }
                }));
            CreateMap<AddUserExerciseContract, UpdateUserExerciseCollectionBlobAggregatorModel>()
                .ForMember(m => m.Action, c => c.MapFrom(c => UpdateCollectionAction.Add))
                .ForMember(m => m.CollectionName, c => c.MapFrom(c => _defaultCollectionName))
                .ForMember(m => m.Model, c => c.MapFrom(c => ConstructUserExerciseCollectionBlobAggregatorItemModel(Guid.Empty.ToString(), c.Name, c.Calories, c.Description, c.Photo)));
            CreateMap<UpdateUserExerciseContract, UpdateUserExerciseCollectionBlobAggregatorModel>()
                .ForMember(m => m.Action, c => c.MapFrom(c => UpdateCollectionAction.Update))
                .ForMember(m => m.CollectionName, c => c.MapFrom(c => _defaultCollectionName))
                .ForMember(m => m.Model, c => c.MapFrom(c => ConstructUserExerciseCollectionBlobAggregatorItemModel(c.Id, c.Name, c.Calories, c.Description, c.Photo)));
            CreateMap<Tuple<string, string>, UpdateUserExerciseCollectionBlobAggregatorModel>()
                .ForMember(m => m.Action, c => c.MapFrom(c => UpdateCollectionAction.Remove))
                .ForMember(m => m.CollectionName, c => c.MapFrom(c => _defaultCollectionName))
                .ForMember(m => m.UserId, c => c.MapFrom(c => c.Item1))
                .ForMember(m => m.Model, c => c.MapFrom(c => ConstructUserExerciseCollectionBlobAggregatorItemModel(c.Item2, default, default, default, default)));
            #endregion

            #region CollectionBlobAggregatorModel 2 CollectionModel
            CreateMap<CreateUserExerciseCollectionBlobAggregatorModel, CreateUserExerciseCollectionModel>();
            CreateMap<UpdateUserExerciseCollectionBlobAggregatorModel, UpdateUserExerciseCollectionModel>()
                .ForMember(m1 => m1.Model, m2 => m2.MapFrom(m2 => m2.Model.Model));

            #endregion

            #region CollectionModel 2 CollectionEntity
            CreateMap<CreateUserExerciseCollectionModel, UserExerciseCollectionEntity>();
            #endregion

            #region CollectionItemModel 2 CollectionItemEntity
            CreateMap<UserExerciseCollectionItemModel, ExerciseCollectionItemEntity>();
            #endregion

            #region CollectionItemEntity 2 CollectionItemModel
            CreateMap<ExerciseCollectionItemEntity, UserExerciseCollectionItemModel>();
            #endregion

            #region CollectionEntity 2 CollectionModel
            CreateMap<UserExerciseCollectionEntity, UserExerciseCollectionModel>()
                .ForMember(m => m.Collection, c => c.Ignore())
                .AfterMap((e, m) =>
                {
                    m.Collection = new Dictionary<string, List<ICollectionItemModel>>();
                    foreach (var kvp in e.Collection)
                    {
                        var list = new List<ICollectionItemModel>();
                        foreach (var entity in kvp.Value)
                        {
                            var foodEntity = entity as ExerciseCollectionItemEntity;
                            list.Add(new UserExerciseCollectionItemModel
                            {
                                Id = foodEntity.Id,
                                Name = foodEntity.Name,
                                Description = foodEntity.Description,
                                Calories = foodEntity.Calories,
                                AddedDate = foodEntity.AddedDate
                            });
                        }

                        m.Collection.Add(kvp.Key, list);
                    }
                });
            #endregion

            #region CollectionBlobAggregatorModel 2 Contract
            CreateMap<UserExerciseCollectionBlobAggregatorItemModel, ExerciseItemContract>()
                .ForMember(c => c.Id, m => m.MapFrom(m => m.Model.Id))
                .AfterMap((m, c) =>
                {
                    var userFoodCollectionItemModel = m.Model as UserExerciseCollectionItemModel;
                    c.Name = userFoodCollectionItemModel.Name;
                    c.Description = userFoodCollectionItemModel.Description;
                    c.Calories = userFoodCollectionItemModel.Calories;
                    c.AddedDate = userFoodCollectionItemModel.AddedDate;
                    c.Photo = m.Images.Find(i => i.FieldName == "Photo")?.Value;
                });
            #endregion
        }

        private readonly string _defaultCollectionName = "Exercise";

        private DateTime GetDateTimeForMapping()
        {
            return DateTime.UtcNow;
        }

        private UserExerciseCollectionBlobAggregatorItemModel ConstructUserExerciseCollectionBlobAggregatorItemModel(string id, string name, double calories, string description, string photo)
        {
            return new UserExerciseCollectionBlobAggregatorItemModel
            {
                Model = new UserExerciseCollectionItemModel
                {
                    Id = id == Guid.Empty.ToString()
                        ? Guid.NewGuid().ToString()
                        : id,
                    Name = name,
                    AddedDate = GetDateTimeForMapping(),
                    Calories = calories,
                    Description = description
                },
                Images = new List<BlobImageModel>
                {
                    new BlobImageModel
                    {
                        FieldName = "Photo",
                        Value = photo
                    }
                }
            };
        }
    }
}
