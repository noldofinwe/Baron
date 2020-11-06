namespace Assets.Source.Models.State
{
    public class GoBuyFood : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            return new GoBuyResourceState(Constants.ResourceIdBread, 10);
        }
    }
}