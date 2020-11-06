using System;
using UnityEngine;

namespace Assets.Source.Models.State
{
    public class GoSeedFieldState : BaseState
    {
        private Field _fieldNeedsSeeding;
        private int minimumAmountNeeded = 50;

        public GoSeedFieldState(Field fieldNeedsSeeding)
        {
            _fieldNeedsSeeding = fieldNeedsSeeding;
        }

        public override BaseState Update(PersonModel person)
        {
            var farmer = (Farmer)person;

            var amount = farmer.Inventory.HasAmountResource(Constants.ResourceIdWheatSeed);

            if (amount < minimumAmountNeeded)
            {
                var location = farmer.GetInventoryWithMostLocation(Constants.ResourceIdWheatSeed);
                if (location != null)
                {
                    if(location == farmer.CurrentLocation)
                    {
                        return new GetItemsFromInventoryState(Constants.ResourceIdWheatSeed, 100);
                    }
                    else
                    {
                        farmer.TargetLocation = location;
                        return new TravelState();
                    }
                }
                else if(farmer.Inventory.HasAmountResource(Constants.ResourceIdCoin) > 0)
                {
                   return new GoBuyResourceState(Constants.ResourceIdWheatSeed, 200);
                }
            }
            else if (farmer.CurrentLocation.Id != _fieldNeedsSeeding.Id)
            {
                Debug.Log($"Going to field");
                person.TargetLocation = _fieldNeedsSeeding;
                return new TravelState();

            }
            else
            {
                return new SeedFieldState();
            }
            return new GoHomeState();
        }
    }
}