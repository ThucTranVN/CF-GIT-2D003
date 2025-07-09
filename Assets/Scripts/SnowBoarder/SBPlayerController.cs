using UnityEngine;

public class SBPlayerController : MonoBehaviour
{
    [SerializeField]
    private float torqueAmount = 1f;
    [SerializeField]
    private float boostSpeed;
    [SerializeField]
    private float defaultSpeed;
    [SerializeField]
    private Rigidbody2D playerRB;
    [SerializeField]
    private SurfaceEffector2D surfaceEffector2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        ChangePlayerSpeed();
    }

    private void ChangePlayerSpeed()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Tang toc do
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            //Reset ve toc do ban dau
            surfaceEffector2D.speed = defaultSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("LeftArrow");
            playerRB.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("RightArrow");
            playerRB.AddTorque(-torqueAmount);
        }
    }
}
