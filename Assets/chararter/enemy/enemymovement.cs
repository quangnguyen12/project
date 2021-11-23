using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
     public Rigidbody2D myrb;
    public float movespeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        myrb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Isfacingright())
        {
            myrb.velocity = new Vector2(movespeed, 0f);
        }
        else  
        {
            myrb.velocity = new Vector2(-movespeed, 0f);
        }
        
    }
    bool Isfacingright()
    {
        return transform.localScale.x > 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myrb.velocity.x)), 1f);
    }
} 
