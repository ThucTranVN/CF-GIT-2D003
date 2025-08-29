using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject goStanding;
    [SerializeField]
    private GameObject goBall;
    [SerializeField]
    private BulletController bulletPrefab;
    [SerializeField]
    private GameObject bombPrefab;
    [SerializeField]
    private Transform shootPosition;
    [SerializeField]
    private Transform bombSpawnPosition;
    [SerializeField]
    private Rigidbody2D playerRb;
    [SerializeField]
    private LayerMask layerToCheck;
    [SerializeField]
    private Transform groundPoint;

    [SerializeField]
    private Animator animStandingState;
    [SerializeField]
    private Animator animBallState;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float dashSpeed;
    [SerializeField]
    private float dashTime;
    [SerializeField]
    private float becomeBallTime;

    [SerializeField]
    private SpriteRenderer playerSR;
    [SerializeField]
    private SpriteRenderer playerDashEffectSR;
    [SerializeField]
    private float dashEffectLifeTime;
    [SerializeField]
    private float timeBetweenEachDashEffect;
    [SerializeField]
    private float dashCoolDownTime;

    private float becomeBallCounter;
    private float dashCoolDownCounter;
    private float dashEffectCounter;
    private float dashCounter;
    private bool isOnGround;
    private bool isDoubleJump;

    private int speedParam = Animator.StringToHash("speed");
    private int ballSpeedParam = Animator.StringToHash("ballSpeed");
    private int isOnGroundParam = Animator.StringToHash("isOnGround");
    private int shotParam = Animator.StringToHash("shot");
    private int doubleJumpParam = Animator.StringToHash("doubleJump");

    [SerializeField]
    private PlayerAbilityTracker playerAbilityTracker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log($"speedParam {speedParam}");
        //Debug.Log($"isOnGroundParam {isOnGroundParam}");
        //Debug.Log($"shotParam {shotParam}");
        //Debug.Log($"doubleJumpParam {doubleJumpParam}");
    }

    // Update is called once per frame
    void Update()
    {
        if(dashCoolDownCounter > 0)
        {
            dashCoolDownCounter -= Time.deltaTime;
        }
        else
        {
            if (Input.GetButtonDown("Fire2")
                && goStanding.activeSelf
                && playerAbilityTracker.IsCanDash)
            {
                dashCounter = dashTime;
                ShowDashEffect();
            }
        }


        if(dashCounter > 0) //Player Dash
        {
            dashCounter -= Time.deltaTime;
            playerRb.linearVelocity = new Vector2(dashSpeed * transform.localScale.x, playerRb.linearVelocity.y);
            dashEffectCounter -= Time.deltaTime;
            if(dashEffectCounter <= 0)
            {
                ShowDashEffect();
            }
            dashCoolDownCounter = dashCoolDownTime;
        }
        else
        {
            //Move player
            float xAxis = Input.GetAxisRaw("Horizontal");
            playerRb.linearVelocity = new Vector2(xAxis * moveSpeed, playerRb.linearVelocity.y);

            //Change player direction
            if (playerRb.linearVelocityX < 0) //left
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (playerRb.linearVelocityX > 0) //right
            {
                transform.localScale = Vector3.one;
            }
        } 

        //Check player is on ground
        isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.2f, layerToCheck);

        //Player jump
        if (Input.GetButtonDown("Jump") && (isOnGround || (isDoubleJump && playerAbilityTracker.IsCanDoubleJump)))
        {
            if (isOnGround)
            {
                isDoubleJump = true;
            }
            else
            {
                animStandingState.SetTrigger(doubleJumpParam);
                isDoubleJump = false;
            }

            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, jumpForce);
        }

        //Shoot
        if (Input.GetButtonDown("Fire1"))
        {
            if (goStanding.activeSelf)
            {
                if (BulletManager.HasInstance)
                {
                    if (AudioManager.HasInstance)
                    {
                        AudioManager.Instance.PlaySE(AUDIO.SE_COLLECT);
                    }
                    BulletController bullet = BulletManager.Instance.GetBullet();
                    bullet.Active(shootPosition.position, new Vector2(transform.localScale.x, 0));
                    animStandingState.SetTrigger(shotParam);
                }
                
            }
            else if (goBall.activeSelf && playerAbilityTracker.IsCanDropBomb)
            {
                Instantiate(bombPrefab, bombSpawnPosition.position, bombSpawnPosition.rotation);
            }

        }

        //Ball mode
        if (!goBall.activeSelf)
        {
            if(Input.GetAxisRaw("Vertical") < -0.9f && playerAbilityTracker.IsCanBecomeBall)
            {
                becomeBallCounter -= Time.deltaTime;

                if(becomeBallCounter <= 0)
                {
                    goBall.SetActive(true);
                    goStanding.SetActive(false);
                }
            }
            else
            {
                becomeBallCounter = becomeBallTime;
            }
        }
        else
        {
            if (Input.GetAxisRaw("Vertical") > 0.9f)
            {
                becomeBallCounter -= Time.deltaTime;

                if (becomeBallCounter <= 0)
                {
                    goBall.SetActive(false);
                    goStanding.SetActive(true);
                }
            }
            else
            {
                becomeBallCounter = becomeBallTime;
            }
        }

        //Animation
        if (goStanding.activeSelf)
        {
            animStandingState.SetBool(isOnGroundParam, isOnGround);
            animStandingState.SetFloat(speedParam, Mathf.Abs(playerRb.linearVelocityX));
        }

        if (goBall.activeSelf)
        {
            animBallState.SetFloat(ballSpeedParam, Mathf.Abs(playerRb.linearVelocityX));
        }
    }

    private void ShowDashEffect()
    {
        SpriteRenderer spriteRenderer = Instantiate(playerDashEffectSR, transform.position, transform.rotation);
        spriteRenderer.sprite = playerSR.sprite;
        spriteRenderer.transform.localScale = transform.localScale;
        Destroy(spriteRenderer.gameObject, dashEffectLifeTime);
        dashEffectCounter = timeBetweenEachDashEffect;
    }
}
