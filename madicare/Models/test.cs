using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace madicare.Models
{
    public class test
    {
        [Key]
        public int mid { get; set; }

        public String mname { get; set; }
        public String minfo { get; set; }

        public List<Patient> patients{ get; set; }
    }
}
