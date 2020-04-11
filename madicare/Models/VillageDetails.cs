using madicare.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace madicare.Models
{
    public class VillageDetails
    {
       

        [Key]
        public int VillageId { get; set; }
        [Required]
        [Display(Name = "Village Name")]
        public string VillageName { get; set; }

        [Display(Name = "District Name")]
        public string District { get; set; }

        public List<Doctor> doctor { get; set; }
    }
}
