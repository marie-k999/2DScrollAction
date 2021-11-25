using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checker8Trigger : MonoBehaviour
{
    public Text dialogText;

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("hit");
        dialogText.text = "なあに、邪魔する奴は全部踏みつぶしてやればいいのさ！";
        Destroy(this.gameObject);
    }
}
