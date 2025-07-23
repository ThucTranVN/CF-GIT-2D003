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
    private Animator animStandingState;

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
        //Move player
        float xAxis = Input.GetAxisRaw("Horizontal");
        playerRb.linearVelocity = new Vector2(xAxis * moveSpeed, playerRb.linearVelocity.y);

        //Change player direction
        if(playerRb.linearVelocityX < 0) //left
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(playerRb.linearVelocityX > 0) //right
        {
            transform.localScale = Vector3.one;
        }

        //Check player is on ground
        isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.2f, layerToCheck);

        //Player jump
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, jumpForce);
        }


        //Animation
        animStandingState.SetBool("isOnGround", isOnGround);
        animStandingState.SetFloat("speed", Mathf.Abs(playerRb.linearVelocityX));
    }
}
