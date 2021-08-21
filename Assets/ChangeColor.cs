using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public SpriteRenderer square;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        square = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
 
     if (Time.time > nextActionTime ) {
            nextActionTime += period;
            // execute block of code here
            square.color = Color.green;
        }
 
    
    }
}
