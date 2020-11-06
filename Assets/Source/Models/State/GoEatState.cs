namespace Assets.Source.Models.State
{
    public class GoEatState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            if(person.CurrentLocation  != person.GetHome())
            {
                return new GoHomeState();
            }

            return new EatState();
        }
    }
}