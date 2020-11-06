using Assets.Source.Models;
using Assets.Source.Models.Enums;
using Assets.Source.Models.Resources;
using Assets.Source.Views;
using System;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

namespace Assets.Source.Helpers
{
    public class TestWorldGenerator
    {

        public static World Generate()
        {
            //var building = new Building("Farm house");
            Debug.Log("Generating Test world");
            var world = new World();
            var area = new Area("Farm area");
            Farmer person = GenerateFarm(area, 20 ,20, "Jim");
            Farmer person1 = GenerateFarm(area, 120 ,150, "John");
            Farmer person2 = GenerateFarm(area, -120 ,-120, "Wim");
            Farmer person3 = GenerateFarm(area, -130 ,100, "Eddard");
            Farmer person4 = GenerateFarm(area, 130, -90, "John");
            ShopOwner person5 = GenerateShop(area, 0, -160, "Mark");
            Miller person6 = GenerateMill(area, 0, 160, "Mark");
            Baker person7 = GenerateBakery(area, -40, 160, "Mark");
            GenerateWell(area, 60, 175);
            world.AddPerson(person);
            world.AddPerson(person1);
            world.AddPerson(person2);
            world.AddPerson(person3);
            world.AddPerson(person4);
            world.AddPerson(person5);
            world.AddPerson(person6);
            world.AddPerson(person7);


            //for(int i = 0; i < 10000; i++)
            //{
            //    Farmer personx = GenerateFarm(area, 20+i*100, 20, "Jim");
            //    world.AddPerson(personx);
            //}
            world.AddArea(area);

            return world;
        }

        private static void GenerateWell(Area area, int x, int y)
        {
            var well = new Well(Guid.NewGuid(), "Well", area, x, y, 20, 20);
            area.AddLocation(well);
        }

        private static ShopOwner GenerateShop(Area area, int x, int y, string name)
        {
            var shop = new Shop(Guid.NewGuid(), "Shop", area, x, y, 20, 20);
            var person = new ShopOwner(Guid.NewGuid(), name, shop);

            shop.Owner = person;

            person.AddOwnerShip(shop);
            shop.Inventory.AddResource(new WheatSeed(), 10000);
            area.AddLocation(shop);

            return person;
        }


        private static Baker GenerateBakery(Area area, int x, int y, string name)
        {
            var bakery = new Bakery(Guid.NewGuid(), "Bakery", area, x, y, 20, 20, true);
            var person = new Baker(Guid.NewGuid(), name, bakery);

            bakery.Owner = person;

            person.AddOwnerShip(bakery);
            person.Inventory.AddResource(new Coin(), 100);
            area.AddLocation(bakery);

            return person;
        }


        private static Miller GenerateMill(Area area, int x, int y, string name)
        {
            var mill = new Mill(Guid.NewGuid(), "Mill", area, x, y, 20, 20, true);
            var barn = new Barn(Guid.NewGuid(), "Barn", area, x + RandomSingleton.Instance.Random.Next(-10, 30), y + 20 + RandomSingleton.Instance.Random.Next(-5, 20), 10, 10);
            var person = new Miller(Guid.NewGuid(), name, mill);
            person.Inventory.AddResource(Constants.ResourceIdCoin, 100);
            mill.Owner = person;

            person.AddOwnerShip(mill);
            person.AddOwnerShip(barn);
            area.AddLocation(mill);
            area.AddLocation(barn);

            return person;
        }


        private static Farmer GenerateFarm(Area area, int x, int y, string name)
        {
           
            var farm = new Farm(Guid.NewGuid(), "Farm", area, x, y, 20, 20, true);
            var barn = new Barn(Guid.NewGuid(), "Barn", area, x + RandomSingleton.Instance.Random.Next(-10, 30), y+20 + RandomSingleton.Instance.Random.Next(-5,20), 10, 10);

            var person = new Farmer(Guid.NewGuid(), name, farm);
            var field = new Field(Guid.NewGuid(), "Field", area, x+30+ RandomSingleton.Instance.Random.Next(0, 40), y+30 + RandomSingleton.Instance.Random.Next(-100, 40), 10, 10);
            var field1 = new Field(Guid.NewGuid(), "Field1", area, x-40, y, 10, 10);
            var field2 = new Field(Guid.NewGuid(), "Field2", area, x, y-40, 10, 10);
            person.Inventory.AddResource(Constants.ResourceIdCoin, RandomSingleton.Instance.Random.Next(0, 10));
            farm.Owner = person;
            field.Owner = person;
            field1.Owner = person;
            field2.Owner = person;
            barn.Owner = person;

            person.AddOwnerShip(farm);
            person.AddOwnerShip(field);
            person.AddOwnerShip(field1);
            person.AddOwnerShip(field2);
            person.AddOwnerShip(barn);

            barn.Inventory.AddResource(new WheatSeed(), 100);

            area.AddLocation(farm);
            area.AddLocation(field);
            area.AddLocation(field1);
            area.AddLocation(field2);
            area.AddLocation(barn);
            return person;
        }

        public static void GenerateViews(World world)
        {
            Sprite personSprite = Resources.Load<Sprite>("Sprites/person");
            Sprite farmSprite = Resources.Load<Sprite>("Sprites/farm");
            Sprite fieldSprite = Resources.Load<Sprite>("Sprites/field");
            Sprite barnSprite = Resources.Load<Sprite>("Sprites/barn");
            Sprite shopSprite = Resources.Load<Sprite>("Sprites/shop");
            Sprite millSprite = Resources.Load<Sprite>("Sprites/mill");
            Sprite wellSprite = Resources.Load<Sprite>("Sprites/well");
            Sprite bakerySprite = Resources.Load<Sprite>("Sprites/bakery");

            foreach (var person in world.Persons)
            {
                GameObject gameObject = new GameObject();
                var renderer = gameObject.AddComponent<SpriteRenderer>();
              
                renderer.sprite = personSprite;

                var view = gameObject.AddComponent<PersonView>();
                view.SetModel(person);

            }

            foreach (var area in world.Areas)
            {
                foreach (var location in area.Locations)
                {
                    GameObject gameObject = new GameObject();
                    var renderer = gameObject.AddComponent<SpriteRenderer>();
                    if(location is Farm)
                    {
                        renderer.sprite = farmSprite;
                        gameObject.name = "farm";
                    }
                    else if(location is Barn)
                    {
                        renderer.sprite = barnSprite;
                    }
                    else if (location is Field)
                    {
                        renderer.sprite = fieldSprite;
                    }
                    else if (location is Shop)
                    {
                        Debug.Log("Add shop");
                        renderer.sprite = shopSprite;
                        gameObject.name = "shop";
                    }
                    else if (location is Mill)
                    {
                        renderer.sprite = millSprite;
                        gameObject.name = "mill";
                    }
                    else if (location is Bakery)
                    {
                        renderer.sprite = bakerySprite;
                        gameObject.name = "bakery";
                    }
                    else if (location is Well)
                    {
                        renderer.sprite = wellSprite;
                        gameObject.name = "well";
                    }
                    else
                    {
                        Debug.Log($"No sprite for {location.Id}");
                    }

                    var view = gameObject.AddComponent<LocationView>();
                    view.SetModel(location);
                }

            }
        }
    }
}
