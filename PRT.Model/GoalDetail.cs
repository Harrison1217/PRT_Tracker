using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT.Model
{
    public class GoalDetail
    {
        public int GoalId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Display(Name="Create Date")]
        public DateTimeOffset CreatedDate { get; set; }
        [Display(Name ="Date Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{GoalId}] {Title}";

    }
}
