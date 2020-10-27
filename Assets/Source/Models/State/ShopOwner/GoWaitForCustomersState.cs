namespace Assets.Source.Models.State
{
    public class GoWaitForCustomersState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            if (person.CurrentLocation == null)
            {
                person.TargetLocation = person.GetHome();
                return new TravelState();
            }


            return new WaitForCustomersState();

        }
    }
}