using UnityEngine;


namespace Vagonetka
{
    public class GoldPreset : MonoBehaviour
    {
        [SerializeField] private GoldModel[] _goldArray;

        public GoldModel[] GetGold()
        {
            return _goldArray;
        }
    }
}