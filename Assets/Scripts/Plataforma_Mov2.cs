using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Mov2 : MonoBehaviour
{
    Rigidbody platamorma;
    public GameObject jugador;
    public GameObject jugador_Prueba;
    [SerializeField] Vector3 posicion;
    [SerializeField] Vector3 lados;
    [SerializeField] accion reaccion;
    Vector3 rangoB;
    Vector3 rangoC;
    Vector3 rangoD;
    [Range(0.2f, 50)]
    [SerializeField] float rango;
    [Range(0.2f, 50)]
    [SerializeField] float rangoA;
    [Range(0.2f, 5)]
    [SerializeField] float MargenError;
    float distancia;
    float distanciaB;
    float distanciaC;
    void traslado()
    {
        distancia = Vector3.Distance(transform.position, rangoB);
        if (reaccion == accion.movPositivo && distancia >= rango)
        {
            reaccion = accion.movLadoPos;
            rangoC = transform.position;
        }
        distanciaB = Vector3.Distance(transform.position, rangoC);
        if (reaccion == accion.movLadoPos && distanciaB >= rangoA)
        {
            reaccion = accion.movNegativo;
        }
        if (reaccion == accion.movNegativo && distancia <= rangoA + MargenError)
        {
            reaccion = accion.movLadoNeg;
            rangoD = transform.position;
        }
        distanciaC = Vector3.Distance(transform.position, rangoD);
        if (reaccion == accion.movLadoNeg && distanciaC >= rangoA)
        {
            reaccion = accion.movPositivo;
        }
    }
    enum accion
    {
        movPositivo,
        movNegativo,
        movLadoPos,
        movLadoNeg
    };
    void Start()
    {
        rangoB = transform.position;
        platamorma = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        traslado();
        switch (reaccion)
        {
            case accion.movPositivo:
                transform.Translate(posicion * Time.deltaTime);
                break;
            case accion.movNegativo:
                transform.Translate(-posicion * Time.deltaTime);
                break;
            case accion.movLadoPos:
                transform.Translate(lados * Time.deltaTime);
                break;
            case accion.movLadoNeg:
                transform.Translate(-lados * Time.deltaTime);
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jugador.gameObject.transform.SetParent(transform);
            jugador_Prueba.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jugador.gameObject.transform.SetParent(null);
            jugador_Prueba.gameObject.transform.SetParent(null);
        }
    }
}
