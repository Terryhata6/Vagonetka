using UnityEngine;
using NaughtyAttributes;


namespace Vagonetka
{
    public class LevelController : MonoBehaviour
    {
        [ReorderableList] [SerializeField] private SceneCreator[] _kit;

        private MainGameController _mainController;
        private GoldController _goldController;
        private GoldCollector _goldCollector;
        private PlayerModel _player;
        private PlayerMovementController _playerMovement;
        private SceneBuilder _builder;
        private UIController _uiController;

        private int _levelNumber;
        public int LevelNumber
        {
            get => _levelNumber;
            set
            {
                _levelNumber = value;
            }
        }


        private void Start()
        {
            _mainController = FindObjectOfType<MainGameController>();
            _goldController = FindObjectOfType<GoldController>();
            _goldCollector = FindObjectOfType<GoldCollector>();
            _player = FindObjectOfType<PlayerModel>();
            _playerMovement = FindObjectOfType<PlayerMovementController>();
            _builder = FindObjectOfType<SceneBuilder>();
            _uiController = FindObjectOfType<UIController>();
        }

        private void CleareLevel()
        {
            LevelGatePreset[] gates = FindObjectsOfType<LevelGatePreset>();
            LevelPartPreset[] levelParts = FindObjectsOfType<LevelPartPreset>();

            for (int i = 0; i < gates.Length; i++)
            {
                Destroy(gates[i].gameObject);
            }

            for (int i = 0; i < levelParts.Length; i++)
            {
                Destroy(levelParts[i].gameObject);
            }
        }

        public void StartLevel()
        {
            CleareLevel();

            if (_levelNumber < _kit.Length)
            {
                _builder.BuildScene(_kit[_levelNumber]);
            }
            else
            {
                _levelNumber = 0;
                _builder.BuildScene(_kit[_levelNumber]);
            }
            
            _goldController.UpdateGoldList();
            _goldController.ActivateController(true);

            _player.StartLevel();
            _playerMovement.Restart();
        }

        public void NextLevel()
        {
            _levelNumber++;
            StartLevel();
        }

        public void FinishLevel()
        {
            _player.IsMoving = false;

            _mainController.IsLevelPassed(_goldCollector.IsEnoughGoldCollected());
            _uiController.EndGame();
        }
    }
}
