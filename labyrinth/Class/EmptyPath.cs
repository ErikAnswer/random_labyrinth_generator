﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labyrinth.Interface;

namespace labyrinth.Class
{
    class EmptyPath : IComponent
    {
        public string getComp()
        {
            return " ";
        }
    }
}
