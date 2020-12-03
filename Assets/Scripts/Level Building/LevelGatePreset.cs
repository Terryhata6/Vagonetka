using UnityEngine;


namespace Vagonetka
{
    public class LevelGatePreset : MonoBehaviour
    {
        [Header("Point for next level part")]
        [SerializeField] private GameObject _endPoint;

        [Header("Point for player")]
        [SerializeField] private GameObject _playerStartPoint;

        public Vector3 GetPositionToNext()
        {
            return _endPoint.transform.position;
        }
        public Vector3 GetPlayerStartPoint()
        {
            return _playerStartPoint.transform.position;
        }
    }
}
