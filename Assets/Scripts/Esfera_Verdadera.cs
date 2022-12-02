using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esfera_Verdadera : MonoBehaviour
{
    [SerializeField] GameObject esto;
    bool pedo = false;
    void Update()
    {
        if (pedo == true && Input.GetKeyDown(KeyCode.Space))
        {
            Application.Quit();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            esto.SetActive(true);
            Time.timeScale = 0;
            pedo = true;
        }
    }
}
