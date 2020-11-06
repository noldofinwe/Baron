using System;
using System.Linq;
using UnityEngine;

namespace Assets.Source.Models.State
{
    internal class GoBuyResourceState : BaseState
    {
        private Guid guid;
        private int amount;

        public GoBuyResourceState(Guid guid, int amount)
        {
            this.guid = guid;
            this.amount = amount;
        }

        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Go to the shop");
            if(person.CurrentLocation != null && person.CurrentLocation is Shop)
            {
                return new BuyResourceState(guid, amount);
            }

            var area = person.CurrentArea ?? person.CurrentLocation.Area;
            var shop = area.Locations.FirstOrDefault(p => p is Shop && p.Inventory.HasResource(guid));
            if(shop == null)
            {
                Debug.Log("No shop found");
                return new GoHomeState();
            }
            person.TargetLocation = shop;
            return new TravelState();


        }
    }
}