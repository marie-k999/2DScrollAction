using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checker7Trigger : MonoBehaviour
{
    public Text dialogText;

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("hit");
        dialogText.text = "生きているものはみんな敵だからね、フフッ";
        Destroy(this.gameObject);
    }
}
