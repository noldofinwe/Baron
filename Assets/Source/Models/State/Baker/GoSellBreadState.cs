using System.Linq;
using UnityEngine;

namespace Assets.Source.Models.State
{
    public class GoSellBreadState : BaseState
    {

        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Going to sell bread to shop");

            if (!person.Inventory.HasResource(Constants.ResourceIdBread) && (person.CurrentLocation == null || person.CurrentLocation != person.GetStorage()))
            {
                return new GoStorageState();
            }

            var amount = person.CurrentLocation.Inventory.HasAmountResource(Constants.ResourceIdBread);

            if (amount > 0)
            {
                return new GetItemsFromInventoryState(Constants.ResourceIdBread, amount);
            }

            if (person.CurrentLocation != null && person.CurrentLocation is Shop)
            {
                return new SellResourceState(Constants.ResourceIdBread, person.Inventory.HasAmountResource(Constants.ResourceIdBread));
            }

            var area = person.CurrentArea ?? person.CurrentLocation.Area;
            var shop = area.Locations.FirstOrDefault(p => p is Shop);
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