using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToEndingController : MonoBehaviour
{
    public GameObject playerObj;
    PlayerController player;

    int animalScore;
    int humanScore;
    bool noKill;

    private void Start()
    {
        player = playerObj.GetComponent<PlayerController>();
        noKill = false;
    }

    public void ToEnding()
    {
        animalScore = player.GetAnimalScore();
        humanScore = player.GetHumanScore();
        if (animalScore == 0 && humanScore == 0) noKill = true;

        if (noKill)
        {
            FadeManager.Instance.LoadScene("Movie", 3.0f);
        }
        else if (animalScore >= humanScore)
        {
            FadeManager.Instance.LoadScene("AnimalEndMovie", 3.0f);
        }
        else
        {
            FadeManager.Instance.LoadScene("HumanEndMovie", 3.0f);
        }
    }
}
