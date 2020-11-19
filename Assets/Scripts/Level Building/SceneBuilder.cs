using System.Collections.Generic;
using UnityEngine;


namespace Vagonetka
{
    public class SceneBuilder : MonoBehaviour
    {
        [SerializeField] private Vector3 _startPosition;
        public void BuildScene(SceneCreator sceneKit)
        {
            _startPosition = new Vector3(0, 0, 0);
            List<LevelPartPreset> someShit = new List<LevelPartPreset>();

            for (int i = 0; i < sceneKit.LevelPartsArray.Length; i++)
            {
                someShit.Add(Instantiate(sceneKit.LevelPartsArray[i], _startPosition, Quaternion.identity));
            }

            for (int i = 0; i < someShit.Count; i++)
            {
                if (i == 0)
                {
                    someShit[i].SetGoldPreset();
                }
                else
                {
                    someShit[i].transform.position = someShit[i - 1].GetPositionToNext();
                    someShit[i].SetGoldPreset();
                }
            }
        }
    }
}