# PRT_Tracker
PRT(Physical Readness Test) Tracker for the Navys PRT Which also allows you to track meals and calories as well as write personal goals for yourself.

This is a Web.MVC n-teir application.

The purpose of this program is to track your progress during your time in the Navy. The 1.0 version of this app allows you to enter in run times, push-ups and sit-ups and will then add them to a chart so you can track your progress over time. This portion of the app will not allow you to edit an entry once it has been entered. The reason for this is that once you take a PRT your scores are final and wont be able to edit them. This part of the app has you enter in the date and time. The reason behind this is so you can enter in past PRT's to be able to see your improvement. My thought process for this was that the person that runs the PRT would be the one entering in the information for the users to see. 

The next page you will come across is the goal page. Here you can write goals for yourself to motivate you and assist in better PRT scores. This also displays a list of your current goals. This page does allow you to edit and delete your goals. 

The last page I titled Nutrition. Here you can enter in the meals you have ate for the day, the calories associated with each meal and your current weight for the day. 

As of right now the only charts displayed on the site are for push-ups, sit-ups, and your run time. 

The following code is from my model layer. Here i am creating what will be displayed after prt scores have been entered. 
Im taking the data from the run time minutes and seconds and combining it into runtime. Also with that a fail safe was created in case the user enters in a single number. This will add a zero to it before the number. For example if you entered in 4 in the minutes and 4 in the secondes. It would display as 4:04.

namespace PRT.Model
{
    public class PrtDetail
    {
        public int PrtId { get; set; }

        [Display(Name ="Number of Pushups")]
        public double NumPushups { get; set; }

        [Display(Name = "Number of Situps")]
        public double NumSitups { get; set; }

  
        public double MM { get; set; }
        
        public double SS { get; set; }
        private string runTime;
        [Display(Name = "1.5 Mile Run Time")]
        public string RunTime
        {
            get { return runTime; }
            set
            {
                if (SS >= 0 && SS <= 9)
                {
                    runTime = String.Format(MM + ":0" + SS);
                }
                else if (SS > 9)
                {
                    runTime = value;
                }
            }
        }

        [Display(Name ="Date of PRT")]
        public DateTime PrtDate { get; set; }

        public double RtSeconds { get; set; }


    }
    
}

The next bit of code is also in the model layer. Here we are taking in the informaton from the nutrition form and displaying it to the user. This also takes all of your calories entered for the day adds them together so you can see your totals from the day. 


namespace PRT.Model
{
    public class NutritionDetail
    {
        public int NutritionId { get; set; }

        public string Breakfast { get; set; }

        [Display(Name ="Calories")]
        public int CaloriesFB { get; set; }

        public string Lunch { get; set; }

        [Display(Name ="Calories")]
        public int CaloriesFL { get; set; }

        public string Dinner { get; set; }

        [Display(Name ="Calories")]
        public int CaloriesFD { get; set; }

        [Display(Name ="Total Calories")]
        public int TotalCalories { get; set; }
        [Display(Name ="Your Weight")]
        public double Weight { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}


The last bit of code comes from our service layer. Here we are actually running through the process of adding the information given to a data table that was created in the data layer of the program. The code shows how we receive the data from the user and save it to our tables. 


namespace PRT.Services
{
    public class GoalServices : IGoalService
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
                    Title = Convert.ToString(model.Title),
                    Content = Convert.ToString(model.Content),
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




