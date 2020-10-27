namespace Assets.Source.Models.State
{
    public class FindMillerWorkState : FindWorkState
    {
        public override BaseState Update(PersonModel person)
        {
            if(person.GetStorage().Inventory.HasAmountResource(Constants.ResourceIdWheatSeed) == 0)
            {
                return new DoLongNothingState();
            }
            return this;
        }
    }
}
