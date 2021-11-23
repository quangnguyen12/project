using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class heathpickup : MonoBehaviour
{
    player myplayer;
    public int healthbouns = 10;
    public Text life;
    
     void Awake()
    {
        myplayer = FindObjectOfType<player>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (myplayer.playerlive < 100)
        {

            myplayer.playerlive = myplayer.playerlive + healthbouns;
            life.text = myplayer.playerlive.ToString();
            Destroy(gameObject);


        }
    }
}
