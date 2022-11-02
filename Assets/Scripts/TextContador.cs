using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextContador : MonoBehaviour
{
    [SerializeField] Text saltos;
    int contador = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        saltos.text = "Platadormas saltadas: " + contador;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "SobreSuelo")
        {
            contador++;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Cuadricula")
        {
            contador = 0;
        }
    }
}
