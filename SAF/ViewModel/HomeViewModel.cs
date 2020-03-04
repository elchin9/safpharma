using SAF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAF.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<SendSms> Messages { get; set; }
    }
}
