using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
public class player : MonoBehaviour
{

    public int playerlive =100;
    bool isALive = true;
    Rigidbody2D myrb;
    Animator myamin;
    Collider2D mycollider2d;
    public float playerspeed = 150f;
    public float jump = 5f;
    public float climbspeed = 5f;
    float gravityscale;
    Vector2 deathspeed = new Vector2(1f,1f);
    public Text livehealth;
    // Start is called before the first frame update
    void Start()
    {
        livehealth.text = playerlive.ToString();
        myrb = GetComponent<Rigidbody2D>();
        myamin = GetComponent<Animator>();
        mycollider2d = GetComponent<Collider2D>();
        gravityscale = myrb.gravityScale;
        isALive = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isALive)
        {
            return;
        }
        Run();
        Jump();
        flipsprite();
        Climb();
        death();
        
    }
    public void Run()
    {
        float controlthrow = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        Vector2 playervelocity = new Vector2(controlthrow * playerspeed, myrb.velocity.y);
        myrb.velocity = playervelocity;
        bool run = Mathf.Abs(myrb.velocity.x) > Mathf.Epsilon;
        myamin.SetBool("run", run); ;
    }
    public void Jump()
    {
        if (!mycollider2d.IsTouchingLayers(LayerMask.GetMask("ground")))
        {
            return;
        }
        if (CrossPlatformInputManager.GetButtonDown("Jump")) 
        {
            Vector2 jumpvelocity = new Vector2(0f, jump);
            myrb.velocity += jumpvelocity;
        }
    }
    public void Climb()
    {
         if (!mycollider2d.IsTouchingLayers(LayerMask.GetMask("ladder")))
        {
            myamin.SetBool("climb", false);
            myrb.gravityScale = gravityscale;
            return;
        }
        float controlthrow = CrossPlatformInputManager.GetAxisRaw("Vertical");
        Vector2 clinbladder = new Vector2(myrb.velocity.x, controlthrow * climbspeed);
        myrb.velocity = clinbladder;
        myrb.gravityScale = 0f;
        bool climb = Mathf.Abs(myrb.velocity.y) > Mathf.Epsilon;
        myamin.SetBool("climb", climb);
    }
    void death()
    {
        if(myrb.IsTouchingLayers(LayerMask.GetMask("hazard")))
            
        {
            playerlive = playerlive - playerlive;
            livehealth.text = playerlive.ToString();
            isALive = false;
            myamin.SetTrigger("death");
            GetComponent<Rigidbody2D>().velocity = deathspeed;
            FindObjectOfType<gamesession>().Processpalyerdeath();
            Debug.Log("player death ");


        }
       if(myrb.IsTouchingLayers(LayerMask.GetMask("enemy")))


        {

            playerlive = playerlive - 10;
            livehealth.text = playerlive.ToString();

             if (playerlive < 0)
            {
                Debug.Log("player death "); 
                isALive = false;
             myamin.SetTrigger("death");
             GetComponent<Rigidbody2D>().velocity = deathspeed;
              FindObjectOfType<gamesession>().Processpalyerdeath();
             }


        }
        

    }
      public void flipsprite()
    {
        bool playerhashorizontalspeed = Mathf.Abs(myrb.velocity.x) > Mathf.Epsilon;
        if (playerhashorizontalspeed)
        {
            transform.localScale =new Vector2 (Mathf.Sign(myrb.velocity.x),1f) ;
        }
    }
    
      
    

}
