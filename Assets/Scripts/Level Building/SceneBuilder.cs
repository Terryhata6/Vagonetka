using System.Collections.Generic;
using UnityEngine;


namespace Vagonetka
{
    public class SceneBuilder : MonoBehaviour
    {
        [SerializeField] private Vector3 _positionForStartGates;

        private ListOfGoldModel _listOfGold;
        private PlayerModel _player;

        private void Start()
        {
            _player = FindObjectOfType<PlayerModel>();
        }

        public void BuildScene(SceneCreator sceneKit)
        {
            if (_listOfGold == null)
            {
                _listOfGold = FindObjectOfType<ListOfGoldModel>();
            }

            _listOfGold.ClearList();

            LevelGatePreset startGate = Instantiate(sceneKit.StartGate);
            LevelGatePreset endGate = Instantiate(sceneKit.EndGate);
            List<LevelPartPreset> spawnedLevelParts = new List<LevelPartPreset>();

            _player.transform.position = startGate.GetPlayerStartPoint();
            _player.transform.rotation = Quaternion.identity;

            Vector3 firstLevelPartPosition = startGate.GetPositionToNext();

            for (int i = 0; i < sceneKit.LevelPartsArray.Length; i++)
            {
                spawnedLevelParts.Add(Instantiate(sceneKit.LevelPartsArray[i]));
            }

            for (int i = 0; i < spawnedLevelParts.Count; i++)
            {
                if (i == 0)
                {
                    spawnedLevelParts[i].transform.position = firstLevelPartPosition;
                    spawnedLevelParts[i].SetGoldPreset();
                    spawnedLevelParts[i].SetDecorPreset();
                    _listOfGold.AddGold(spawnedLevelParts[i].GetGoldArray());
                }
                else
                {
                    spawnedLevelParts[i].transform.position = spawnedLevelParts[i - 1].GetPositionToNext();
                    spawnedLevelParts[i].SetGoldPreset();
                    spawnedLevelParts[i].SetDecorPreset();
                    _listOfGold.AddGold(spawnedLevelParts[i].GetGoldArray());
                }
            }
            endGate.transform.position = spawnedLevelParts[spawnedLevelParts.Count - 1].GetPositionToNext();
        }
    }
}