

using UnityEngine;

namespace Assets.Source.Models.State
{
    public class RestingState : BaseState
    {
        private int _doNothingTime;
        private int _currentdoNothingTime = 0;
        public RestingState()
        {
            _doNothingTime = RandomSingleton.Instance.Random.Next(500, 2000);
        }

        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Resting"); 
            _currentdoNothingTime++;
            
            if (person.Tiredness <= 0 ||_currentdoNothingTime == _doNothingTime)
            {
                return person.GetFindWorkState();
            }
            return this;
        }

        public override int TiredStep => -5;
    }
}