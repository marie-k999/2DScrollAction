using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checker9Trigger : MonoBehaviour
{
    public Text dialogText;

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("hit");
        dialogText.text = "きみに期待しているよ！行ってらっしゃい！";
        Destroy(this.gameObject);
    }
}
