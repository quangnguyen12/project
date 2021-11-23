using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamesession : MonoBehaviour
{
    public int playerlive = 100;
    Rigidbody2D myrb;
    public Text life;
    private void Awake()
    {
        int numgamesession = FindObjectsOfType<gamesession>().Length;
        if (numgamesession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Processpalyerdeath()
    {
        if(playerlive > 1)
        {
            takelife();
        }
        else
        {
            resetgame();
        }
    }
    void resetgame()
    {
        playerlive = playerlive - playerlive;
       
        SceneManager.LoadScene(0);
        Destroy(gameObject);

    }
    void takelife()
    {
        playerlive = playerlive - 1;
        life.text = playerlive.ToString();
        var currentscence = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscence);
    }
    
}
