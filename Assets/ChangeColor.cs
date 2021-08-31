using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public SpriteRenderer square;
    Coroutine the_routine;
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = start.position;
        square.color = Color.red;
        //StartCoroutine("ChangeColorToGreen");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (square.color == Color.green){
            transform.position = Vector2.Lerp(transform.position, end.position, Time.deltaTime);
        }
        if (square){
                StartCoroutine("ChangeColorToGreen");
                // if (square.color == Color.red){
                //     StopCoroutine("ChangeColorToGreen");

                // }
                

        }
        // StartCoroutine(ChangeColorToRed());
     
        // InvokeRepeating ("newColor", 10, 8);
        // square.color = Color.red;
    
    }
    void newColor(){
        square.color = Color.green;
    }

    IEnumerator ChangeColorToRed(){
        yield return new WaitForSeconds(8f);
        square.color = Color.red;
        
    }
    IEnumerator ChangeColorToGreen(){
        yield return new WaitForSecondsRealtime(10.0f);
        square.color = Color.green;
        yield return new WaitForSecondsRealtime(8.0f);
        square.color = Color.red;
        StartCoroutine("ChangeColorToGreen");
    }

    private void OnDrawGizmos(){
        Gizmos.DrawCube(start.position, Vector3.one*0.1f);
        Gizmos.DrawCube(end.position, Vector3.one*0.1f);
    }
}
