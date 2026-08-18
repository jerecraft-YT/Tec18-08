using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    public int CoinValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        //debug para mostrar cuanto obtuviste
        Debug.Log($"obtuviste {CoinValue}");

        Destroy(gameObject);
    }
}
