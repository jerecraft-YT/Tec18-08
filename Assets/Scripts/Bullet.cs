using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private int damageBullet;
    [SerializeField] private float BulletSpeed = 3f;
    [SerializeField] private float timeLife;
    [SerializeField] private GameObject prefabParticleHit;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = transform.up * BulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            HitEnemy(collision);
        }
    }

    private void HitEnemy(Collider2D actualEnemy)
    {
        //codigo cuando choque con enemigo
        Enemy enemy = actualEnemy.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damageBullet);
        }
        else
        {
            Debug.LogWarning("Script de enemigo no asignado >:(");
        }

        SpawnParticle();

        Destroy(gameObject);
    }

    private void SpawnParticle()
    {
        if (prefabParticleHit == null) return;

        GameObject particleHit = Instantiate(prefabParticleHit,transform.position,Quaternion.identity);

        Destroy(particleHit, 1.25f);
    }

}
