using UnityEngine;


namespace Vagonetka
{
    public class LevelPartPreset : MonoBehaviour
    {
        //TODO Включение Декораций из массива декораций 

        [Header("Array of gold presets")]
        [SerializeField] private GoldPreset[] _goldPresetArray;
        
        [Header ("Point for next level part")]
        [SerializeField] private GameObject _endPoint;

        [Header("Array of decoration presets")]
        [SerializeField] private GameObject[] _decorPresetArray;

        private int _goldPresetNumber;
        private int _decorPresetNumber;

        public void SetGoldPreset()
        {
            _goldPresetNumber = Random.Range(0, _goldPresetArray.Length);

            _goldPresetArray[_goldPresetNumber].gameObject.SetActive(true);
        }

        public void SetDecorPreset()
        {
            _decorPresetNumber = Random.Range(0, _decorPresetArray.Length);

            _decorPresetArray[_decorPresetNumber].SetActive(true);
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