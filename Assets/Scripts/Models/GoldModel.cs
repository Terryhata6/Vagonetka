using UnityEngine;


namespace Vagonetka
{
    public class GoldModel : MonoBehaviour
    {
        private Rigidbody _rigidbody;


        private void OnCollisionEnter(Collision collision)
        {
            //TODO
        }

        public void Activate()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;

            //TODO визуальное свечение золота
            //TODO активация слитка для Input
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
