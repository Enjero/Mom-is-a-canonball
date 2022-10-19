using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    //Pared dorada
    public float tiempoT = 0f;
    void teleport()
    {
        if (tiempoT >= 2)
        {
            transform.position = new Vector3(Random.Range(-18.5f,18.5f), 3, Random.Range(-16.41f,17.59f));
            transform.rotation = new Quaternion(transform.eulerAngles.z,Random.Range(0,360) ,transform.eulerAngles.z , transform.eulerAngles.y);
        }
    }
    void Start()
    {

    }
    void Update()
    {
        teleport();
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            tiempoT += Time.deltaTime;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            tiempoT = 0;
        }
    }
}
