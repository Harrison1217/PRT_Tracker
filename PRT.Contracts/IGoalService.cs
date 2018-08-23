using PRT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT.Contracts
{
    public interface IGoalService
    {
        bool GoalCreate(Goal_Create model);
        IEnumerable<GoalList> GetGoals();
        GoalDetail GetGoalById(int goalId);
        bool UpdateGoal(GoalEdit model);
        bool DeleteGoal(int goalId);


    }
}
