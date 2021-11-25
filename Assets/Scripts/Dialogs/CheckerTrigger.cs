using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckerTrigger : MonoBehaviour
{
    public Text dialogText;

       void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("hit");
            dialogText.text = "ニンゲンともケモノともつかぬ姿になった気分はどう？";
            Destroy(this.gameObject);
        }
}
