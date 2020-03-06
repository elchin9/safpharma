using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAF.ViewModel
{
    public class ExcelViewModel
    {
        [Required(ErrorMessage = "Xahiş olunur fayl yükləyin.")]
        public IFormFile File { get; set; }
    }
}
