using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    
    public GameObject Player; //objeto jugador

    private Vector3 offset;

    void Start ()
    {
        //adquiere la posicion de salida del jugador
        offset = transform.position - Player.transform.position;
    }
    
    void LateUpdate ()
    {
        //actuzliza la posicion de la camara a medida que se mueve el jugador
        transform.position = Player.transform.position + offset;
    }
}


