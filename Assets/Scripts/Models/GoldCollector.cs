using System.Collections.Generic;
using TapticPlugin;
using UnityEngine;

namespace Vagonetka
{
	public class GoldCollector : MonoBehaviour
	{
		public ParticleSystem[] GoldEffectParticles;
		public Light GoldEffectLight;
		public float GoldEffectRangeMax;
		public int GoldCollectedBeforeInvisible;

		[SerializeField] private int _goldCollected;
		[SerializeField] private int _minAmountOfGold;
		[SerializeField] private int _maxAmountOfGold;
		[SerializeField] private bool EnoughOfGoldCollected;

		private Collider[] _collectedGoldColliders;
		private List<Transform> _goldTransformList;
		private SampleUI _taptic;

		private void Awake()
		{
			_goldTransformList = new List<Transform>();
			for (int i = 0; i < GoldEffectParticles.Length; i++)
			{
				GoldEffectParticles[i].Pause();
			}
			GoldEffectLight.range = 0;
			_collectedGoldColliders = new Collider[25];

			_taptic = FindObjectOfType<SampleUI>();
		}
		public void AddGold()
		{
			_taptic.OnImpactClick(2);
			_goldCollected++;
			for (int i = 0; i < GoldEffectParticles.Length; i++)
			{
				GoldEffectParticles[i].Play();
			}
			ActivateLightEffect();
			if (_goldCollected >= _minAmountOfGold)
			{
				EnoughOfGoldCollected = true;
			}
			if (_goldCollected >= GoldCollectedBeforeInvisible)
			{
				TurnCollidersOff();
			}
		}
		private void TurnCollidersOff()
		{
			for (int i = 0; i < _goldCollected - 2; i++)
			{
				_collectedGoldColliders[i].isTrigger = true;
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
			_minAmountOfGold = _maxAmountOfGold / 2;
			Debug.Log("_minAmountOfGold = " + _minAmountOfGold);
			_goldCollected = 0;

			GoldModel[] goldInChildren = GetComponentsInChildren<GoldModel>();
			foreach (GoldModel gold in goldInChildren)
			{
				Destroy(gold.gameObject);
			}

			_goldTransformList.Clear();
		}
		public bool IsEnoughGoldCollected()
		{
			Debug.Log("EnoughOfGoldCollected = " + EnoughOfGoldCollected);
			if (EnoughOfGoldCollected)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public void PlaceGold(Transform goldIngot, GoldModel goldModel)
		{
			goldIngot.parent = transform;
			_goldTransformList.Add(goldIngot);
			_collectedGoldColliders[_goldCollected] = goldIngot.gameObject.GetComponent<Collider>();
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
		public int GetMaxAmountOfGold()
		{
			return _maxAmountOfGold;
		}
	}
}
