using UnityEngine;

namespace Vagonetka
{
	public class FinishTrigger : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			FindObjectOfType<LevelController>().FinishLevel();
		}
	}
}
