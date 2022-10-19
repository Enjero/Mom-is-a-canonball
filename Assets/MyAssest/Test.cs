using UnityEngine;

public class Test : MonoBehaviour
{
    //Movimiento
    Vector3 jugadorInput;
    new Rigidbody rigidbody;
    [SerializeField] float speed = 5;
    void movimiento()
    {
        float lados = Input.GetAxis("Horizontal");
        float frentes = Input.GetAxis("Vertical");

        jugadorInput = new Vector3(lados, 0, frentes);

        rigidbody.MovePosition(transform.position + jugadorInput*Time.deltaTime*speed);
    }
    //Cambio de Tamaño
    Vector3 tamaño;
    Vector3 tamañoB;
    float cooldownPortal = 1.5f;
    float cooldownPortalB;
    void cooldown1()
    {
        if (cooldownPortal < cooldownPortalB)
        {
            cooldownPortal -= Time.deltaTime;
        }
        if (cooldownPortal <= 0)
        {
            cooldownPortal = cooldownPortalB;
        }
    }
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        tamaño = transform.localScale;
        tamañoB = transform.localScale;
        cooldownPortalB = cooldownPortal;
    }

    void Update()
    {
        movimiento();
        transform.localScale = tamaño;
        cooldown1();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject)
        {
            Debug.Log("Nombre: " + collision.transform.gameObject.name);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject)
        {
            Debug.Log("Nombre: " + other.transform.gameObject.name);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.tag == "Umbral" && tamaño == tamañoB && cooldownPortal == cooldownPortalB)
        {
            tamaño = tamaño * 0.5f;
            cooldownPortal--;
        }
        if (other.transform.gameObject.tag == "Umbral" && cooldownPortal == cooldownPortalB)
        {
            tamaño = tamañoB;
            cooldownPortal--;
        }      
    }
}
