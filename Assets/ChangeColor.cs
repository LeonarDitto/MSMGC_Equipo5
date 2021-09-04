using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public SpriteRenderer square;
    public Transform distance;
    Coroutine the_routine;
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    float endPost = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = start.position;
        square.color = Color.red;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        endPost = end.position.y;
        if (square.color == Color.green ){
            transform.position = Vector2.Lerp(transform.position, end.position, Time.deltaTime);
            
            
        }
        if (square.color == Color.red && transform.position.y > -1.7){
                transform.position = start.position;

            }

        if (transform.position.y + 0.2 >= endPost){
                //Debug.Log("Hola");
                transform.position = start.position;

        }
        //Debug.Log("End " + transform.position);
        //Debug.Log(transform.position);
        

        if (square){
                StartCoroutine("ChangeColorToGreen");

        }
       
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
        
        //Destroy(this);
        //transform.position = start.position;
    }
}
