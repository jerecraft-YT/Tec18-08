using Unity.Multiplayer.PlayMode;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
        
    public enum EnemyEnum
    {
        None, 
        Chase, // cooldown entre el disparo en attack
        Attack, //cuando ataca se deja de mover -> Enter the gungeon
        // cooldown entre el disparo en attack
        Dead
    }

    public Rigidbody2D rb;
    public EnemyEnum state = EnemyEnum.Chase;
    public Enemy ScriptEnemyHealth;
    public float speed;
    public float chaseSpeed;
    public float damage;

    public bool isAbleToAttack;
    private Vector3 basePos;
    public GameObject Target;

    void Start()
    {
       //toTrack the enemy from the Player script 
        basePos = transform.position;
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

        Vector3 myPos = transform.position;



        
    }




}
