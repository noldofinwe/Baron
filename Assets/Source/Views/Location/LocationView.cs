using Assets.Source.Models;
using UnityEngine;

namespace Assets.Source.Views
{
    public class LocationView : MonoBehaviour
    {
        private Location _locationModel;
        // Start is called before the first frame update
        void Start()
        {

        }

        public void SetModel(Location model)
        {
            _locationModel = model;
            gameObject.transform.position = new Vector3(_locationModel.X, _locationModel.Y, 5);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}