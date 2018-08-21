using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
