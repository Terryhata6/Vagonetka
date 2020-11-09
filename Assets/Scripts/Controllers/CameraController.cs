using UnityEngine;


namespace Vagonetka
{
    public class CameraController : MonoBehaviour
    {
        [Header("Camera offset")]
        [SerializeField] private float _offsetX = 5;
        [SerializeField] private float _offsetY = 5;
        [SerializeField] private float _offsetZ = 5;

        private GameObject _player;
        private Transform _playerTransform;

        private void Start()
        {
            FindPlayer();
        }

        private void Update()
        {
            if (_playerTransform != null)
            {
                transform.position = new Vector3(_playerTransform.position.x - _offsetX, _playerTransform.position.y - _offsetY, _playerTransform.position.z - _offsetZ);
            }
            else
            {
                FindPlayer();
            }
        }

        private void FindPlayer()
        {
            _player = FindObjectOfType<PlayerModel>().gameObject;
            _playerTransform = _player.transform;
        }
    }
}