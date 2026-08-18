using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento_Santiago : MonoBehaviour
{
    [SerializeField] private InputActionReference acInput;
    [SerializeField] private float velocidad = 10f;
    [SerializeField] private int vidaMaxima = 10;
    [SerializeField] private int vidaActual;

    private void Start()
    {
        vidaActual = vidaMaxima;
    }

    private void OnEnable()
    {
        if (acInput != null && acInput.action != null)
            acInput.action.Enable();
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
}