using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT.Data
{
    public class NutritionGuide
    {
        [Key]
        public int NutritionId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Breakfeast { get; set; }
        [Required]
        public string Lunch { get; set; }
        [Required]
        public string Dinner { get; set; }
        [Required]
        public int CaloriesFB { get; set; }
        [Required]
        public int CaloriesFL { get; set; }
        [Required]
        public int CaloriesFD { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }

        public int TotalCalories { get; set; }

        

    }
}
