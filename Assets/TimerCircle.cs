using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Vagonetka
{
    public class TimerCircle : MonoBehaviour
    {
        [SerializeField] private GameObject _camera;        
        [SerializeField] private float _rotationSpeed = 1.0f;
        private float _activateDistance;
        private GameObject _sprite;
        private PlayerModel _player;
        private float _distance;
        private float _temporalScale;
        private Vector3 _newScale;
        private Vector2 _playerVector2;
        private Vector2 _transformVector2;
        void Start()
        {
            _camera = FindObjectOfType<CameraController>().gameObject;
            _sprite = GetComponentInChildren<SpriteRenderer>().gameObject;
            _player = FindObjectOfType<PlayerModel>();
            _activateDistance = FindObjectOfType<GoldController>().ActivateDistance;
        }


        void Update()
        {
            _playerVector2.x = _player.transform.position.x;
            _playerVector2.y = _player.transform.position.z;
            _transformVector2.x = transform.position.x;
            _transformVector2.y = transform.position.z;

            transform.LookAt(_camera.transform.position);
            _distance = (_playerVector2 - _transformVector2).magnitude;
            _sprite.transform.Rotate(0,0,1);
            _temporalScale = 0.25f + 3.5f * _distance / _activateDistance;
            _newScale.x = _temporalScale;
            _newScale.y = _temporalScale;
            _newScale.z = _temporalScale;
            transform.localScale = _newScale;
        }
    }
}

