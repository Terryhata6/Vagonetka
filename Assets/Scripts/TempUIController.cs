using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Vagonetka
{
	public class TempUIController : MonoBehaviour
	{


		private GoldCollector _goldCollector;
		public Text ScoreText;
		public Text RestartScoreText;
		public GameObject PanelForNextLvl;
		public GameObject PanelForRestart;

		private void Start()
		{
			_goldCollector = FindObjectOfType<GoldCollector>();
		}
		//убрать
		public void ShowWinPanel()
		{
			PanelForNextLvl.SetActive(true);
			ScoreText.text = "Gold Collected " + _goldCollector.GetGoldCollected() + "/" + _goldCollector.GetMinAmountOfGold();
		}
		public void ShowRestartPanel()
		{
			PanelForRestart.SetActive(true);
			ScoreText.text = "Gold Collected " + _goldCollector.GetGoldCollected() + "/" + _goldCollector.GetMinAmountOfGold();
		}
		public void HideWinPanel()
		{
			PanelForNextLvl.SetActive(false);
		}
		public void RestartGame()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
