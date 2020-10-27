using System;

namespace Assets.Source.Models
{
    public class Field : Location
    {
        private int fieldSize = 10;
        private int harvestTime = 2000;
        private int[] _seeded;
        private int[] _readyForHarvest;
        private bool _ready = false;
        private bool _isSeeded = false;

        public Field(Guid guid, string name, Area area, int x, int y, int width, int length) : base(guid, name, area, x, y, width, length, false)
        {
            _seeded = new int[fieldSize];
            _readyForHarvest = new int[fieldSize];
        }

        internal bool Harvest()
        {
            var doneHarvesting = true;
            for (int i = 0; i < fieldSize; i++)
            {
                if(_readyForHarvest[i] == 2000)
                {
                    _seeded[i]--;
                    if(_seeded[i] == 0)
                    {
                        _readyForHarvest[i] = 0;
                    }
                    doneHarvesting = false;
                    break;
                }

            }
            if(doneHarvesting)
            {
                _isSeeded = false;
                _ready = false;
            }
            return !doneHarvesting;
        }

        public override void Update()
        {
            if (!_ready)
            {
                var isReady = true;
                var isSeeded = true;
                for (int i = 0; i < fieldSize; i++)
                {
                    if (_seeded[i] == 10)
                    {
                        if (_readyForHarvest[i] < harvestTime)
                        {
                            _readyForHarvest[i]++;
                            isReady = false;
                        }

                    }
                    else
                    {
                        isReady = false;
                        isSeeded = false;
                    }
                }
                _ready = isReady;
                _isSeeded = isSeeded;
            }
        }


        public void Seed()
        {

            var doneSeeding = true;
            for (int i = 0; i < fieldSize; i++)
            {
                if (_seeded[i] < 10)
                {
                    _seeded[i]++;
                    doneSeeding = false;
                    break;

                }

            }
            _isSeeded = doneSeeding;

        }


        public bool IsReadyForHarvest()
        {
            return _ready;
        }

        public bool IsSeeded()
        {
            return _isSeeded;
        }
    }
}
