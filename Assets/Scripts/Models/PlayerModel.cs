using UnityEngine;


namespace Vagonetka
{
    public class PlayerModel : MonoBehaviour
    {
        public bool IsMoving;
        public bool IsRotateRight;
        public bool IsRotateLeft;

        [SerializeField] private GameObject _rightFrontWheel;
        [SerializeField] private GameObject _rightBackWheel;
        [SerializeField] private GameObject _leftFrontWheel;
        [SerializeField] private GameObject _leftBackWheel;

        private float _increaseNum = 0.1f;
        private float _tempXCoordinat;
        private float _tempZCoordinat;

        private float _speedMultiplier = 20f;


        public void StartLevel()
        {
            IsRotateLeft = false;
            IsRotateRight = false;
            IsMoving = true;
        }

        public void AlignByZ(float zCoordinate)
        {
            _tempZCoordinat = zCoordinate;
            if (zCoordinate > transform.position.z)
            {
                int num = (int)((zCoordinate - transform.position.z) / _increaseNum) + 1;
                for (int i = 0; i < num; i++)
                {
                    Invoke("IncreaseZCoordinat", 0.05f * i);
                }
            }
            else if (zCoordinate < transform.position.z)
            {
                Debug.Log(transform.position.z - zCoordinate);
                int num = (int)((transform.position.z - zCoordinate) / _increaseNum) + 1;
                for (int i = 0; i < num; i++)
                {
                    Invoke("DecreaseZCoordinat", 0.05f * i);
                }
            }
        }

        public void AlignByX(float xCoordinate)
        {
            _tempXCoordinat = xCoordinate;
            if (xCoordinate > transform.position.x)
            {
                int num = (int)((xCoordinate - transform.position.x) / _increaseNum) + 1;
                for (int i = 0; i < num; i++)
                {
                    Invoke("IncreaseXCoordinat", 0.05f * i);
                }
            } 
            else if(xCoordinate < transform.position.x)
            {
                int num = (int)((transform.position.x - xCoordinate) / _increaseNum) + 1;
                for (int i = 0; i < num; i++)
                {
                    Invoke("DecreaseXCoordinat", 0.05f * i);
                }
            }
        }
        private void IncreaseXCoordinat()
        {
            transform.position = new Vector3(transform.position.x + _increaseNum, transform.position.y, transform.position.z);
            if(transform.position.x > _tempXCoordinat)
            {
                transform.position = new Vector3(_tempXCoordinat, transform.position.y, transform.position.z);
            }
        }
        private void DecreaseXCoordinat()
        {
            transform.position = new Vector3(transform.position.x - _increaseNum, transform.position.y, transform.position.z);
            if(transform.position.x < _tempXCoordinat)
            {
                transform.position = new Vector3(_tempXCoordinat, transform.position.y, transform.position.z);
            }
        }
        private void IncreaseZCoordinat()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + _increaseNum);
            if(transform.position.z > _tempZCoordinat)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, _tempZCoordinat);
            }
        }
        private void DecreaseZCoordinat()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - _increaseNum);
            if(transform.position.z < _tempZCoordinat)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, _tempZCoordinat);
            }
        }

        public void Erondondon(float speed)
        {
            if (!_rightFrontWheel || !_rightBackWheel || !_leftFrontWheel || !_leftBackWheel) return;
            _rightFrontWheel.transform.Rotate(Vector3.up * Time.deltaTime * speed * _speedMultiplier);
            _rightBackWheel.transform.Rotate(Vector3.up * Time.deltaTime * speed * _speedMultiplier);
            _leftFrontWheel.transform.Rotate(Vector3.up * Time.deltaTime * speed * -_speedMultiplier);
            _leftBackWheel.transform.Rotate(Vector3.up * Time.deltaTime * speed * -_speedMultiplier);
        }
    }
}