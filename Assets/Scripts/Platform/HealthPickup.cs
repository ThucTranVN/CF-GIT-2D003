using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField]
    private int healthPickupAmount;
    [SerializeField]
    private GameObject pickupEffect; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealthController playerHealth = collision.gameObject.GetComponentInParent<PlayerHealthController>();

            if(playerHealth != null)
            {
                playerHealth.HealPlayer(healthPickupAmount);
            }

            if(pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, transform.rotation);
            }

            Destroy(this.gameObject);
        }
    }
}
