using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CambioEsc2 : MonoBehaviour
{
    Animator transitionAnimation;
    [SerializeField] float transitionTime = 1f;
    public void cargarEscena2()
    {
        transitionAnimation.SetTrigger("StartTransition");
        Invoke("escena2", transitionTime);
    }
    void escena2()
    {
        SceneManager.LoadScene("Escena 2");
    }
    // Start is called before the first frame update
    void Start()
    {
        transitionAnimation = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cargarEscena2();
        }
    }
}
