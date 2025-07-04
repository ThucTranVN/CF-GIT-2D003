using UnityEngine;

public class CarFollower : MonoBehaviour
{
    [SerializeField]
    private GameObject myCar;
    [SerializeField]
    private Vector3 offSet = new(0, 0, -10);

    // Update is called once per frame
    void Update()
    {
        if(myCar != null)
        {
            transform.position = myCar.transform.position + offSet;
        }
    }
}
