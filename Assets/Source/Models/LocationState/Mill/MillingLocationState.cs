using Assets.Source.Models.Resources;
using UnityEngine;

namespace Assets.Source.Models.State
{
    public class MillingLocationState : BaseLocationState
    {
        private int _doNothingTime;
        private int _currentdoNothingTime = 0;

        public MillingLocationState()
        {
            _doNothingTime = Constants.MillingTime;
        }
 
        public override BaseLocationState Update(Location location)
        {
            _currentdoNothingTime++;
            if (_currentdoNothingTime == _doNothingTime)
            {
                location.Inventory.AddResource(ResourceFactory.GetResource(Constants.ResourceIdFlour), 1);

                Debug.Log("Milled 1 flour");
                return null;
            }
            return this;
        }
    }
}