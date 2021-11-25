using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HumanEndMovieController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadEnding());
    }

    IEnumerator LoadEnding()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("HumanEnding");
    }
}
