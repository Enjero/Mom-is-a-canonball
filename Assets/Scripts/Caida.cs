using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caida : MonoBehaviour
{
    [SerializeField] GameObject jugador;
    [SerializeField] GameObject point;
    Vector3 respawn;
    void Start()
    {
        respawn = point.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = respawn;
        }
    }
}
