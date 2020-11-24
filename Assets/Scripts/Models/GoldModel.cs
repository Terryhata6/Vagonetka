using UnityEngine;


namespace Vagonetka
{
    public class GoldModel : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private GoldCollector _goldCollector;
        private bool _isActive;
        private bool _isCollected;


        private void OnCollisionEnter(Collision collision)
        {
            //TODO
            //Destroy(gameObject);
        }
        private void OnTriggerEnter(Collider other)
        {
            _goldCollector = other.gameObject.GetComponent<GoldCollector>();
            if(_goldCollector != null && !_isCollected)
            {
                _isCollected = true;
                _goldCollector.AddGold();
                _goldCollector.PlaceGold(this.transform, this);
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
        public void StopFalling(float time) 
        {
            Invoke("SetKinematic", time);
        }
        private void SetKinematic()
        {
            _rigidbody.isKinematic = true;
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
