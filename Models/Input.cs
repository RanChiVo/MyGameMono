﻿using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameMono.Models
{
  public  class Input
    {
        public Keys Down { get; set; }

        public Keys Up { get; set; }

        public Keys Right { get; set; }

        public Keys Left { get; set; }

        public Keys Jump { get; set; }

        public Keys Touch { get; set; }


        public bool IsObstacle { get; set; }

    }
}
