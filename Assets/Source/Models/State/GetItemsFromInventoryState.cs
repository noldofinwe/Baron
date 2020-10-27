using System;
using UnityEngine;

namespace Assets.Source.Models.State
{
    internal class GetItemsFromInventoryState : BaseState
    {
        private Guid guid;
        private readonly int amount;

        public GetItemsFromInventoryState(Guid guid, int amount)
        {
            this.guid = guid;
            this.amount = amount;
        }

        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Getting item from stock");

            var resourcestack = person.CurrentLocation.Inventory.GetResource(guid, amount);
            person.Inventory.AddResource(resourcestack.Resource, resourcestack.Amount);
            return new DoNothingState();
        }
    }
}