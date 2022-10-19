using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySaw : MonoBehaviour
{
    [SerializeField] GameObject jugador;
    void Start()
    {

    }
    void Update()
    {
        transform.LookAt(vectorJugador());
        Vector3 vectorJugador()
        {
            return Vector3.Lerp(transform.position, jugador.transform.position, 1);
        }
    }
}
