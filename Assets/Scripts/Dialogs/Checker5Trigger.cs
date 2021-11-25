using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checker5Trigger : MonoBehaviour
{
    public Text dialogText;

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("hit");
        dialogText.text = "今のきみはニンゲンから見たらバケモノ。";
        Destroy(this.gameObject);
    }
}
