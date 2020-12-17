using UnityEngine;

namespace Vagonetka
{
	public class BalanceController : MonoBehaviour
	{
		public BalancePreset BalancePreset;
		[SerializeField] private int CurrentLvlPreset;
		[SerializeField] private int CurrentLvl;

		private void Start()
		{
			CurrentLvl = 0;
		}
		private void CountLvlPreset()
		{
			for (int i = 0; i < BalancePreset._LVLSettings.Length; i++)
			{
				if (CurrentLvl <= BalancePreset._LVLSettings[i].MaxLvl)
				{
					CurrentLvlPreset = i;
					break;
				}
			}
		}
		public void AddLvl()
		{
			CurrentLvl++;
			CountLvlPreset();
		}
		public void ZeroiseLvl()
		{
			CurrentLvl = 0;
			CountLvlPreset();
		}
		public float CountSpeed()
		{
			return BalancePreset._LVLSettings[CurrentLvlPreset].LevelSettings.CartSpeed;
		}/*
		public int GetMaxAmountOfMissedGold()
		{
			return BalancePreset._LVLSettings[CurrentLvlPreset].LevelSettings.MaxAmountOfMissedGold;
		}*/
	}
}