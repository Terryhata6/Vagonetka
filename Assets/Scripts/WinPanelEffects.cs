using UnityEngine;

public class WinPanelEffects : MonoBehaviour
{
    public Animator[] StarsAnimators;
    private int _starNum;

    public void ActivateStars(float TimeDelay, int AmountOfStars)
    {
        _starNum = 0;
        for (int i = 0; i < AmountOfStars; i++)
        {
            Invoke("ActivateSingleStar", TimeDelay + 0.5f * i);
        }
    }
    private void ActivateSingleStar()
    {
        StarsAnimators[_starNum].SetTrigger("PopUp");
        StarsAnimators[_starNum].GetComponentInChildren<ParticleSystem>().Stop();
        StarsAnimators[_starNum].GetComponentInChildren<ParticleSystem>().Play();
        _starNum++;
    }
}
