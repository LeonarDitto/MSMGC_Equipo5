using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorSecond : MonoBehaviour
{
    //Semaforo
    public SpriteRenderer square;
    //No necesario, se va a eliminar en un futuro.
    Coroutine the_routine;
    //Punto de inicio del auto
    [SerializeField] private Transform start;
    //Punto final del auto
    [SerializeField] private Transform end;
    float endPost = 0;
    
    void Start()
    {
        transform.position = start.position;
        //Todos los semaforos inician en rojo
        square.color = Color.red;
        
    }

    
    void Update()
    {
        endPost = end.position.x;
        //Mueve el auto si esta en verde
        if (square.color == Color.green){
            transform.position = Vector2.Lerp(transform.position, end.position, Time.deltaTime);
        }

        //Si esta adelante del semaforo en rojo, regresa a la posicion inicial
        if (square.color == Color.red && transform.position.x < 3.0){
                transform.position = start.position;

            }

        //Si llega al final del mapa, regresa al punto de inicio

        if (transform.position.x + 0.2 <= endPost){
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
        yield return new WaitForSecondsRealtime(18.0f);
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
