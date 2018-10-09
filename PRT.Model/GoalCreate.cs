using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT.Model
{
    public class Goal_Create
    {
        [Required]
        [MinLength(2, ErrorMessage ="Please enter a longer title for this Goal.")]
        [MaxLength(100, ErrorMessage ="You have exceede the max number of charactors in this field")]
        public string Title { get; set; }
        [MaxLength(9000, ErrorMessage = "You have exceede the max number of charactors in this field")]
        [Display(Name ="Goal")]
        public string Content { get; set; }

        public override string ToString() => Title + Content;
        



    }
}
