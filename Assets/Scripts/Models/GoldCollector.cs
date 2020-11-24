using Boo.Lang;
using System;
using UnityEngine;

namespace Vagonetka
{
	public class GoldCollector : MonoBehaviour
	{
		private BalanceController _balanceModel;
		private List<Transform> _goldTransformList;
		[SerializeField] private int _goldCollected;
		[SerializeField] private int _minAmountOfGold;
		[SerializeField] private int _maxAmountOfGold;
		[SerializeField] private bool EnoughOfGoldCollected;

		private void Start()
		{ 
			_balanceModel = FindObjectOfType<BalanceController>();
			_goldTransformList = new List<Transform>();
		}
		public void AddGold()
		{
			_goldCollected++;
			if(_goldCollected >= _minAmountOfGold)
			{
				EnoughOfGoldCollected = true;
			}
		}
		public void UpdateGoldNums(int AmountOfGoldOnScene)
		{
			_maxAmountOfGold = AmountOfGoldOnScene; 
			EnoughOfGoldCollected = false;
			_minAmountOfGold = _maxAmountOfGold - _balanceModel.GetMaxAmountOfMissedGold();
			_goldCollected = 0;
			_goldTransformList.Clear();
		}
		public bool IsEnoughGoldCollected()
		{
			if (EnoughOfGoldCollected)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public void PlaceGold(Transform goldIngot , GoldModel goldModel)
		{
			goldIngot.parent = transform;
			_goldTransformList.Add(goldIngot);
			goldModel.StopFalling(2f);
		}
		public void ClearCollector()
		{
			for (int i = 0; i < _goldTransformList.Count; i++)
			{
				Destroy(_goldTransformList[i].gameObject);
			}
		}
		public int GetGoldCollected()
		{
			return _goldCollected;
		}
		public int GetMinAmountOfGold()
		{
			return _minAmountOfGold;
		}
	}
}
