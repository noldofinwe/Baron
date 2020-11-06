using System;

namespace Assets.Source.Models
{
    public class Well : Location
    {
        public Well(Guid guid, string name, Area area, int x, int y, int width, int length) : base(guid, name, area, x, y, width, length, false)
        {
        }
    }
}
