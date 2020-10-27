namespace Assets.Source.Models.State
{
    public class WaitForCustomersState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            return this;
        }
    }
}