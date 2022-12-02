using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esfera_Falsa : MonoBehaviour
{
    [SerializeField] GameObject esto;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            esto.SetActive(false);
        }
    }
}
