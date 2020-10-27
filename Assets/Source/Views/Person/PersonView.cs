using Assets.Source.Models;
using UnityEngine;

namespace Assets.Source.Views
{
    public class PersonView : MonoBehaviour
    {
        private PersonModel _personModel;
        // Start is called before the first frame update
        void Start()
        {

        }

        public void SetModel(PersonModel model)
        {
            _personModel = model;
            gameObject.transform.position = new Vector3(_personModel.X, _personModel.Y, 2);
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log("Update view");
            if (_personModel == null)
            {
                return;
            }

          
            gameObject.transform.position = new Vector3(_personModel.X, _personModel.Y, 2);
        }
    }
}