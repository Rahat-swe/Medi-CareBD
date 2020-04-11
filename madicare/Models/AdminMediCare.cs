using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace madicare.Controllers
{
    public class AdminMediCare
    {
        [Key]
        public int aid { get; set; }
        [Required]
        public String aname { get; set; }
        [Required]
        public String aphone { get; set; }
        [Required]
        public String aaddress { get; set; }
        [Required]
        public String agender { get; set; }
        [Required]
        public String aemail { get; set; }
        [Required]
        public String apassword { get; set; }
        [Required]
        public String adate_of_brith { get; set; }

    }
}
