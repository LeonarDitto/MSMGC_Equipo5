using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorThird : MonoBehaviour
{
    public SpriteRenderer actualCar;
    public List<Sprite> newCars;
    //Semaforo
    public SpriteRenderer square;
    
    //Punto de inicio del auto
    [SerializeField] private Transform start;
    //Punto final del auto
    [SerializeField] private Transform end;
    float endPost = 0;
    private float timer = 0.0f;
    
    void Start()
    {
        transform.position = start.position;
        //Todos los semaforos inician en rojo
        square.color = Color.red;
        
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        endPost = end.position.y;
        //Mueve el auto si esta en verde
        if (square.color == Color.green){
            transform.position = Vector2.Lerp(transform.position, end.position, Time.deltaTime);
        }

        //Si esta adelante del semaforo en rojo, regresa a la posicion inicial
        if (square.color == Color.red && transform.position.y < 1.5){
            actualCar.sprite = newCars[Random.Range(0, 4)];
            transform.position = start.position;

            }

        //Si llega al final del mapa, regresa al punto de inicio

        if (transform.position.y + 0.2 <= endPost){
            actualCar.sprite = newCars[Random.Range(0, 4)];
            transform.position = start.position;

        }

        if (timer >= 21.0f){
            timer = 0;
        }

        
        newColor();
      
    
    }

    void newColor(){
        if (timer >= 10.0f && timer < 12.0f){
            square.color = Color.green;
        }
        if (timer >= 12.0f){
            square.color = Color.red;
        }
        
    }


    private void OnDrawGizmos(){
        Gizmos.DrawCube(start.position, Vector3.one*0.1f);
        Gizmos.DrawCube(end.position, Vector3.one*0.1f);
    }
}
