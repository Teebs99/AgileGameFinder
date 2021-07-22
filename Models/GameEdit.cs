﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GameEdit
    {
        public int GameId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Genre { get; set; }

        public bool Multiplayer { get; set; }

        public bool HasPlayed { get; set; }

    }
}
