using UnityEngine;

public class DestroyObjectOvertime : MonoBehaviour
{
    [SerializeField]
    private float timeToDestroy;

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
