namespace Assets.Source.Models.State
{
    public class FindShopOwnerWorkState : FindWorkState
    {
        public override BaseState Update(PersonModel person)
        {
            return new GoWaitForCustomersState();
        }
    }
}
