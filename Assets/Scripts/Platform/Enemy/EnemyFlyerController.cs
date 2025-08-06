using UnityEngine;

public class EnemyFlyerController : MonoBehaviour
{
    [SerializeField]
    private Transform playerTf;
    [SerializeField]
    private float chaseRange;
    [SerializeField]
    private float flySpeed;
    [SerializeField]
    private float turnSpeed;

    private bool isChasing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTf = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChasing)// Neu dang ko di chuyen toi player
        {
            //Tinh toan khoang cach toi player
            if(Vector3.Distance(transform.position, playerTf.position) < chaseRange)
            {
                isChasing = true;
            }
        }
        else
        {
            if(playerTf != null)
            {
                //Huong cua enemy va player
                Vector3 direction = transform.position - playerTf.position;
                //Goc giua enemy va player
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Debug.Log($"Angle {angle}");
                //Tinh toan goc xoay mong muon de xoay enemy
                //angle: gia tri goc xoay
                //axis: xoay quanh truc nao
                Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

                //thay doi gia tri rotation cua enemy
                //transform.rotation => goc xoay hien tai
                //targetRotatation => goc xoay mong muon
                //t: thoi gian xoay
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    turnSpeed * Time.deltaTime);

                //thay doi gia tri position cua enemy
                //current: position hien tai cua enemy
                //target: position hien tai cua player
                //t: thoi gian di chuyen tu current den target
                transform.position = Vector3.MoveTowards(current: transform.position,
                    target: playerTf.position,
                    flySpeed * Time.deltaTime);
            }
        }
    }
}
