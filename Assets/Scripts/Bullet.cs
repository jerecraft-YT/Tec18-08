using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public int damageBullet;
    public float BulletSpeed = 3f;

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

        enemy.TakeDamage(damageBullet);

        Destroy(gameObject);
    }

}
