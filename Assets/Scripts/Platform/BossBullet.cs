using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D bulletRb;
    [SerializeField]
    private GameObject impactEffect;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private int damageAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 direction = transform.position - BulletManager.Instance.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        bulletRb.linearVelocity = -transform.right * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthController playerHealth = collision.gameObject.GetComponentInParent<PlayerHealthController>();
            if(playerHealth != null)
            {
                playerHealth.DamagePlayer(damageAmount);
            }
        }

        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);

            Destroy(this.gameObject);
        }
    }
}
