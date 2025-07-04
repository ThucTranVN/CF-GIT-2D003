using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField]
    private float steerSpeed;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float slowSpeed;
    private float defaultSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //Debug.Log($"steerAmount: {steerAmount}");
        //Debug.Log($"moveAmount: {moveAmount}");
        transform.Rotate(0, 0, -steerAmount); //Apply rotation z
        transform.Translate(0, moveAmount, 0); //Apply postion y
    }

    public void SetSlowSpeed()
    {
        moveSpeed = slowSpeed;
    }

    public void ResetSpeed()
    {
        moveSpeed = defaultSpeed;
    }
}
