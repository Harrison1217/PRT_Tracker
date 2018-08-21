using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT.Model
{
    public class PrtScoresList
    {
        [Display(Name ="PRT ID")]
        public int prtId { get; set; }
        [Display(Name ="Number Of Pushups")]
        public int NumPushups { get; set; }
        [Display(Name = "Number Of Situps")]
        public int NumSitups { get; set; }
        [Display(Name = "1.5 Mile Run Time")]
        public string RunTime { get; set; }
        [Display(Name = "Date of PRT")]
        public DateTime PrtDate { get; set; }
        [Display(Name = "1.5 Mile Run Time Minutes")]
        public double MM { get; set; }
        [Display(Name = "1.5 Mile Run Time Seconds")]
        public double SS { get; set; }
        


    }
}
