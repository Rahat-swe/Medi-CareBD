using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace madicare.Models
{
    public class medicine
    {


        [Key]
        public int MedicineId { get; set; }
       
        [Required]        
        public string MedicineName { get; set; }       
        public string Medicineinfo { get; set; }

       

    }
}
