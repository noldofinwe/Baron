using UnityEngine;

namespace Assets.Source.Models.State
{
    public class GoIntoTargetLocationState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Arrived at location");
            if (person.CurrentLocation == null)
            {
                person.CurrentLocation = person.TargetLocation;
               //person.CurrentArea.RemovePerson(person);
                person.CurrentLocation.AddPerson(person);
                person.CurrentArea = null;
                person.TargetLocation = null;
            }
            return new DoNothingState();
        }
    }
}