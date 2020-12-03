using UnityEngine;

namespace Vagonetka
{
    [CreateAssetMenu(fileName = "BalancePeset")]
    public class BalancePreset : ScriptableObject
    {
        public FewLVLPreset[] _LVLSettings;
    }
}
