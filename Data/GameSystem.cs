using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class GameSystem
    {
        [Key]
        public int SystemId { get; set; }
        public List<string> Games = new List<string>(); //string to be replaced with Game class
        [Required]
        public string SystemName { get; set; }
        public string CompanyName { get; set; }

    }
}
