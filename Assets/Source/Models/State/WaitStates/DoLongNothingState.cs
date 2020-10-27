using System;

namespace Assets.Source.Models.State
{
    public class DoLongNothingState : BaseState
    {
        private int _doNothingTime;
        private int _currentdoNothingTime = 0;
        public DoLongNothingState()
        {
            var random = new Random();
            _doNothingTime = random.Next(500, 2000);
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