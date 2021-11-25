using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalCheckerTrigger : MonoBehaviour
{
    public void OnTriggerExit2D(Collider2D other)
    {
        SceneManager.LoadScene("Main");
    }
}
