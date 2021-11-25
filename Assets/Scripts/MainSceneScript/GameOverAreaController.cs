using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAreaController : MonoBehaviour
{
    public GameObject Controller;
    GameOverController script;
    public GameObject Camera;
    FollowCamera CameraScript;

    private void Start()
    {
        script = Controller.GetComponent<GameOverController>();
        CameraScript = Camera.GetComponent<FollowCamera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CameraScript.enabled = false;
            script.GameOver();
        }
    }
}
