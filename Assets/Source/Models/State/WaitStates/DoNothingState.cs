using System;

namespace Assets.Source.Models.State
{
    public class DoNothingState : BaseState
    {
        private int _doNothingTime;
        private int _currentdoNothingTime = 0;
        public DoNothingState()
        {

            _doNothingTime = RandomSingleton.Instance.Random.Next(40, 100);
        }

        public DoNothingState(string id)
        {
            var random = new Random();
            _doNothingTime = random.Next(40, 100);
        }

        public override BaseState Update(PersonModel person)
        {
            _currentdoNothingTime++;
            if (_currentdoNothingTime == _doNothingTime)
            {
                return person.GetFindWorkState();
            }
            return this;
        }
    }
}
