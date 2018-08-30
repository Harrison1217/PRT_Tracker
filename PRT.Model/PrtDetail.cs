using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
