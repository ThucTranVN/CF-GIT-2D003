using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField]
    private Animator bossAnim;
    [SerializeField]
    private BossHealthController bossHealthController;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private int healthThreshHoldPhase1;
    [SerializeField]
    private int healthThreshHoldPhase2;
    [SerializeField]
    private float activeTime;
    [SerializeField]
    private float disAppearTime;
    [SerializeField]
    private float inActiveTime;
    [SerializeField]
    private float timeBetweenShootPhase1;
    [SerializeField]
    private float timeBetweenShootPhase2;
    [SerializeField]
    private float moveSpeed;

    private float activeTimeCounter;
    private float disAppearTimeCounter;
    private float inActiveTimeCounter;
    private float shootCounter;
    private int VANISH_PARAM = Animator.StringToHash("vanish");

    [SerializeField]
    private Transform[] spawnPoints;
    private Transform targetPoint;

    [SerializeField]
    private Transform theBoss;

    void Awake()
    {
        bossHealthController = GetComponent<BossHealthController>();
        bossAnim = GetComponentInChildren<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activeTimeCounter = activeTime;
        shootCounter = timeBetweenShootPhase1;
    }

    // Update is called once per frame
    void Update()
    {
        if(bossHealthController.CurrentHealth > healthThreshHoldPhase1)
        {
            if(activeTimeCounter > 0)
            {
                activeTimeCounter -= Time.deltaTime;

                if(activeTimeCounter <= 0)
                {
                    disAppearTimeCounter = disAppearTime;
                    bossAnim.SetTrigger(VANISH_PARAM);
                }

                shootCounter -= Time.deltaTime;
                if(shootCounter <= 0)
                {
                    shootCounter = timeBetweenShootPhase1;
                    Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
                }
            }
            else if(disAppearTimeCounter > 0)
            {
                disAppearTimeCounter -= Time.deltaTime;
                if(disAppearTimeCounter <= 0)
                {
                    theBoss.gameObject.SetActive(false);
                    inActiveTimeCounter = inActiveTime;
                }
            }
            else if(inActiveTimeCounter > 0)
            {
                inActiveTimeCounter -= Time.deltaTime;
                if(inActiveTimeCounter <= 0)
                {
                    theBoss.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                    theBoss.gameObject.SetActive(true);
                    activeTimeCounter = activeTime;
                    shootCounter = timeBetweenShootPhase1;
                }
            }
        }
        else
        {
            if(targetPoint == null)
            {
                targetPoint = theBoss;
                disAppearTimeCounter = disAppearTime;
                bossAnim.SetTrigger(VANISH_PARAM);
            }
            else
            {
                if (Vector3.Distance(theBoss.position, targetPoint.position) > 0.2f)
                {
                    theBoss.position = Vector3.MoveTowards(
                        theBoss.position, targetPoint.position, moveSpeed * Time.deltaTime);

                    if (Vector3.Distance(theBoss.position, targetPoint.position) <= 0.2f)
                    {
                        disAppearTimeCounter = disAppearTime;
                        bossAnim.SetTrigger(VANISH_PARAM);
                    }

                    shootCounter -= Time.deltaTime;
                    if (shootCounter <= 0)
                    {
                        shootCounter = timeBetweenShootPhase2;
                        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
                    }
                }
                else if (disAppearTimeCounter > 0)
                {
                    disAppearTimeCounter -= Time.deltaTime;
                    if (disAppearTimeCounter <= 0)
                    {
                        theBoss.gameObject.SetActive(false);
                        inActiveTimeCounter = inActiveTime;
                    }
                }
                else if (inActiveTimeCounter > 0)
                {
                    inActiveTimeCounter -= Time.deltaTime;
                    if (inActiveTimeCounter <= 0)
                    {
                        theBoss.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;

                        targetPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                        int whileBreaker = 0;
                        while(targetPoint.position == theBoss.position && whileBreaker < 100)
                        {
                            targetPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                            whileBreaker++;
                        }

                        theBoss.gameObject.SetActive(true);

                        shootCounter = timeBetweenShootPhase2;
                    }
                }
            }

        }
    }
}
