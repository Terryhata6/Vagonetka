using System.Collections.Generic;
using UnityEngine;


namespace Vagonetka
{
	public class GoldController : MonoBehaviour
	{
		[SerializeField] private float _activateDistance;

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

				if (Mathf.Abs(_goldX - _playerX) <= _activateDistance || Mathf.Abs(_goldZ - _playerZ) <= _activateDistance)
				{
					_currentGold.Activate();
				}
				if (Mathf.Abs(_goldX - _playerX) <= 10f && Mathf.Abs(_goldZ - _playerZ) <= 10f)
				{
					SwitchNextGold();
				}
			}
		}

		public void UpdateGoldList()
		{
			_index = 0;
			//_goldList.Clear(); //этот метод вызывается в SceneBuilder
			_goldList = _listOfGold.GetListOfGold();
			_goldCollector.UpdateGoldNums(_goldList.Count);
			_currentGold = _goldList[_index];
		}

		public void SwitchNextGold()
		{
			_index++;
			if (_index < _goldList.Count)
			{
				_currentGold = _goldList[_index];
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
