using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStalker : MonoBehaviour
{
    Rigidbody stalker;
    [SerializeField] float speed = 700f;
    [SerializeField] GameObject jugador;
    [SerializeField] float rango = 2f;
    Vector3 algo;
    void Start()
    {
        stalker = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, jugador.transform.position);
        if (distance > rango)
        {
            stalker.AddForce(transform.forward * speed * Time.deltaTime);
            algo = transform.position;
        }
        else
        {
            transform.position = algo;
            transform.rotation = new Quaternion(0, 0, 0, 0f);
        }
        transform.LookAt(jugador.transform.position);

    }

}
