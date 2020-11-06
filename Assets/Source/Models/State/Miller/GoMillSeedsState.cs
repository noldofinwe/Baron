using System.Runtime.InteropServices.WindowsRuntime;

namespace Assets.Source.Models.State
{
    public class GoMillSeedsState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            if(person.CurrentLocation != person.GetHome())
            {
                return new GoHomeState();
            }

            return new MillSeedsState();
        }
    }
}