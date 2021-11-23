using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazardrising : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("game unit per second")]
    [SerializeField] float scrollrate = 0.2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, scrollrate * Time.deltaTime));
    }
}
