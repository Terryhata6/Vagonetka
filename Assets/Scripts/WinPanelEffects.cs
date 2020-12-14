using UnityEngine;
using TapticPlugin;
public class WinPanelEffects : MonoBehaviour
{
	public Animator[] StarsAnimators;
	[SerializeField] private int _starNum;
	private SampleUI _sampleUI;

	public void ActivateStars(float TimeDelay, int AmountOfStars)
	{
		_sampleUI = FindObjectOfType<SampleUI>();
		   _starNum = 0;
		/*for (int i = 0; i < AmountOfStars; i++)
		{
			Invoke("ActivateSingleStar", TimeDelay + 0.5f * i);
		}*/
		Debug.Log("AmountOfStars = " + AmountOfStars);
		switch (AmountOfStars)
		{
			case (1):
				Invoke("ActivateFirstStar", TimeDelay + 0.5f);
				break;
			case (2):
				Invoke("ActivateFirstStar", TimeDelay + 0.5f);
				Invoke("ActivateSecondStar", TimeDelay + 1f);
				break;
			case (3):
				Invoke("ActivateFirstStar", TimeDelay + 0.5f);
				Invoke("ActivateSecondStar", TimeDelay + 1f);
				Invoke("ActivateThirdStar", TimeDelay + 1.5f);
				break;
		}
	}
	private void ActivateFirstStar()
	{
		StarsAnimators[0].SetTrigger("PopUp"); 
		_sampleUI.OnImpactClick(1);
	}
	private void ActivateSecondStar()
	{
		StarsAnimators[1].SetTrigger("PopUp");
		_sampleUI.OnImpactClick(1);
	}
	private void ActivateThirdStar()
	{
		StarsAnimators[2].SetTrigger("PopUp");
		_sampleUI.OnImpactClick(1);
	}
}