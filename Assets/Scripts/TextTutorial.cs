using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTutorial : MonoBehaviour
{
    bool tuto;
    [SerializeField] GameObject texto;
    [SerializeField] GameObject texto1;
    [SerializeField] GameObject texto2;
    [SerializeField] GameObject texto3;
    [SerializeField] GameObject texto4;
    [SerializeField] GameObject texto5;
    [SerializeField] GameObject saltos;
    public int text = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && tuto == false) 
        {
            text++;
        }
        switch (text)
        {
            case 0:
                break;
            case 1:
                texto1.SetActive(false);
                texto2.SetActive(true);
                break;
            case 2:
                texto2.SetActive(false);
                texto3.SetActive(true);
                break;
            case 3:
                texto3.SetActive(false);
                texto4.SetActive(true);
                break;
            case 4:
                texto4.SetActive(false);
                texto5.SetActive(true);
                break;
            case 5:
                texto.SetActive(false);
                tuto = true;
                Time.timeScale = 1;
                saltos.SetActive(true);
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ("Player") && tuto == false)
        {
            Time.timeScale = 0;
            texto.SetActive(true);
            tuto = false;
        }
        
    }
}
