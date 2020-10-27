using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Models
{
    public class RandomSingleton
    {
        private static RandomSingleton _instance = null;
        private Random _random;

        private RandomSingleton()
        {
            _random = new Random();
        }

        public static RandomSingleton Instance
        {
            get
            {
                // The first call will create the one and only instance.
                if (_instance == null)
                {
                    _instance = new RandomSingleton();
                }

                // Every call afterwards will return the single instance created above.
                return _instance;
            }
        }

        public Random Random { get { return _random; } }
    }
}
