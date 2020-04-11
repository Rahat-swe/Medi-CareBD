using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace madicare.Models
{
    public class Doctor
    {

        [Key]
        public int did { get; set; }
        [Required]
        public String dname { get; set; }
        [Required]
        public String dphone { get; set; }
        [Required]
        public String daddress { get; set; }
        [Required]
        public String dgender { get; set; }
        [Required]
        public String demail { get; set; }
        [Required]
        public String dpassword { get; set; }
        [Required]
        public String ddate_of_brith { get; set; }
        [Required]
        public String dqualification { get; set; }

        public int VillageId { get; set; }
        [ForeignKey("VillageId")]
       public  VillageDetails villageDetails { get; set; }


    }
}
