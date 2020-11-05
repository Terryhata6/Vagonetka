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
            Rotate(Angles.Angle90, Directions.Left);
        }
    }

    private void Move()
    {
        _player.transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }

    private void Rotate(Angles angle, Directions direction)
    {
        if (direction == Directions.Right) _direction = 1f;
        else if (direction == Directions.Left) _direction = -1f;

        _currentYAngle = _player.transform.rotation.eulerAngles.y;

        _player.transform.Rotate(Vector3.up * Time.deltaTime * (_speedRotate * _direction));


    }

    //private void Rotate(float direction, float angle)
    //{
    //    _currentYAngle = _player.transform.rotation.eulerAngles.y;

    //    _player.transform.Rotate(Vector3.up * Time.deltaTime * (_speedRotate * direction));

    //    if (direction == 1)
    //    {
    //        if (_currentYAngle - _startYAngle >= angle * direction)
    //        {
    //            _isRotate = false;
    //            _startYAngle += angle * direction;
    //            _player.transform.rotation = Quaternion.Euler(_player.transform.rotation.eulerAngles.x, _startYAngle, _player.transform.rotation.eulerAngles.z);
    //        }
    //        else if (_currentYAngle >= 359f && _currentYAngle <= 359.9f)
    //        {
    //            _isRotate = false;
    //            _startYAngle = 0f;
    //            _player.transform.rotation = Quaternion.Euler(_player.transform.rotation.eulerAngles.x, _startYAngle, _player.transform.rotation.eulerAngles.z);
    //        }
    //    }
        
    //    if (direction == -1)
    //    {

    //    }
    //}
}
