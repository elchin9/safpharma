using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAF.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string FullName { get; set; }
        [Required, StringLength(250)]
        public string Profession { get; set; }
        [Required, StringLength(250)]
        public string WorkPlace { get; set; }
        [Required, StringLength(250)]
        public string Region { get; set; }
        [Required, StringLength(15)]
        public string MobileNumber { get; set; }
    }
}
