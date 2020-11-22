using UnityEngine;


namespace Vagonetka
{
    public class GoldModel : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private bool _isActive;


        private void OnCollisionEnter(Collision collision)
        {
            //TODO
            Destroy(gameObject);
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
