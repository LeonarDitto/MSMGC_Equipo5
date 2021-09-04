using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorThird : MonoBehaviour
{
    public SpriteRenderer square;
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
        if (square.color == Color.green){
            transform.position = Vector2.Lerp(transform.position, end.position, Time.deltaTime);
        }

        if (square.color == Color.red && transform.position.y < 1.5){
                transform.position = start.position;

            }

        if (transform.position.y + 0.2 <= endPost){
                //Debug.Log("Hola");
                transform.position = start.position;

        }

        if (square){
                StartCoroutine("ChangeColorToGreen");

        }
      
    
    }

    public IEnumerator ChangeColorToRed(){
        yield return new WaitForSeconds(5f);
        square.color = Color.red;
        yield return new WaitForSeconds(10f);
        square.color = Color.green;
    }
    IEnumerator ChangeColorToGreen(){
        yield return new WaitForSecondsRealtime(20.0f);
        square.color = Color.green;
        yield return new WaitForSecondsRealtime(2.0f);
        square.color = Color.red;
        StartCoroutine("ChangeColorToGreen");
    }

    private void OnDrawGizmos(){
        Gizmos.DrawCube(start.position, Vector3.one*0.1f);
        Gizmos.DrawCube(end.position, Vector3.one*0.1f);
    }
}
