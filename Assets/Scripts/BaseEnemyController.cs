using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyController : MonoBehaviour
{
    [SerializeField] GameObject rightWall;
    [SerializeField] GameObject leftWall;
    [SerializeField] float speed = 2.0f;

    Vector3 direction;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = rightWall.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards
            (transform.position, direction, step);
        if (this.transform.position.x == rightWall.transform.position.x)
        {
            direction = leftWall.transform.position;
        }
        else if(this.transform.position.x == leftWall.transform.position.x)
        {
            direction = rightWall.transform.position;
        }
        Turn();
    }

    void Turn()
    {
        if(direction == rightWall.transform.position)
        {
            //this.transform.Rotate(0f, 180f, 0f);
            transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        else if(direction == leftWall.transform.position)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }
    }
}