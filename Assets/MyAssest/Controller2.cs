using UnityEngine;

public class Controller2 : MonoBehaviour
{
    //Movimiento
    [Range(0, 10)]
    [SerializeField] float speed = 5;
    [SerializeField] float angle = 5;
    [SerializeField] CharacterController jugador;
    float lados;
    float frentes;
    Vector3 jugadorInput;
    Vector3 moveJugador;
    void movimiento()
    {
        lados = Input.GetAxis("Horizontal");
        frentes = Input.GetAxis("Vertical");

        jugadorInput = new Vector3(lados, 0, frentes);
    }
    void direction()
    {
        moveJugador = (jugadorInput.x * camRight + jugadorInput.z * camForward);
        jugador.transform.LookAt(jugador.transform.position + moveJugador);
        jugador.Move(speed * Time.deltaTime * moveJugador);
    }
    void rotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(transform.position, Vector3.down, angle);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(transform.position, Vector3.up, angle);
        }
    }
    //Respecto a la camara
    [SerializeField] Camera mainCamera;
    Vector3 camForward;
    Vector3 camRight;
    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }


    void Start()
    {
        jugador = GetComponent<CharacterController>();
    }

    void Update()
    {
        movimiento();
        camDirection();
        direction();
        rotation();
    }
}
