using System.Linq;
using UnityEngine;

namespace Assets.Source.Models.State
{
    internal class GoSellFlourState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Going to sell flour to bakery");

            if (!person.Inventory.HasResource(Constants.ResourceIdFlour) && (person.CurrentLocation == null || person.CurrentLocation != person.GetStorage()))
            {
                return new GoStorageState();
            }

            var amount = person.CurrentLocation.Inventory.HasAmountResource(Constants.ResourceIdFlour);

            if (amount > 0)
            {
                return new GetItemsFromInventoryState(Constants.ResourceIdFlour, amount);
            }

            if (person.CurrentLocation != null && person.CurrentLocation is Bakery)
            {
                return new SellResourceState(Constants.ResourceIdFlour, person.Inventory.HasAmountResource(Constants.ResourceIdFlour));
            }

            var area = person.CurrentArea ?? person.CurrentLocation.Area;
            var shop = area.Locations.FirstOrDefault(p => p is Bakery);
            if (shop == null)
            {
                Debug.Log("No shop found");
                return new GoHomeState();
            }
            person.TargetLocation = shop;
            return new TravelState();
        }
    }
}