using UnityEngine;

namespace Assets.Source.Models.State
{
    public class EatState : BaseState
    {
        private int _doNothingTime;
        private int _currentdoNothingTime = 0;
        public EatState()
        {

            _doNothingTime = RandomSingleton.Instance.Random.Next(500, 2000);
        }

        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Eating");
            _currentdoNothingTime++;


            if (_currentdoNothingTime == _doNothingTime)
            {
                person.Inventory.RemoveResource(Constants.ResourceIdBread, 1);
                person.Hunger = person.Hunger - Constants.BreadSatiate;
                return person.GetFindWorkState();
            }
            return this;
        }

        public override int HungryStep => 0;
    }
}