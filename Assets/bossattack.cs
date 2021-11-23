using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossattack : MonoBehaviour
{
    int attackdamage = 10;
    Vector3 attackoffset;
    float attackrange = 1f;
    public LayerMask attackmask;
    player myplayer;
    public void Awake()
    {
        myplayer = FindObjectOfType<player>();
    }
    public void attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackoffset.x;
        pos += transform.up * attackoffset.y;
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackrange, attackmask);
        if(colInfo.IsTouchingLayers(LayerMask.GetMask("player")))
        {
            myplayer.playerlive = myplayer.playerlive - 10;
        }
        
    }
}
