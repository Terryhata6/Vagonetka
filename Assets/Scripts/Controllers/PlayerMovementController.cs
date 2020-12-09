using UnityEngine;

namespace Vagonetka
{
    public class PlayerMovementController : MonoBehaviour
    {
        [Header("Player speed")]
        [SerializeField] private float _speed;
        
        private float _rotateSpeed;
        private float _startYAngle;
        private float _currentYAngle;

        private PlayerModel _player;


        private void Start()
        {
            _player = FindObjectOfType<PlayerModel>();
            _rotateSpeed = _speed * 23.8f / 10f;
        }

        private void FixedUpdate()
        {
            if (_player.IsMoving)
            {
                Move();
            }
            if (_player.IsRotateRight)
            {
                Rotate(1f, 90f);
            }
            if (_player.IsRotateLeft)
            {
                Rotate(-1f, 90f);
            }
        }

        private void Move()
        {
            _player.transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }

        private void Rotate(float direction, float angle)
        {
            _currentYAngle = _player.transform.rotation.eulerAngles.y;

            _player.transform.Rotate(Vector3.up * Time.deltaTime * (_rotateSpeed * direction));

            if (direction == 1)
            {
                if (_currentYAngle - _startYAngle >= angle)
                {
                    _player.IsRotateRight = false;
                    _startYAngle += angle * direction;
                    _player.transform.rotation = Quaternion.Euler(_player.transform.rotation.eulerAngles.x, _startYAngle, _player.transform.rotation.eulerAngles.z);
                }
                else if (_currentYAngle >= 358f && _currentYAngle <= 359.9f)
                {
                    _player.IsRotateRight = false;
                    _startYAngle = 0f;
                    _player.transform.rotation = Quaternion.Euler(_player.transform.rotation.eulerAngles.x, _startYAngle, _player.transform.rotation.eulerAngles.z);
                }
            }

            if (direction == -1)
            {
                if (_startYAngle == 0)
                {
                    _startYAngle = 360;
                    _currentYAngle = 360;
                }

                if (_startYAngle - _currentYAngle >= angle)
                {
                    _player.IsRotateLeft = false;
                    _startYAngle += angle * direction;
                    _player.transform.rotation = Quaternion.Euler(_player.transform.rotation.eulerAngles.x, _startYAngle, _player.transform.rotation.eulerAngles.z);
                }
                else if (_currentYAngle >= 0.1f && _currentYAngle <= 2f)
                {
                    _player.IsRotateLeft = false;
                    _startYAngle = 0f;
                    _player.transform.rotation = Quaternion.Euler(_player.transform.rotation.eulerAngles.x, _startYAngle, _player.transform.rotation.eulerAngles.z);
                    _currentYAngle = 0f;
                }
            }
        }

        public void Restart()
        {
            _startYAngle = 0;
            _currentYAngle = 0;
        }
    }
}