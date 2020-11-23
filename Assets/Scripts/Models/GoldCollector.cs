using Boo.Lang;
using System;
using UnityEngine;


namespace Vagonetka
{
	public class GoldCollector : MonoBehaviour
	{
		private BalanceModel _balanceModel;
		[SerializeField] private int _goldCollected;
		[SerializeField] private int _minAmountOfGold;
		[SerializeField] private int _maxAmountOfGold;
		[SerializeField] private bool EnoughOfGoldCollected;

		private void Start()
		{ 
			_balanceModel = FindObjectOfType<BalanceModel>();
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
			_goldCollected = 0;
			_minAmountOfGold = _maxAmountOfGold - _balanceModel.GetMaxAmountOfMissedGold();
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
		public void PlaceGold(GameObject GoldIngot)
		{
			Destroy(GoldIngot);
		}
	}
}
