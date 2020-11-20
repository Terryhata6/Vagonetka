using UnityEngine;

namespace Vagonetka
{
    [CreateAssetMenu(fileName = "SnapSettings", menuName = "CreateSO/SnapSettings")]
    public class SnapSettings : ScriptableObject
    {
        [Range(0.0f, 10.0f)]
        public float SnapDistance;
    }
}