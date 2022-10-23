using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Animator transitionAnimation;
    public GameObject pasoNivel2;
    [SerializeField] float transitionTime = 1f; //tiempo que dura la transicion.
    public void trans() => transitionAnimation.SetTrigger("StartTransition");
    public void cargarEscena1()
    {
        trans();
        Invoke("escena1", transitionTime);
    }
    void escena1()
    {
        SceneManager.LoadScene("Escena 1");
    }//Está aparte para poder hacer uso del invoke y retrazarlo, dando espacio a la animación.
    public void exit()
    {
        trans();
        Invoke("Quit", transitionTime);
    }
    private void Quit() => Application.Quit();//Está aparte para poder hacer uso del invoke y retrazarlo, dando espacio a la animación.
    void Start()
    {
        transitionAnimation = GetComponentInChildren<Animator>();
    }
    void Update()
    {

    }
}
