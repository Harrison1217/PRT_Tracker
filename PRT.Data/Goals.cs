using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT.Data
{
    public class Goals
    {
        [Key]
        public int GoalId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MinLength(5, ErrorMessage ="Please add More Detail to your Goal.")]
        [Display(Name ="Goal Was Created!")]
        public string Content { get; set; }
        [Required]
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
