using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT.Data
{
    public class PrtScores
    {
        [Key]
        public int prtID { get; set; }
        [Required]
        public Guid UserID { get; set; }
        [Required]
        public double NumPushups { get; set; }
        [Required]
        public double NumSitUps { get; set; }
        [Required]
        public double MM { get; set; }
        [Required]
        public double SS { get; set; }

        
        
        private string runTime;
        [Required]
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
                
                if (SS >= 60)
                {
                    
                }
            }
        }

        [Required]
        public DateTime PrtDate { get; set; }

        public double RtSeconds { get; set; }



    }

}
