using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // （Player子オブジェクト）

    string groundTag = "Ground";
    bool isGround = false;  //接地フラグ渡し
    bool isGroundEnter, isGroundStay, isGroundExit;

    //接地判定を返すメソッド
    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        //　初期化
        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;

        return isGround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag) isGroundEnter = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)  isGroundStay = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)  isGroundExit = true;
    }
}
