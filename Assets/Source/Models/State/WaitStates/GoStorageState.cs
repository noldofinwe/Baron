using UnityEngine;

namespace Assets.Source.Models.State
{
    public class GoStorageState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Going to storage");
            var home = person.GetStorage();

            if (home == null)
            {
                Debug.Log("I have no storage place");
                return new DoNothingState();
            }

            if (person.CurrentLocation != null && person.CurrentLocation.Id == home.Id)
            {
                Debug.Log("Already at storage place");
                return new DoLongNothingState();
            }
            Debug.Log("Traveling to storage");
            person.TargetLocation = home;
            return new TravelState();
        }
    }
}