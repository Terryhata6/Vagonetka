using System.Collections.Generic;
using UnityEngine;


namespace Vagonetka
{
    public class GoldPresetModel : MonoBehaviour
    {
        [SerializeField] private GoldModel[] _goldList;

        public GoldModel[] GetGold()
        {
            return _goldList;
        }
    }
}
