using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Mov : MonoBehaviour
{
    Rigidbody platamorma;
    public GameObject jugador;
    [SerializeField] Vector3 posicion;
    [SerializeField] accion reaccion;
    Vector3 rangoB;
    [Range(0.2f,50)]
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
    enum accion
    {
        movPositivo,
        movNegativo
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
            }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jugador.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jugador.gameObject.transform.SetParent(null);
        }
    }
}
