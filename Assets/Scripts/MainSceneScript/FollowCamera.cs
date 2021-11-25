using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class FollowCamera : MonoBehaviour
{
    public GameObject playerObj;
    PlayerController player;
    Transform playerTransform;
    void Start()
    {
        player = playerObj.GetComponent<PlayerController>();
        playerTransform = playerObj.transform;
    }
    void LateUpdate()
    {
        MoveCamera();
    }
    void MoveCamera()
    {
        //  playerのxが1.83より小さいなら追従しない
        if (playerTransform.position.x < 1.83)
        {
            return;
        }
        //横方向だけ追従
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
}
