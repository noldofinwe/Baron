using Assets.Source.Helpers;
using Assets.Source.Models;
using System;
using UnityEngine;

namespace Assets.Source
{
    public class Application : MonoBehaviour
    {
        private World _world = new World();

        void Start() 
        {
            Debug.Log("Starting Application");
            _world = TestWorldGenerator.Generate();
            TestWorldGenerator.GenerateViews(_world);
        }

        void Update()
        {
         
        }

        void FixedUpdate()
        {
            _world.Update();
        }

        public World World
        {
            get
            {
                return _world;
            }
        }
    }
}
