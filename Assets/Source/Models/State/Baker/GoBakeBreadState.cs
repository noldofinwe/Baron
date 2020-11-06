using UnityEngine;

namespace Assets.Source.Models.State
{
    public class GoBakeBreadState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Going to bake bread");
            if (person.CurrentLocation != person.GetHome())
            {
                return new GoHomeState();
            }

            return new BakeBreadState();
        }
    }
}