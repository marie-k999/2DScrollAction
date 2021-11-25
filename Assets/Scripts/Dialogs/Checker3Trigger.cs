using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checker3Trigger : MonoBehaviour
{
    public Text dialogText;

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("hit");
        dialogText.text = "中にある薬を飲めばちゃんと元の姿に戻れる";
        Destroy(this.gameObject);
    }
}
