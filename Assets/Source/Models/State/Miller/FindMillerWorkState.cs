namespace Assets.Source.Models.State
{
    public class FindMillerWorkState : FindWorkState
    {
        public override BaseState Update(PersonModel person)
        {
            var mill = person.GetHome();

            if (mill.CurrentState == null && person.GetStorage().Inventory.HasAmountResource(Constants.ResourceIdWheatSeed) > Constants.SeedsToFlour)
            {
                return new GoMillSeedsState();
            }
            if (person.Inventory.HasAmountResource(Constants.ResourceIdWheatSeed) > 100)
            {
                return new GoStoreResourceState(Constants.ResourceIdWheatSeed);
            }
            if(person.HasInTotalInventory(Constants.ResourceIdFlour) > 1)
            {
                return new GoSellFlourState();
            }
            if (person.CurrentLocation != mill)
            {
                return new GoHomeState();
            }

            return this;
        }
    }
}
