using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerRb;
    [SerializeField]
    private LayerMask layerToCheck;
    [SerializeField]
    private Transform groundPoint;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;

    private bool isOnGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        //Debug.Log($"xAxis: {xAxis}");
        playerRb.velocity = new Vector2(xAxis * moveSpeed, playerRb.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.2f, layerToCheck);
        Debug.Log($"isOnGround {isOnGround}");

        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        }
    }
}
