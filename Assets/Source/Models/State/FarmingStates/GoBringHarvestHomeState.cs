using System;

namespace Assets.Source.Models.State
{
    public class GoBringHarvestHomeState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            if (person.CurrentLocation == null || person.CurrentLocation != person.GetStorage())
            {
                return new GoStorageState();
            }
            return new PutItemsInInventoryState(Constants.ResourceIdWheatPlant);
        }
    }
}