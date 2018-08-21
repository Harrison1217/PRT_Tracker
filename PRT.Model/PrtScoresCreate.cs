using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT.Model
{
    public class PrtScoresCreate
    {
        [Display(Name ="Enter Date")]
        public DateTime Prt_Date { get; set; }
        [Display(Name = "Number of Pushups")]
        public int Push_Ups { get; set; }
        [Display(Name = "Number of Situps")]
        public int Sit_Ups { get; set; }
        [Display(Name = "1.5 Mile Run Time Minutes")]
        public double MM { get; set; }
        [Display(Name ="1.5 Mile Run Time Seconds")]
        public double SS { get; set; }






    }
}
