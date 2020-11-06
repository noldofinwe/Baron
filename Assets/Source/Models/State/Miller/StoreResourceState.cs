using System;

namespace Assets.Source.Models.State
{
    public class StoreResourceState : BaseState
    {
        private Guid resourceIdWheatSeed;

        public StoreResourceState(Guid resourceIdWheatSeed)
        {
            this.resourceIdWheatSeed = resourceIdWheatSeed;
        }

        public override BaseState Update(PersonModel person)
        {
            var amount = person.Inventory.HasAmountResource(resourceIdWheatSeed);
            var resource = person.Inventory.GetResource(resourceIdWheatSeed, amount);
            person.CurrentLocation.Inventory.AddResource(resourceIdWheatSeed, resource.Amount);
            return new DoNothingState();
        }
    }
}