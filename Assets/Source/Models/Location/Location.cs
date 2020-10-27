using Assets.Source.Models.Inventory;
using Assets.Source.Models.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Models
{

    public class Location
    {
        private string _name;
        private Guid _guid;
        private int _x, _y;
        private int _width, _length;
        private List<PersonModel> _persons = new List<PersonModel>();
        private Area _area;
        private bool _home;

        public Location(Guid guid, string name, Area area, int x, int y, int width, int length, bool home)
        {
            _guid = guid;
            _name = name;
            _x = x;
            _y = y;
            _width = width;
            _length = length;
            _area = area;
            _home = home;
            Inventory = new InventoryStorage();
        }

        public void RemovePerson(PersonModel person)
        {
            Debug.Log("Remove person from location");
            _persons.Remove(person);
        }

        public string Name { get { return _name; } }

        public int X { get { return _x; } }
        public int Y { get { return _y; } }

        public Area Area { get { return _area; } }

        public bool IsHome { get { return _home; } }
        public Guid Id { get { return _guid; } }

        public InventoryStorage Inventory { get; set; }
        public PersonModel Owner { get; internal set; }

        public void AddPerson(PersonModel person)
        {
            _persons.Add(person);
        }


        public virtual void Update()
        {
            //_persons.ForEach(p => p.Update());
        }
    }
}