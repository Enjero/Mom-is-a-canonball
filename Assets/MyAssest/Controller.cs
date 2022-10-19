using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Range (0,1000)]
    [SerializeField] float speed = 5f;
    [SerializeField] Vector3 alinear;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float lados = Input.GetAxis("Horizontal");
        float frentes = Input.GetAxis("Vertical");
        Vector3 vector = new Vector3(lados, 0.5f, frentes);
        rb.AddForce(vector * speed * Time.deltaTime);
        //rb.AddForce(-vector*Time.deltaTime);
        rb.AddTorque(-vector * Time.deltaTime*speed);
    }
}
