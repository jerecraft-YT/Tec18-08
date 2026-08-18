using UnityEngine;
public class Enemy : MonoBehaviour
{
    public string EnemyName;
    public float Hp;

    public void TakeDamage(float damagePlayer)
    {
        Hp -= damagePlayer;
    }
    public void Death()
    {
        if (Hp >= 0f)
        {
            Destroy(gameObject); 
        }
    }






}
