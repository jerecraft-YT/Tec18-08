using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento_Santiago : MonoBehaviour
{
    [SerializeField] private InputActionReference acInput;
    [SerializeField] private InputActionReference gun;
    [SerializeField] private float velocidad = 10f;
    [SerializeField] private int vidaMaxima = 10;
    [SerializeField] private int vidaActual;
    [SerializeField] private Transform puntoDeDisparo;

    [SerializeField] private GameObject PrefabBullet;

    [SerializeField] private Animator player_animator;

    [SerializeField] private Transform player_direction;


    private Camera camaraPrincipal;

    private void Start()
    {
        vidaActual = vidaMaxima;
        camaraPrincipal = Camera.main;
    }

    private void OnEnable()
    {
        if (acInput != null && acInput.action != null)
            acInput.action.Enable();

        if (gun != null && gun.action != null)
        {
            gun.action.Enable();
            gun.action.performed += Disparar;
        }
    }

    private void OnDisable()
    {
        if (acInput != null && acInput.action != null)
            acInput.action.Disable();
    }

    void Update()
    {
        if (acInput == null || acInput.action == null) return;

        Vector2 idirection = acInput.action.ReadValue<Vector2>();
        float inputX = idirection.x;
        float nuevoX = transform.position.x + (inputX * velocidad * Time.deltaTime);

        transform.position = new Vector3(nuevoX, transform.position.y, transform.position.z);

        if (idirection != Vector2.zero)
        {
            if (idirection.x > 0)
            {
            player_direction.transform.localScale = Vector2.one;
            }
            else
            {
            player_direction.transform.localScale = new Vector2(-1, 1);
            }
            player_animator.SetBool("its_moving", true);
        }
        else
        {
            player_animator.SetBool("its_moving", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            RecibirDamage(1);
        }   
    }

    public void RecibirDamage(int damage)
    {
        vidaActual -= damage;
        Debug.Log("Vida restante: " + vidaActual);

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        Debug.Log("El jugador ha muerto");
        gameObject.SetActive(false);
    }

    private void Disparar(InputAction.CallbackContext context)
    {
        if (PrefabBullet == null) return;

        Vector3 posicionMousePantalla = Mouse.current.position.ReadValue();
        Vector3 posicionMouseMundo = camaraPrincipal.ScreenToWorldPoint(posicionMousePantalla);
        posicionMouseMundo.z = 0f;

        Vector3 origen = puntoDeDisparo != null ? puntoDeDisparo.position : transform.position;

        Vector2 direccion = (posicionMouseMundo - origen).normalized;

        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotacion = Quaternion.Euler(0, 0, angulo);

        Instantiate(PrefabBullet, origen, rotacion);
    }




}