using PRT.Data;
using PRT.Model;
using PRTTracker.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT.Services
{
    public class NutritionServices
    {
        private readonly Guid _userId;

        public NutritionServices(Guid userId)
        {
            _userId = userId;
        }

        public bool NutritionCreate(NutritionCreate model)
        {
            var entity =
                new NutritionGuide()
                {
                    UserId = _userId,
                    Breakfeast = model.Breakfast,
                    Lunch = model.Lunch,
                    Dinner = model.Dinner,
                    CaloriesFB = model.Calories_from_Breakfast,
                    CaloriesFD = model.Calories_from_Dinner,
                    CaloriesFL = model.Calories_from_Lunch,
                    Weight = model.Weight,
                    TotalCalories = model.Calories_from_Breakfast + model.Calories_from_Dinner + model.Calories_from_Lunch,
                    Date = DateTimeOffset.Now


                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Nutrition.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<NutritionList> GetNutritions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Nutrition
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new NutritionList
                                {
                                    NutritionId = e.NutritionId,
                                    Breakfeast = e.Breakfeast,
                                    Lunch = e.Lunch,
                                    Dinner = e.Dinner,
                                    TotalCalories = e.TotalCalories,
                                    Weight = e.Weight,
                                    Date = e.Date

                                }
                                );
                return query.ToArray();
            }
        }

        public NutritionDetail GetNutritionById(int nutritionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Nutrition
                        .Single(e => e.NutritionId == nutritionId && e.UserId == _userId);
                return
                    new NutritionDetail
                    {
                        NutritionId = entity.NutritionId,
                        Breakfast = entity.Breakfeast,
                        CaloriesFB = entity.CaloriesFB,
                        Lunch = entity.Lunch,
                        CaloriesFL = entity.CaloriesFL,
                        Dinner = entity.Dinner,
                        CaloriesFD = entity.CaloriesFD,
                        TotalCalories = entity.TotalCalories,
                        Weight = entity.Weight,
                        Date = entity.Date
                        
                    };

            }
        }
    }
}
