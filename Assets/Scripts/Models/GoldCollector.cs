
using System.Collections.Generic;
using UnityEngine;

namespace Vagonetka
{
	public class GoldCollector : MonoBehaviour
	{
		public ParticleSystem[] GoldEffectParticles;
		public Light GoldEffectLight;
		public float GoldEffectRangeMax;

		private BalanceController _balanceModel;
		private List<Transform> _goldTransformList;
		[SerializeField] private int _goldCollected;
		[SerializeField] private int _minAmountOfGold;
		[SerializeField] private int _maxAmountOfGold;
		[SerializeField] private bool EnoughOfGoldCollected;

		private void Awake()
		{ 
			_balanceModel = FindObjectOfType<BalanceController>();
			_goldTransformList = new List<Transform>();
			for (int i = 0; i < GoldEffectParticles.Length; i++)
			{
				GoldEffectParticles[i].Pause();
			}
			GoldEffectLight.range = 0;
		}
		public void AddGold()
		{
			_goldCollected++;
			for (int i = 0; i < GoldEffectParticles.Length; i++)
			{
				GoldEffectParticles[i]. Play();
			}
			ActivateLightEffect();
			if (_goldCollected >= _minAmountOfGold)
			{
				EnoughOfGoldCollected = true;
			}
		}
		private void ActivateLightEffect()
		{
			for (int i = 0; i < GoldEffectRangeMax; i++)
			{
				Invoke("IncreaseLightRange", i * 0.01f);
			}
			for (int i = 0; i < GoldEffectRangeMax; i++)
			{
				Invoke("DecreaseLightRange", (GoldEffectRangeMax * 0.01f) + i * 0.01f);
			}
		}
		private void IncreaseLightRange()
		{
			GoldEffectLight.range++;
		}
		private void DecreaseLightRange()
		{
			GoldEffectLight.range--;
		}
		public void UpdateGoldNums(int AmountOfGoldOnScene)
		{
			_maxAmountOfGold = AmountOfGoldOnScene; 
			EnoughOfGoldCollected = false;
			_minAmountOfGold = _maxAmountOfGold - _balanceModel.GetMaxAmountOfMissedGold();
			_goldCollected = 0;

			GoldModel[] goldInChildren = GetComponentsInChildren<GoldModel>();
			foreach(GoldModel gold in goldInChildren)
            {
				Destroy(gold.gameObject);
            }

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
		//private void 
	}
}
