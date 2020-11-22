using UnityEngine;


namespace Vagonetka
{
    public class LevelGatePreset : MonoBehaviour
    {
        [Header("Point for next level part")]
        [SerializeField] private GameObject _endPoint;

        public Vector3 GetPositionToNext()
        {
            return _endPoint.transform.position;
        }
    }
}
