using Assets.Source.Models.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Models
{
    public class Baker : PersonModel
    {
        public Baker(Guid guid, string name, Location currentLocation) : base(guid, name, currentLocation)
        {
        }

        public override FindWorkState GetFindWorkState()
        {
            return new FindBakerWorkState();
        }
    }
}
