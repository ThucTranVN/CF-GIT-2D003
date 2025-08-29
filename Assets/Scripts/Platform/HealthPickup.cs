using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private int healthPickupAmount;
    [SerializeField]
    private GameObject pickupEffect;

    void Start()
    {
        if (DataManager.HasInstance)
        {
            healthPickupAmount = DataManager.Instance.GlobalConfig.HealthPickupAmount;
        }
    }

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
