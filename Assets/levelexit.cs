using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelexit : MonoBehaviour
{
    float levelloaddelay=2f;
     void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Loadnextlevel());

    }
    IEnumerator Loadnextlevel()
    {
        yield return new WaitForSecondsRealtime(levelloaddelay);
        var currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneindex + 1);
    }
}
