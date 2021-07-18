using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleScript : MonoBehaviour
{
    public Transform player;

    public Animator playerAnims;

    public int walkSpeed = 5;
    public int runSpeed = 20;
    public int jumpHeight = 1;
    public int count;
    public int directionToTurn;

    public bool closeToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float distToPlayer = Vector3.Distance(this.transform.position, player.transform.position);
        
        if (distToPlayer < 5) {
            closeToPlayer = true;
        }
        else {
            closeToPlayer = false;
        }

        Idle();
    }

    void Idle()
    {
        walkSpeed = 0;
        runSpeed = 0;

        if (closeToPlayer) {
            Vector3 rotateTowardPlayer = new Vector3(player.transform.position.x,
           transform.position.y, player.transform.position.z);
            transform.LookAt(rotateTowardPlayer);
        }

        playerAnims.SetBool("isWalkingForward", false);
        playerAnims.SetBool("isRunningForward", false);
    }
}
