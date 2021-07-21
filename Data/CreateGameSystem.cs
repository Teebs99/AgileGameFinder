using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CreateGameSystem
    {
        [Required]
        public string SystemName { get; set; }
        public string CompanyName { get; set; }
    }
}
