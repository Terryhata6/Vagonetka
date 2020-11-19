using UnityEngine;


namespace Vagonetka
{
    public class LevelPartPreset : MonoBehaviour
    {
        [Header("Array of gold presets")]
        [SerializeField] private GoldPreset[] _goldPresetArray;
        
        [Header ("Start/end points")]
        [SerializeField] private GameObject _startPoint;
        [SerializeField] private GameObject _endPoint;

        private int _goldPresetNumber;

        public void SetGoldPreset()
        {
            _goldPresetNumber = Random.Range(0, _goldPresetArray.Length);

            _goldPresetArray[_goldPresetNumber].gameObject.SetActive(true);
        }

        public Vector3 GetPositionToNext()
        {
            return _endPoint.transform.position;
        }
    }
}