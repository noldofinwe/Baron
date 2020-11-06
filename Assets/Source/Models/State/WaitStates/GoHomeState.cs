using UnityEngine;

namespace Assets.Source.Models.State
{
    public class GoHomeState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Going home");
            var home = person.GetHome();

            if (home == null)
            {
                Debug.Log("I have no home");
                return new DoNothingState();
            }

            if (person.CurrentLocation != null && person.CurrentLocation.Id == home.Id)
            {
                Debug.Log("Already home");
                return new RestingState();
            }
            Debug.Log("Traveling home");
            person.TargetLocation = home;
            return new TravelState();
        }
    }
}