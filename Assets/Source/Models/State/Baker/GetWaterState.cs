namespace Assets.Source.Models.State
{
    public class GetWaterState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            person.Inventory.AddResource(Constants.ResourceIdWater, 1);
            return new DoNothingState();
        }
    }
}