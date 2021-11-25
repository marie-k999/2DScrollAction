using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBoxController : MonoBehaviour
{
    public GameObject playerObj;
    PlayerController player;
    
    public GameObject openedTreasure;
    OpenSoundController openSoundScript;

    public GameObject toEndingObj;
    ToEndingController toEnding;

    // Start is called before the first frame update
    void Start()
    {
        player = playerObj.GetComponent<PlayerController>();
        openSoundScript = openedTreasure.GetComponent<OpenSoundController>();
        toEnding = toEndingObj.GetComponent<ToEndingController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            openedTreasure.SetActive(true);
            this.gameObject.SetActive(false);
            openSoundScript.PlayOpenSound();
            player.Goal();
            toEnding.ToEnding();
        }
    }
}
