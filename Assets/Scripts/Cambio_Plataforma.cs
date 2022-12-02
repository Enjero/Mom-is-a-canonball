using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cambio_Plataforma : MonoBehaviour
{
    [SerializeField] GameObject Plataforma;
    [SerializeField] GameObject Plataforma2;
    [SerializeField] GameObject texto;
    [SerializeField] GameObject mierda;
    public bool pedo = false;
    public bool pedo2 = false;

    void Update()
    {
        if (pedo == true && Input.GetKeyDown(KeyCode.Space))
        {
            texto.SetActive(false);
            Time.timeScale = 1;
            mierda.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Plataforma.SetActive(false);
            Plataforma2.SetActive(true);
            Time.timeScale = 0;
            texto.SetActive(true);
            pedo = true;
        }
    }

}
