using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Models
{
    public class Mill : Location
    {
        public Mill(Guid guid, string name, Area area, int x, int y, int width, int length, bool home) : base(guid, name, area, x, y, width, length, home)
        {
        }
    }
}
