using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void GameOver()
    {
        StartCoroutine(WaitAndReturnToTitle());
    }

    private IEnumerator WaitAndReturnToTitle()
    {
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("Gameover");
    }
}
