using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT.Model
{
    public class GoalList
    {
        [Display(Name = "Goal Id")]
        public int GoalId { get; set; }
        [Display(Name ="Your Goal")]            
        public string Title { get; set; }

        [Display(Name="Date Created")]
        public DateTimeOffset CreatedDate { get; set; }

        public override string ToString() => Title;

    }
}
