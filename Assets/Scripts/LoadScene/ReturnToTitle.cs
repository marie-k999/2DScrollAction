using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{
    public void OnTitleButtonClicked()
    {
        SceneManager.LoadScene("Title");
    }

    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }
}
