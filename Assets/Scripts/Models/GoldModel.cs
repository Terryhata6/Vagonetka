using UnityEngine;
using TapticPlugin;


namespace Vagonetka
{
    public class GoldModel : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private GoldCollector _goldCollector;
        private float _timeToDestroy = 3f;
        private bool _isActive;
        private bool _isCollected;


        private void OnTriggerEnter(Collider other)
        {
            _goldCollector = other.gameObject.GetComponent<GoldCollector>();
            if(_goldCollector != null && !_isCollected)
            {
                _isCollected = true;
                _goldCollector.PlaceGold(this.transform, this);
                _goldCollector.AddGold();
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
            if (!_isActive) return;
            _rigidbody.isKinematic = false;

            FindObjectOfType<SampleUI>().OnImpactClick(0);
            Invoke("MayBeDestroy", _timeToDestroy);
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

        private void MayBeDestroy()
        {
            if (_isCollected) return;
            Destroy(gameObject);
        }

        public bool IsActive()
        {
            return _isActive;
        }
    }
}
