using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT.Model
{
    public class NutritionCreate
    {
        
        [MinLength(2, ErrorMessage ="Please add more detail.")]
        [MaxLength(8000)]
        public string Breakfast { get; set; }
        [Display(Name = "Calories From Breakfast")]
        public int Calories_from_Breakfast { get; set; }

        [MinLength(2, ErrorMessage = "Please add more detail.")]
        [MaxLength(8000)]
        public string Lunch { get; set; }
        [Display(Name = "Calories From Lunch")]
        public int Calories_from_Lunch { get; set; }

        [MinLength(2, ErrorMessage = "Please add more detail.")]
        [MaxLength(8000)]
        public string Dinner { get; set; }
        [Display(Name = "Calories From Dinner")]
        public int Calories_from_Dinner { get; set; }

        public double Weight { get; set; }

        



    }
}
