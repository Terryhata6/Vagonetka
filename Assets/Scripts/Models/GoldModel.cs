using UnityEngine;
using TapticPlugin;


namespace Vagonetka
{
    public class GoldModel : MonoBehaviour
    {
        [SerializeField] private GameObject _rotatingObj;
        [SerializeField] private TimerCircle _circle;
        private Rigidbody _rigidbody;
        private GoldCollector _goldCollector;
        private float _timeToDestroy = 3f;
        private bool _isActive;
        private bool _isCollected;

        public GameObject RotatingObject
        {
            get => _rotatingObj;
        }


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
                _circle.gameObject.SetActive(true);
            }

            //TODO визуальное свечение золота
        }

        public void DeactivateCircle()
        {
            _circle.gameObject.SetActive(false);
        }

        public void Fall()
        {
            if (!_isActive) return;
            _circle.gameObject.SetActive(false);
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
