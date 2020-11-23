using UnityEngine;
namespace Vagonetka
{
	public class BalanceModel : MonoBehaviour
	{
		public BalancePreset BalancePreset;
		private int CurrentLvlPreset;
		private int CurrentLvl;

		private void Start()
		{
			CurrentLvl = 1;
		}
		private void CountLvlPreset()
		{
			for (int i = 0; i < BalancePreset._LVLSettings.Length; i++)
			{
				if(CurrentLvl >= BalancePreset._LVLSettings[i].MaxLvl)
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
		public float CountSpeed()
		{
			return BalancePreset._LVLSettings[CurrentLvlPreset].LevelSettings.CartSpeed;
		}
		public int GetMaxAmountOfMissedGold()
		{
			return BalancePreset._LVLSettings[CurrentLvlPreset].LevelSettings.MaxAmountOfMissedGold;
		}
	}
}
