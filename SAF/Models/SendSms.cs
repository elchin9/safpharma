using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAF.Models
{
    public class SendSms
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required, StringLength(250)]
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

        public string Text { get; set; }
    }
}
