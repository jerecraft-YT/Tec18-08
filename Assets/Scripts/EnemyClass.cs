using UnityEngine;
public class SisEnemy : MonoBehaviour
{
    void Start()
    {
        Enemy skull = new Enemy();
        skull.EnemyName = "Skull";
        skull.Hp = 8;

        Enemy witch = new Enemy();
        skull.EnemyName = "RedWitch";
        skull.Hp = 70;

    }
    void Update()
    {
    }

    public class Enemy
    {
        public string EnemyName;
        public float Hp;

        public void TakeDamage(float damagePlayer)
        {
            Hp -= damagePlayer;
        }
        public void Death()
        { // morir cuando su vida llegue a cero elimando el objeto 
            if (Hp >= 0f)
            {
                // Destroy(GameObject); // mejorar linea
            }
        }






    }


}