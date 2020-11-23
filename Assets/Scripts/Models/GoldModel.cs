using UnityEngine;


namespace Vagonetka
{
    public class GoldModel : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private GoldCollector _goldCollector;
        private bool _isActive;


        private void OnCollisionEnter(Collision collision)
        {
            //TODO
            //Destroy(gameObject);
        }
        private void OnTriggerEnter(Collider other)
        {
            _goldCollector = other.gameObject.GetComponent<GoldCollector>();
            if(_goldCollector != null)
            {
                _goldCollector.AddGold();
                _goldCollector.PlaceGold(this.gameObject);
            }
        }

        public void Activate()
        {
            if (!_isActive)
            {
                _rigidbody = GetComponent<Rigidbody>();
                _rigidbody.isKinematic = true;
                _isActive = true;
            }

            //TODO визуальное свечение золота
        }

        public void Fall()
        {
            _rigidbody.isKinematic = false;
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public void SetMass(float mass)
        {
            _rigidbody.mass = mass;
        }
    }
}
