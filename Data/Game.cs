using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }
        //public GameSystems TypeOfSystem { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool Multiplayer { get; set; }
        //public bool HasPlayed { get; set; }

        [Required]
        public bool HasPlayed { get; set; }
    }
}
