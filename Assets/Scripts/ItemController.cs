using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // アイテム渡し

    public GameObject playerObj;
    PlayerController player;

    Animator anim;
    AudioSource getSound;

    private void Start()
    {
        player = playerObj.GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        getSound = GetComponent<AudioSource>();
    }

    IEnumerator ItemDestroy()
    {
        yield return new WaitForSeconds(1.0f);  //待機
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string itemTag = this.gameObject.tag;

        if (collision.gameObject.tag == "Player")
        {
            this.anim.SetBool("isSet", true);           //アニメーション

            bool isRecovery = player.GetItem(itemTag);  //プレイヤーのアイテム管理

            if (!isRecovery) getSound.Play();           //サウンド（回復時以外）

            StartCoroutine("ItemDestroy");              //削除
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
