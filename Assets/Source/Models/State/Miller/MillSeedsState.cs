using Assets.Source.Models.Resources;

namespace Assets.Source.Models.State
{
    public class MillSeedsState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            var mill = person.CurrentLocation;

            var storage = person.GetStorage();

            storage.Inventory.RemoveResource(Constants.ResourceIdWheatSeed, Constants.SeedsToFlour);

            mill.CurrentState = new MillingLocationState();
            return new DoNothingState();
        }
    }
}