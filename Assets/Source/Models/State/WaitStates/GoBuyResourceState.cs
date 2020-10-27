using System;
using System.Linq;
using UnityEngine;

namespace Assets.Source.Models.State
{
    internal class GoBuyResourceState : BaseState
    {
        private Guid guid;

        public GoBuyResourceState(Guid guid)
        {
            this.guid = guid;
        }

        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Go to the shop");
            if(person.CurrentLocation != null && person.CurrentLocation is Shop)
            {
                return new BuyResourceState(guid, 0);
            }

            var area = person.CurrentArea ?? person.CurrentLocation.Area;
            var shop = area.Locations.FirstOrDefault(p => p is Shop && p.Inventory.HasResource(guid));
            if(shop == null)
            {
                Debug.Log("No shop found");
                return new DoLongNothingState();
            }
            person.TargetLocation = shop;
            return new TravelState();


        }
    }
}