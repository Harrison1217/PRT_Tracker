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
        public int NumPushups { get; set; }
        [Required]
        public int NumSitUps { get; set; }
        [Required]
        public double MM { get; set; }
        [Required]
        public double SS { get; set; }
        [Required]
        public string RunTime { get; set; }
        [Required]
        public DateTime PrtDate { get; set; }



    }

}
