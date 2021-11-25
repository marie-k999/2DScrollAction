using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // プレイヤー

    Rigidbody2D rb2d;
    Animator anim;
    SpriteRenderer spRenderer;      //反転のため

    //他のオブジェクト
    public GameObject sprite;       //子オブジェクトの取得

    GroundCheck groundCheck;
    public GameObject groundObject; //接地判定の取得

    PlayerSoundController soundController;
    public GameObject soundObject;  //サウンド

    UIController uIController;
    public GameObject uIObject;     //UI


    //数値系
    public float speed;     //左右移動
    public float speedJump; //ジャンプ

    public float stompUp;   //踏みつけアップ
    public float deadUp;    //ゲームオーバー

    const int DefaultLife = 3;
    const int MaxCherry = 10;

    int life;
    int cherry;
    int animalScore;
    int humanScore;
    
    bool isGrounded;        //接地フラグ
    bool isDamaged;         //無敵モード    
    bool isDead = false;
    bool isGoal = false;


    public int GetLife()
    {
        return life;
    }

    public int GetAnimalScore()
    {
        return animalScore;
    }
    
    public int GetHumanScore()
    {
        return humanScore;
    }


    // Start is called before the first frame update
    void Start()
    {
        // コンポーネントの取得
        rb2d = GetComponent<Rigidbody2D>();
        anim = sprite.GetComponent<Animator>();
        spRenderer = sprite.GetComponent<SpriteRenderer>();

        uIController = uIObject.GetComponent<UIController>();
        groundCheck = groundObject.GetComponent<GroundCheck>();
        soundController = soundObject.GetComponent<PlayerSoundController>();

        // 初期化
        life = DefaultLife;
        cherry = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");   //左右キー
        //float y = Input.GetAxisRaw("Vertical");     //上下キー
        //Vector2 force = new Vector2(x, y);

        // KeyUpで歩行時の慣性を止める
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) ||   //左
            Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))    //右
        {
            if (isGrounded) rb2d.velocity = Vector2.zero;
        }

        // スプライトの向きを変える（進行方向）
        if (x < 0 && !isGoal) spRenderer.flipX = true; 
        else if (x > 0) spRenderer.flipX = false;
        
        if (!isDead && !isGoal)
        {
            // 歩く
            rb2d.AddForce(Vector2.right * x * speed);
            anim.SetFloat("speed", Mathf.Abs(x * speed));

            if (Input.GetButtonDown("Jump")     //スペースキー
                && isGrounded)
            { 
                // ジャンプ
                anim.SetBool("isJump", true);
                GoUp(speedJump);
                soundController.SoundJump();
            }
        }

        if (isGrounded) //接地時のアニメ
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isFall", false);
        }

        float velX = rb2d.velocity.x;
        float velY = rb2d.velocity.y;

        // ジャンプ、落下時のアニメ
        if (velY > 1.0f && !isGrounded) anim.SetBool("isJump", true);   //(memo,0.5f)
        if (velY < -0.2f) anim.SetBool("isFall", true);                 //(memo,-0.1f)

        //ジャンプ時の進みすぎ補正
        if (Mathf.Abs(velX) > 5)
        {
            if (velX > 5.0f)　rb2d.velocity = new Vector2(5.0f, velY);
            if (velX < -5.0f)　rb2d.velocity = new Vector2(-5.0f, velY);
        }
    }

    private void FixedUpdate()
    {
        isGrounded = groundCheck.IsGround();
    }
    
    
    public void Goal()
    {
        isGoal = true;
        anim.SetFloat("speed", 0.0f);
        rb2d.velocity = Vector2.zero;
    }

    public bool GetItem(string item)            //アイテム側から呼び出し
    {
        bool isRecovery = false;    //アイテムサウンド管理のため

        switch (item) 
        {
            case "Cherry":

                if (cherry == MaxCherry - 1 && life == DefaultLife) break;

                cherry++;

                if (cherry >= MaxCherry)
                {
                    Recovery();
                    isRecovery = true;
                    cherry = 0;
                }

                uIController.CherryUISwitch(cherry);//渡し
                Debug.Log("cherry " + cherry);          //※debug
                break;

            case "Gem":
                if (life < DefaultLife)
                {
                    Recovery();
                    isRecovery = true;
                }
                break;

            default:
                break;
        }

        return isRecovery;
    }

    public bool Attack(string enemyTag)  //エネミー側から呼び出し
    {
        Debug.Log("enabled");                           //※debug

        float velY = rb2d.velocity.y;
        bool isFalling = false;

        if (velY < -0.2f)
        {
            isFalling = true;

            GoUp(stompUp);
            soundController.SoundStomp();

            switch (enemyTag) 
            {
                case "Animal":
                    animalScore++;
                    uIController.FactionUISwitch();//渡し
                    Debug.Log("animal:" + animalScore); //※debug
                    break;

                case "Human":
                    humanScore++;
                    uIController.FactionUISwitch();//渡し
                    Debug.Log("human:" + humanScore);   //※debug
                    break;

                default:
                    break;
            }
        }
        return isFalling;
    }


    void Recovery()     //回復
    {
        life++;
        uIController.LifeUISwitch(life);//渡し
        Debug.Log("life " + life);                      //※debug
        soundController.SoundRecovery();
    }

    void GoUp(float upSpeed)//アップ
    {
        rb2d.AddForce(Vector2.up * upSpeed);
    }

    void Dead()         //ゲームオーバー
    {
        if (!isDead)
        {
            groundObject.GetComponent<BoxCollider2D>().enabled = false;
            isDead = true;
            anim.SetBool("isDead", isDead);
            soundController.SoundGameOver();
            Debug.Log("GameOver");                      //※debug

            //跳ねて落ちていく
            sprite.GetComponent<CapsuleCollider2D>().enabled = false;
            if (transform.position.y > -8.5) GoUp(deadUp);
            rb2d.velocity = Vector2.zero;
        }
    }

    IEnumerator Damage()    //無敵モード※コライダーとの問題あり
    {
        isDamaged = true;

        yield return new WaitForSeconds(2.0f);  //待機
        
        isDamaged = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) //当たったか
    {
        if (collision.gameObject.tag == "Enemy")        //敵との接触
        {
            if (!isDamaged && !isDead)
            {
                StartCoroutine("Damage");

                life--;
                uIController.LifeUISwitch(life);//渡し
                Debug.Log("life " + life);              //※debug
                anim.SetTrigger("damage");
                soundController.SoundDamage();
            }
        }

        if (collision.gameObject.tag == "GameOverArea") //落ちた時
        {
            life = 0;
            uIController.LifeUISwitch(life);//渡し
        }

        //ライフが0になったらゲームオーバー
        if (life <= 0) Dead();
    }
}
