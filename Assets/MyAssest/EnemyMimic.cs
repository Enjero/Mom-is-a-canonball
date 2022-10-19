using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMimic : MonoBehaviour
{
    [SerializeField] GameObject jugador;
    Rigidbody mimetico;
    [SerializeField] float speed = 700f;
    [SerializeField] float rango = 2f;
    Vector3 otro;
    [SerializeField] copiarA enemigos;
    float distancia;
    void stalker()
    {
        if (distancia > rango)
        {
            mimetico.AddForce(transform.forward * speed * Time.deltaTime);
            otro = transform.position;
        }
        else
        {
            transform.position = otro;
            transform.rotation = new Quaternion(0, 0, 0, 0f);
        }
    }

    public enum copiarA
    {
        Saw,
        Stalker
    };
    // Start is called before the first frame update
    void Start()
    {
        //mimetico = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //copiarA enemigos;
        distancia = Vector3.Distance(transform.position, jugador.transform.position);
        switch (enemigos)
        {
            case copiarA.Saw:
                transform.LookAt(jugador.transform.position);
                break;

            case copiarA.Stalker:
                mimetico = GetComponent<Rigidbody>();
                stalker();
                transform.LookAt(jugador.transform.position);
                break;
        }
    }
}
