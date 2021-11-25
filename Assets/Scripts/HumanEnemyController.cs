using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanEnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    BaseEnemyController bec;
    int actionType;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        InvokeRepeating("DecideAction", 0.1f, 3.0f);
        bec = GetComponent<BaseEnemyController>();
        bec.enabled = false;
    }

    private void Update()
    {
        
    }

    void DecideAction()
    {
        actionType = Random.Range(0, 3);
        if (actionType == 0)
        {
            anim.SetBool("isMove", false);
            anim.SetBool("isAttack", false);
            anim.SetBool("isIdle", true);
        }
        else if (actionType == 1)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttack", false);
            anim.SetBool("isMove", true);
            
        }
        else if (actionType == 2)
        {
            if (this.gameObject.name == "Hunter")
            {
                anim.SetBool("isIdle", false);
                anim.SetBool("isMove", false);
                anim.SetBool("isAttack", true);
            }
            else
            {
                return;
            }
        }

        if (anim.GetBool("isMove") == false)
        {
            bec.enabled = false;
        }
        else
        {
            bec.enabled = true;
        }
    }
}
