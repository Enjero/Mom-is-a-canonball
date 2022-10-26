using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sustaine : MonoBehaviour
{
    public static Sustaine instancia;
    public string levelName = "Main Menu";
    public Stack nivelActual = new Stack();

    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake() //Para mantenerlo por todo el juego.
    {
        if (instancia == null)
        {
            Sustaine.instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }//Salir del juego con Escape.
        switch (levelName)
        {
            case "Main Menu":
                nivelActual.Push("Main Menu");
                break;
            case "Escena 1":
                nivelActual.Push("Escena 1");
                break;
            case "Escena 2":
                nivelActual.Push("Escena 2");
                break;
        }
    }
}
