using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public Transform player;
    public bool isfilpped = false;
    public void lookatplayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z = -1f;
        if (transform.position.x >player.position.x && isfilpped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isfilpped = false;
        }
        if(transform.position.x < player.position.x && !isfilpped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isfilpped = true; 
        }
    }
    

}
