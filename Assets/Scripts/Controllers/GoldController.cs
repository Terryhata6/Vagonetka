﻿using System.Collections.Generic;
using UnityEngine;


namespace Vagonetka
{
	public class GoldController : MonoBehaviour
	{
		[SerializeField] private float _activateDistance;
		[SerializeField] private float _maxDelta = 5;

		[Header("Rotating active gold")]
		[SerializeField] private float _rotateSpeed = 20f;

		private ListOfGoldModel _listOfGold;
		private List<GoldModel> _goldList;
		private GoldModel _currentGold;
		private GoldCollector _goldCollector;
		private PlayerModel _player;
		private int _index = 0;

		private float _playerX;
		private float _playerZ;
		private float _goldX;
		private float _goldZ;

		private bool _isActive;

		public float ActivateDistance
		{
			get => _activateDistance;
		}

		private void Start()
		{
			_player = FindObjectOfType<PlayerModel>();
			_goldList = new List<GoldModel>();
			_listOfGold = FindObjectOfType<ListOfGoldModel>();
			_goldCollector = FindObjectOfType<GoldCollector>();

		}

		private void Update()
		{
			if (_isActive)
			{
				ComparePosition();
			}
		}

		private void ComparePosition()
		{
			if (_currentGold != null)
			{
				_playerX = _player.gameObject.transform.position.x;
				_playerZ = _player.gameObject.transform.position.z;
				_goldX = _currentGold.gameObject.transform.position.x;
				_goldZ = _currentGold.gameObject.transform.position.z;

				if (Vector3.Distance(_currentGold.transform.position, _player.transform.position) <= _activateDistance)
				{
					_currentGold.Activate();
					_currentGold.RotatingObject.transform.Rotate(Vector3.up, Time.deltaTime * _rotateSpeed);

				}
				if (Mathf.Abs(_goldX - _playerX) <= _maxDelta && Mathf.Abs(_goldZ - _playerZ) <= _maxDelta)
				{
					SwitchNextGold();
				}
			}
		}

		public void UpdateGoldList()
		{
			_index = 0;
			_goldList = _listOfGold.GetListOfGold();
			_goldCollector.UpdateGoldNums(_goldList.Count);
			_currentGold = _goldList[_index];
		}

		public void SwitchNextGold()
		{
			if (!_currentGold.IsActive()) return;
			_currentGold.DeactivateCircle();
			_index++;
			if (_index < _goldList.Count)
			{
				_currentGold = _goldList[_index];
			}
			else
            {
				_currentGold = null;
            }
		}

		public GoldModel GetCurrentGold()
		{
			return _currentGold;
		}

		public void ActivateController(bool condition)
		{
			_isActive = condition;
		}
	}
}
