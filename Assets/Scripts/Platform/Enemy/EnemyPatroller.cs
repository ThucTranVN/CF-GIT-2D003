using UnityEngine;

public class EnemyPatroller : MonoBehaviour
{
    [SerializeField]
    private Transform[] patrolPoints;
    private int currentPoint;
    private float waitCounter;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float timeWaitAtPoint;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private Rigidbody2D enemyRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waitCounter = timeWaitAtPoint;

        foreach(Transform pPoint in patrolPoints)
        {
            pPoint.SetParent(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(patrolPoints.Length > 0)
        {
            if(Mathf.Abs(transform.position.x - patrolPoints[currentPoint].position.x) > 0.2f)
            {
                if(transform.position.x < patrolPoints[currentPoint].position.x)
                {
                    enemyRb.linearVelocity = new Vector2(moveSpeed, enemyRb.linearVelocity.y);
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                }
                else
                {
                    enemyRb.linearVelocity = new Vector2(-moveSpeed, enemyRb.linearVelocity.y);
                    transform.localScale = Vector3.one;
                }

                if(transform.position.y < patrolPoints[currentPoint].position.y)
                {
                    enemyRb.linearVelocity = new Vector2(enemyRb.linearVelocity.x, jumpForce);
                }
            }
            else
            {
                enemyRb.linearVelocity = new Vector2(0, enemyRb.linearVelocity.y);
                waitCounter -= Time.deltaTime;
                if(waitCounter <= 0)
                {
                    waitCounter = timeWaitAtPoint;
                    currentPoint++;
                    if(currentPoint >= patrolPoints.Length)
                    {
                        currentPoint = 0;
                    }
                }
            }
        }
    }
}
