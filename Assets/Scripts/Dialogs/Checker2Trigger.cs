using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checker2Trigger : MonoBehaviour
{
    public Text dialogText;

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("hit");
        dialogText.text = "僕の魔法を解きたければ、この先どこかにある宝箱を探すといいよ";
        Destroy(this.gameObject);
    }
}
