using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT.Model
{
    public class NutritionList
    {
        [Display(Name ="Nutrition ID")]
        public int NutritionId { get; set; }
        [Display(Name ="Total Calories")]
        public int TotalCalories { get; set; }
        
        public string Breakfeast { get; set; }
        public string Lunch { get; set; }
        public string Dinner { get; set; }
        [Display(Name ="Your Weight")]
        public double Weight { get; set; }
        [Display(Name = "Date Entered")]
        public DateTimeOffset Date { get; set; }

    }
}
