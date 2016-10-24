using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Zxl.Models
{
    public class Module
    {
        [Key]
        public int AutoId { get; set; }

        [Required(ErrorMessage="必填项")]
        public Guid ModuleId { get; set; }
    }
}
