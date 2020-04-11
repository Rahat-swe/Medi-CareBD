using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace madicare.Models
{
    public class Patient
    {
        [Key]
        public int pid { get; set; }
        [Required]
        public String pname { get; set; }
        [Required]
        public String pphone { get; set; }
        [Required]
        public String paddress { get; set; }
        [Required]
        public String pgender { get; set; }
        [Required]
        public String pweight { get; set; }
        [Required]
        public String phight { get; set; }
    
        public String pbmi { get; set; }
      
        public String pbmr { get; set; }
 
        public String pbp { get; set; }
        [Required]
        public String pdate_of_brith { get; set; }

        [Required]
       
        public String ppassword { get; set; }

        public String pdisease { get; set; }

        public String pdiseaseSlove { get; set; }

        public int mid { get; set; }
        [ForeignKey("mid")]

        public  test tests { get; set; }





    }
}
