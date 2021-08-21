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
        square.color = Color.green;
        StartCoroutine("ChangeColorToRed");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (square.color == Color.red){
            transform.position = Vector2.Lerp(transform.position, end.position, Time.deltaTime);
        }
        //the_routine = StartCoroutine("ChangeColorToRed");
        //StartCoroutine("ChangeColorToGreen");
        //StopCoroutine(the_routine);
     
 
    
    }

    public IEnumerator ChangeColorToRed(){
        yield return new WaitForSeconds(5f);
        square.color = Color.red;
        yield return new WaitForSeconds(10f);
        square.color = Color.green;
    }
    public IEnumerator ChangeColorToGreen(){
        yield return new WaitForSeconds(10f);
        square.color = Color.green;
    }

    private void OnDrawGizmos(){
        Gizmos.DrawCube(start.position, Vector3.one*0.1f);
        Gizmos.DrawCube(end.position, Vector3.one*0.1f);
    }
}
