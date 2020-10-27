using UnityEngine;

namespace Assets.Source.Models.State
{
    public class TravelState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            //Debug.Log("Travel");
            if(person.TargetLocation == null)
            {
                Debug.Log($"No destination found");
                return new DoNothingState();
            }


            if (person.CurrentLocation != null)
            {
                Debug.Log($"Travel Get out of location {person.CurrentLocation.Name}");
                person.X = person.CurrentLocation.X;
                person.Y = person.CurrentLocation.Y;

                person.CurrentArea = person.CurrentLocation.Area;
                person.CurrentLocation = null;
                return this;
            }
            else if (person.CurrentArea != null)
            {
                Debug.Log($"Travel in Area ");


                if (person.CurrentArea.Contains(person.TargetLocation))
                {
                    var targetX = person.TargetLocation.X;
                    var targetY = person.TargetLocation.Y;
                    bool atX = false;
                    bool atY = false;

                   // Debug.Log($"Travel ({person.X} {person.Y}) to ({targetX} {targetY})");
                    if (person.X < targetX)
                    {
                        person.X++;
                    }
                    else if (person.X > targetX)
                    {
                        person.X--;
                    }
                    else
                    {
                        atX = true;
                    }

                    if (person.Y < targetY)
                    {
                        person.Y++;
                    }
                    else if (person.Y > targetY)
                    {
                        person.Y--;
                    }
                    else
                    {
                        atY = true;
                    }

                    if (atY && atX)
                    {
                        return new GoIntoTargetLocationState();
                    }
                }
            }


            return this;

        }
    }
}