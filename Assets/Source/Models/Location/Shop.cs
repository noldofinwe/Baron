﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Models
{
    public class Shop : Location
    {
        public Shop(Guid guid, string name, Area area, int x, int y, int width, int length) : base(guid, name, area, x, y, width, length, true)
        {
            
        }
    }
}
