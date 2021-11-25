using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checker6Trigger : MonoBehaviour
{
    public Text dialogText;

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("hit");
        dialogText.text = "動物達から見てもバケモノ。";
        Destroy(this.gameObject);
    }
}