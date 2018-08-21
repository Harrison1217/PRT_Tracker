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
    public class GoalServices
    {
        private readonly Guid _userId;

        public GoalServices(Guid userId)
        {
            _userId = userId;
        }

        public bool GoalCreate(Goal_Create model)
        {
            var entity =
                new Goals()
                {
                    UserId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    CreatedDate = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.goal.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GoalList> GetGoals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .goal
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new GoalList
                                {
                                    GoalId = e.GoalId,
                                    Title = e.Title,
                                    CreatedDate = e.CreatedDate
                                }
                                );
                return query.ToArray();
            }
        }

        public GoalDetail GetGoalById(int goalId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .goal
                        .Single(e => e.GoalId == goalId && e.UserId == _userId);
                return
                    new GoalDetail
                    {
                        GoalId = entity.GoalId,
                        Title = entity.Title,
                        Content = entity.Content,
                        CreatedDate = entity.CreatedDate,
                        ModifiedUtc = entity.ModifiedUtc
                    };

            }
        }

        public bool UpdateGoal(GoalEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .goal
                        .Single(e => e.GoalId == model.GoalId && e.UserId == _userId);
                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGoal(int goalId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .goal
                        .Single(e => e.GoalId == goalId && e.UserId == _userId);
                ctx.goal.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }


}
