using UnityEngine;


namespace Vagonetka
{
    public class MainGameController : MonoBehaviour
    {
        [SerializeField] private float _gravity;

        private PlayerModel _player;
        private LevelController _levelController;
        private InputController _inputController;
        private SaveDataRepo _saveData;
        private UIController _uiController;

        private void Start()
        {
            Physics.gravity = new Vector3(0, _gravity, 0);

            _player = FindObjectOfType<PlayerModel>();
            _levelController = FindObjectOfType<LevelController>();
            _inputController = FindObjectOfType<InputController>();
            _uiController = FindObjectOfType<UIController>();

            _saveData = new SaveDataRepo();
        }

        public void StartGame()
        {
            _levelController.LevelNumber = _saveData.LoadInt(SaveKeyManager.LevelNumber);

            _levelController.StartLevel();
            _inputController.ActivateController(true);
        }
        public void NextLevel()
        {
            _saveData.SaveData(_levelController.LevelNumber, SaveKeyManager.LevelNumber);

            _levelController.NextLevel();
        }

        public void IsLevelPassed(bool isPassed)
        {
            if (isPassed)
            {
                _uiController.EndGame(EndGameUIState.Win);
            }
            else
            {
                _uiController.EndGame(EndGameUIState.Lose);
            }
        }
    }
}
