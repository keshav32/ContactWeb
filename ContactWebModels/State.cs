using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWebModels
{
    public class State
    {
        [Key]

        public int Id { get; set; }

        [Display(Name ="State")]
        [Required(ErrorMessage = "The name is required for stage")]
        [StringLength(ContactConstant.MAX_State_name_length)]
        public string Name { get; set; }

        [Required(ErrorMessage ="State abbrevation is required")]
        [StringLength(ContactConstant.MAX_State_abrr_length)]
        public string abbrevation { get; set; }


    }
}
