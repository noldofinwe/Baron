using System;
using System.Data.SqlTypes;

namespace Assets.Source.Models.State
{
    public class GoStoreResourceState : BaseState
    {
        private Guid resourceIdWheatSeed;

        public GoStoreResourceState(Guid resourceIdWheatSeed)
        {
            this.resourceIdWheatSeed = resourceIdWheatSeed;
        }

        public override BaseState Update(PersonModel person)
        {
            if(person.CurrentLocation != person.GetStorage())
            {
                    return new GoStorageState();
            }
            return new StoreResourceState(resourceIdWheatSeed);
        }
    }
}