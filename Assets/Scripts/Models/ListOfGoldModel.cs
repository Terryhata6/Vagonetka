using UnityEngine;
using System.Collections.Generic;


namespace Vagonetka
{
    public class ListOfGoldModel : MonoBehaviour
    {
        [SerializeField] private List<GoldModel> _listOfGold;

        private void Awake()
        {
            _listOfGold = new List<GoldModel>();
        }

        public void AddGold(GoldModel[] goldArray)
        {
            _listOfGold.AddRange(goldArray);
        }

        public void ClearList()
        {
            _listOfGold.Clear();
        }

        public List<GoldModel> GetListOfGold()
        {
            return _listOfGold;
        }
    }
}
