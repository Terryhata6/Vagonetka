using UnityEngine;


namespace Vagonetka
{
    public class LevelPartPreset : MonoBehaviour
    {
        [Header("Array of gold presets")]
        [SerializeField] private GoldPreset[] _goldPresetArray;
        
        [Header ("Point for next level part")]
        [SerializeField] private GameObject _endPoint;

        private int _goldPresetNumber;

        public void SetGoldPreset()
        {
            _goldPresetNumber = Random.Range(0, _goldPresetArray.Length);

            _goldPresetArray[_goldPresetNumber].gameObject.SetActive(true);
        }

        public GoldModel[] GetGoldArray()
        {
            return _goldPresetArray[_goldPresetNumber].GetGold();
        }

        public Vector3 GetPositionToNext()
        {
            return _endPoint.transform.position;
        }
    }
}