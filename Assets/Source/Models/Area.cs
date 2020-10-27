using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Assets.Source.Models
{
    public class Area
    {
        private string _name;

        public List<Location> Locations { get; set; }

        public Area(string name)
        {
            _name = name;
            Locations = new List<Location>();
        }


        public void AddLocation(Location location)
        {
            Locations.Add(location);
        }

        public void Update()
        {
            Locations.ForEach(p => p.Update()); 
        }

        public bool Contains(Location targetLocation)
        {
            return Locations.Any(p => p.Id == targetLocation.Id);
        }
    }
}