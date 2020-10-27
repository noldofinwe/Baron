using System.Linq;
using UnityEngine;

namespace Assets.Source.Models.State
{
    public class GoBringWheatToMillState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Going to sell to mill");

            if (!person.Inventory.HasResource(Constants.ResourceIdWheatSeed) && (person.CurrentLocation == null || person.CurrentLocation != person.GetStorage()))
            {
                return new GoStorageState();
            }

            var amount = person.CurrentLocation.Inventory.HasAmountResource(Constants.ResourceIdWheatSeed) - 300;

            if (amount > 0)
            {
                return new GetItemsFromInventoryState(Constants.ResourceIdWheatSeed, amount);
            }

            if (person.CurrentLocation != null && person.CurrentLocation is Mill)
            {
                return new SellResourceState(Constants.ResourceIdWheatSeed, person.Inventory.HasAmountResource(Constants.ResourceIdWheatSeed));
            }

            var area = person.CurrentArea ?? person.CurrentLocation.Area;
            var mill = area.Locations.FirstOrDefault(p => p is Mill);
            if (mill == null)
            {
                Debug.Log("No mill found");
                return new DoLongNothingState();
            }
            person.TargetLocation = mill;
            return new TravelState();
        }
    }
}