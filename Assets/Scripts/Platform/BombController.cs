using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField]
    private float timeToExplode = 1f;
    [SerializeField]
    private float explosionRange;
    [SerializeField]
    private LayerMask layerToDestroy;
    [SerializeField]
    private GameObject explosionEffect;

    
    void Update()
    {
        timeToExplode -= Time.deltaTime;
        if (timeToExplode <= 0)
        {
            if(explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, transform.rotation);
            }

            Destroy(gameObject);

            Collider2D[] objectsToDestroy = Physics2D.OverlapCircleAll(transform.position, explosionRange, layerToDestroy);

            if(objectsToDestroy.Length > 0)
            {
                foreach(Collider2D col in objectsToDestroy)
                {
                    Destroy(col.gameObject);
                }
            }
        }
    }
}
