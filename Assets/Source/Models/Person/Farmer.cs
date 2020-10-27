using Assets.Source.Models.State;
using System;

namespace Assets.Source.Models
{
    public class Farmer : PersonModel
    {
  

        public Farmer(Guid guid, string name, Location currentLocation) : base(guid, name, currentLocation)
        {
        }

        public override void Update()
        {
            base.Update();
        }

        public Location GetEmptyField()
        {
            return null;
        }

        public override FindWorkState GetFindWorkState()
        {
            return new FindFarmWorkState();
        }
    }
}
