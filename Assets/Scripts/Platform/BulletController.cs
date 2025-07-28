using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float BulletSpeed;
    [SerializeField]
    private Vector2 BulletDirection;
    [SerializeField]
    private Rigidbody2D BulletRb;
    [SerializeField]
    private GameObject impactEffect;

    // Update is called once per frame
    void Update()
    {
        BulletRb.linearVelocity = BulletDirection * BulletSpeed;
    }

    public void SetDirection(Vector2 newDirection)
    {
        BulletDirection = newDirection;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
