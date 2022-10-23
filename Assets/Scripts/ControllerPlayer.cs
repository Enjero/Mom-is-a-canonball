using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    //Player
    public Rigidbody jugador;
    //Movimiento
    float hor;
    float ver;
    [SerializeField] float speed = 9f;
    Vector3 mov;
    Vector3 mov2;
    void movimiento()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        mov = new Vector3(hor, 0, ver)*speed;
        mov2 = (mov.x * camRight + mov.z * camForward);
        jugador.AddForce(mov2);
    }
    //Salto
    [SerializeField] float fuerzaSalto = 8f;
    Vector3 vectirijillo;
    //Camara conjunto
    [SerializeField] Camera mainCamera;
    Vector3 camForward;
    Vector3 camRight;
    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
    //Programa
    void Start()
    {
        jugador = GetComponent<Rigidbody>();
    }

    void Update()
    {
        camDirection();
    }
    private void FixedUpdate()
    {
        movimiento();
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Suelo" && (collision.transform.position.y - transform.position.y) <= 0.5f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                vectirijillo = collision.transform.up;
                jugador.AddForceAtPosition(vectirijillo*fuerzaSalto,collision.transform.position ,ForceMode.Impulse);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.gameObject.tag == "SobreSuelo")
        {

        }
    }
}
