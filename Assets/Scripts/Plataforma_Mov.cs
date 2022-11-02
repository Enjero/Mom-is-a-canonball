using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Mov : MonoBehaviour
{
    Rigidbody platamorma;
    [SerializeField] Vector3 posicion;
    [SerializeField] accion reaccion;
    [SerializeField] float rayo = 0.5f;
    Vector3 rangoB;
    [Range(0.2f,10)]
    [SerializeField] float rango;
    float distancia;
    void traslado()
    {
        distancia = Vector3.Distance(transform.position, rangoB);
        if (rango <= distancia)
        {
            reaccion = accion.movNegativo;
        }
        if (reaccion == accion.movNegativo && distancia < 0.2f)
        {
            reaccion = accion.movPositivo;
        }
    }
    void playerDetected()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.up,out hit, rayo))
        {
            if (hit.transform.tag == "Player")
            {
                Debug.Log("Jugador tocado");
                //acá iría el metodo que mueve al jugador con la plataforma si supiera cómo indicarselo
            }
        }
    }
    /*[SerializeField] Vector3 giro;
    Quaternion giroB;
    [SerializeField] accion2 reaccion2;
    [Range(0, 5)]
    [SerializeField] float rotacionVel;
    [SerializeField] float angulo;
    void rotado()
    {
        if (giroB == new Quaternion(angulo,angulo,angulo,angulo) && reaccion2 == accion2.giroPos)
        {
            reaccion2 = accion2.giroNeg;
            //angulo = -angulo;
        }
    }*/
    enum accion
    {
        movPositivo,
        movNegativo
    };
    /*enum accion2
    {
        giroPos,
        giroNeg
    };*/
    void Start()
    {
        rangoB = transform.position;
        //giroB = transform.rotation;
        platamorma = GetComponent<Rigidbody>();
    }

    void Update()
    {
        traslado();
        switch (reaccion)
        {
            case accion.movPositivo:
                platamorma.AddForce(posicion*1000 * Time.deltaTime);
                break;
            case accion.movNegativo:
                platamorma.AddForce(-posicion*1000 * Time.deltaTime);
                break;
        }
        playerDetected();
        /*rotado();
        switch (reaccion2)
        {
            case accion2.giroPos:
                transform.Rotate(giro, rotacionVel);
                break;
            case accion2.giroNeg:
                transform.Rotate(giro, -rotacionVel);
                break;
        }*/
    }
}
