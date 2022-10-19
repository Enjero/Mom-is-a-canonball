using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Animator transitionAnimation;
    public static MainMenu instancia;
    [SerializeField] float transitionTime = 1f;
    private void Awake()
    {
        if (instancia == null)
        {
            MainMenu.instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void cargarEscena1()
    {
        transitionAnimation.SetTrigger("StartTransition");
        Invoke("escena1", transitionTime);
    }
    void escena1()
    {
        SceneManager.LoadScene("Escena 1");
    }
    public void exit()
    {
        transitionAnimation.SetTrigger("StartTransition");
        Invoke("Quit", transitionTime);
    }
    private void Quit()
    {
        Application.Quit();
    }
    void Start()
    {
        transitionAnimation = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exit();
        }
    }
}
