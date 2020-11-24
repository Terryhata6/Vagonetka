using UnityEngine;

namespace Vagonetka
{
	public class FinishTrigger : MonoBehaviour
	{
		private GoldCollector _goldCollector;
		private LevelController _levelController;
		private PlayerModel _playerModel;
		private TempUIController _tempUIController;

		private Vector3 StartVector;
		private void Start()
		{
			_levelController = FindObjectOfType<LevelController>();
			_goldCollector = FindObjectOfType<GoldCollector>();
			_tempUIController = FindObjectOfType<TempUIController>();
			_playerModel = FindObjectOfType<PlayerModel>();
			StartVector = new Vector3(0, 3, 75);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (_playerModel != null)
			{
				//TODO замутить отдельный класс под это дело
				_playerModel.IsMoving = false;
				if (_goldCollector.IsEnoughGoldCollected())
				{
					_tempUIController.ShowWinPanel();
					Invoke("StartNextLevel", 1f);
				}
				else
				{
					_tempUIController.ShowRestartPanel();
				}
			}
		}
		private void StartNextLevel()
		{
			_tempUIController.HideWinPanel();
			_goldCollector.ClearCollector();
			_levelController.ChangeLevel();
			_playerModel.transform.position = StartVector;
			_playerModel.IsMoving = true;
		}
	}
}
