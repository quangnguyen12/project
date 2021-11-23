﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boosrun : StateMachineBehaviour
{ public float speed = 2.5f;
    Transform player;
    Rigidbody2D rb;
    boss myboss;
    float attackrage = 3f;
     //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player=GameObject.FindGameObjectWithTag("Player").transform;
         rb= animator.GetComponent<Rigidbody2D>();
        myboss = animator.GetComponent<boss>();
    }

     //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        myboss.lookatplayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
       Vector2 newpos = Vector2.MoveTowards(rb.position, target,speed*Time.fixedDeltaTime);
        rb.MovePosition(newpos);
        if(Vector2.Distance(player.position, rb.position) <= attackrage)
        {
            animator.SetTrigger("attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attack");
    }

    
}
