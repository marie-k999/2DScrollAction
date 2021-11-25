using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public string objTag;
    [SerializeField] Vector2 deadSize;  //  踏まれた時のサイズ
    [SerializeField] GameObject player; //  プレイヤー
    [SerializeField] GameObject groundCheck; //  プレイヤーの足の部分
    PlayerController playerAttack;
    Collider2D playerCollider;

    bool playerStepOn = false; //   playerに踏まれたか
    BaseEnemyController bec;
    Collider2D colDamage;   //  攻撃時のコライダー(このオブジェクトについてる）
    [SerializeField] GameObject forCrash;   //  衝突時のコライダー用オブジェクト
    Collider2D colCrash;

    // Start is called before the first frame update
    void Start()
    {
        colDamage = GetComponent<Collider2D>();
        colCrash = forCrash.GetComponent<Collider2D>();
        bec = GetComponent<BaseEnemyController>();
        playerAttack = player.GetComponent<PlayerController>();
        //Debug.Log(playerAttack != null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        objTag = collision.gameObject.tag;
        Debug.Log(objTag);
        if (objTag == "FootAttack") //  上から踏まれたら
        {

           // playerAttack.Attack(this.gameObject.tag
            //プレイヤーの座標が敵座標より上だったら
            if (playerAttack.Attack(this.gameObject.tag))
            {
                Debug.Log("敵のY座標: " + transform.position.y);
                Debug.Log("プレイヤーのY座標: " + player.transform.position.y);
                Debug.Log(this.gameObject.tag);
                playerStepOn = true;
                ReceiveAttack();
                playerStepOn = false;
            }
            else
            {
                playerStepOn = false;
            }

        }
        //else if (objTag == "Player") //  横からぶつかったら
        {
            //CrashPlayer();
            /*int playerLife = playerAttack.GetLife();
            if (playerLife == 0)
            {
                Destroy(forCrash);
                Debug.Log("プレイヤーを倒した");
            }*/
            Debug.Log("敵にぶつかった");
        }
    }

    /*IEnumerator CrashPlayer()
    {
        int playerLife = playerAttack.GetLife();
        if (playerLife == 0)
        {
            yield return null;
            //Destroy(forCrash);
            Debug.Log("プレイヤーを倒した");
        }
        Debug.Log("敵にぶつかった");
    }*/

    void ReceiveAttack()
    {
        /*
         * コライダー2種類とも反応してしまうため、踏んだ時に敵にぶつかった時用の
         * コライダーをfalseにして反応しないようにする
        */
        if (playerStepOn)
        {
            colDamage.enabled = false;
            Destroy(forCrash);

            Debug.Log("敵を攻撃した");
            this.transform.localScale = deadSize;
            Invoke("IsDead", Time.deltaTime * 60.0f);
        }


    }

    private void IsDead()
    {
        Destroy(this.gameObject);
    }
}
