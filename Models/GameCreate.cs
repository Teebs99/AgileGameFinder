using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GameCreate
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter a little something please.")]
        [MaxLength(250, ErrorMessage = "Please don't overdo it.")]
        public string Desciption { get; set; }

        [Required]
        public bool Multiplayer { get; set; }

        [Required]
        public string Genre { get; set; }
    }
}
