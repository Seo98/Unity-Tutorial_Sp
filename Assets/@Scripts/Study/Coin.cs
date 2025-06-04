using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Movement.coinCount++;
            Debug.Log($"현재까지 {Movement.coinCount}코인 꺼억!");
            Destroy(gameObject); // Destroy the coin after collection
         
        }
    }
}
