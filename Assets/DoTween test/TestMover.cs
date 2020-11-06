using UnityEngine;

public class TestMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotate;

    [SerializeField] private bool _isMoving;
    [SerializeField] private bool _isRotate;

    [SerializeField] private float _startYAngle;
    [SerializeField] private float _currentYAngle;

    private float _angle;
    private float _direction;

    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            Move();
        }
        if (_isRotate)
        {
            Rotate(1f, 90f);
        }
    }

    private void Move()
    {
        _player.transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }

    private void Rotate(float direction, float angle)
    {
        _currentYAngle = _player.transform.rotation.eulerAngles.y;

        _player.transform.Rotate(Vector3.up * Time.deltaTime * (_speedRotate * direction));

        if (direction == 1)
        {
            if (_currentYAngle - _startYAngle >= angle)
            {
                _isRotate = false;
                _startYAngle += angle * direction;
                _player.transform.rotation = Quaternion.Euler(_player.transform.rotation.eulerAngles.x, _startYAngle, _player.transform.rotation.eulerAngles.z);
            }
            else if (_currentYAngle >= 359f && _currentYAngle <= 359.9f)
            {
                _isRotate = false;
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
                _isRotate = false;
                _startYAngle += angle * direction;
                _player.transform.rotation = Quaternion.Euler(_player.transform.rotation.eulerAngles.x, _startYAngle, _player.transform.rotation.eulerAngles.z);
            }
            else if (_currentYAngle >= 0.1f && _currentYAngle <= 1f)
            {
                _isRotate = false;
                _startYAngle = 0f;
                _player.transform.rotation = Quaternion.Euler(_player.transform.rotation.eulerAngles.x, _startYAngle, _player.transform.rotation.eulerAngles.z);
                _currentYAngle = 0f;
            }
        }
    }
}
