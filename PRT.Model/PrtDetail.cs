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
        public int NumPushups { get; set; }

        [Display(Name ="Number of Situps")]
        public int NumSitups { get; set; }

        [Display(Name ="1.5 Mile Run Time")]
        public string RunTime { get; set; }

        [Display(Name ="Date of PRT")]
        public DateTime PrtDate { get; set; }

        
    }
    
}
