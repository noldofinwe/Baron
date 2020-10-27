using System;
using System.Collections.Generic;

namespace Assets.Source.Models
{

    public class World
    {
        public List<PersonModel> Persons { get; } = new List<PersonModel>();
        public List<Area> Areas { get; }
        public int currentCount = 0;

        public World()
        {
            Areas = new List<Area>();
        }

        public void AddArea(Area area)
        {
            Areas.Add(area);
        }

        internal void Update()
        {
            if(currentCount < Constants.SlowdownFactor)
            {
                currentCount++;
                return;
            }
            currentCount = 0;
            Areas.ForEach(p => p.Update());
            Persons.ForEach(p => p.Update());
        }

        public void AddPerson(PersonModel person)
        {
            Persons.Add(person);
        }
    }
}
