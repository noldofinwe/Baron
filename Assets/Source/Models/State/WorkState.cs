using System;
using UnityEngine;

namespace Assets.Source.Models.State
{
    public class WorkState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Work");
            return new DoNothingState();
        }
    }
}
