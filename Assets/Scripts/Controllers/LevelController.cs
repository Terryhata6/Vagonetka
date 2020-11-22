using UnityEngine;
using NaughtyAttributes;


namespace Vagonetka
{
    public class LevelController : MonoBehaviour
    {
        [ReorderableList] [SerializeField] private SceneCreator[] _kit;

        private GoldController _goldController;
        private SceneBuilder _builder;
        private int _levelNumber;

        private void Start()
        {
            _builder = FindObjectOfType<SceneBuilder>();
            _goldController = FindObjectOfType<GoldController>();

            _builder.BuildScene(_kit[_levelNumber]);
            _goldController.UpdateGoldList();
            _goldController.ActivateController(true);
        }

        public void ChangeLevel()
        {
            CleareLevel();

            _levelNumber++;

            if (_levelNumber < _kit.Length)
            {
                _builder.BuildScene(_kit[_levelNumber]);
            }
            else
            {
                _levelNumber = 0;
                _builder.BuildScene(_kit[_levelNumber]);
            }
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
    }
}
