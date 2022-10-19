using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCam : MonoBehaviour
{
    [SerializeField] GameObject jugador;
    [SerializeField] float sensibilidad = 2;
    Vector3 margen;
    void Start()
    {
        margen = transform.position - jugador.transform.position;
    }

    void Update()
    {
        transform.LookAt(jugador.transform.position);
        margen = Quaternion.AngleAxis (Input.GetAxis("Mouse X")*sensibilidad, Vector3.down)*margen;
        transform.position = jugador.transform.position + margen;
    }
}
