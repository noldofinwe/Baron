using Assets.Source.Models.Resources;
using UnityEngine;

namespace Assets.Source.Models.State
{
    public class BakeryLocationState : BaseLocationState
    {
        private int _doNothingTime;
        private int _currentdoNothingTime = 0;

        public BakeryLocationState()
        {
            _doNothingTime = Constants.BakingTime;
        }
 
        public override BaseLocationState Update(Location location)
        {
            _currentdoNothingTime++;
            if (_currentdoNothingTime == _doNothingTime)
            {
                location.Inventory.AddResource(ResourceFactory.GetResource(Constants.ResourceIdBread), 1);

                Debug.Log("Baked 1 Bread");
                return null;
            }
            return this;
        }
    }
}