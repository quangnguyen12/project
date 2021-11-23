using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhp : MonoBehaviour
{
   
    public Rigidbody2D myrb;
    public Animator myanim;
    public int maxhealth = 50;
    int currenthealth;
    // Start is called before the first frame update
    void Start()
    {
        currenthealth=maxhealth;
    }

   public void takedamage(int damage)
    {
        currenthealth -= damage;
        myanim.SetTrigger("hurt");
        if (currenthealth <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        Debug.Log("Emeny died");
        myanim.SetBool("dead",true);
        gameObject.GetComponent<enemymovement>().enabled = false;//ham de disable script
        GetComponent<Collider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        // GetComponent<SpriteRenderer>().enabled = false;
        myrb.isKinematic=false;//disable rigidbody2d roi frezze 3 truc toa do x y z
        
        this.enabled = false;
    }
}
