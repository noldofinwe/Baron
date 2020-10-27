using System;
using UnityEngine;

namespace Assets.Source.Models.State
{
    internal class PutItemsInInventoryState : BaseState
    {
        private Guid guid;

        public PutItemsInInventoryState(Guid guid)
        {
            this.guid = guid;
        }

        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Putting items in stock");

            var resourcestack = person.Inventory.GetResource(guid, int.MaxValue);
            person.CurrentLocation.Inventory.AddResource(resourcestack.Resource, resourcestack.Amount);
            return new DoNothingState();
        }
    }
}