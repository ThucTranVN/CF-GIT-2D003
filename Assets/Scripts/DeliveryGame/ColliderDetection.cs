using UnityEngine;

public class ColliderDetection : MonoBehaviour
{
    [SerializeField]
    private Color HasPackageColor;
    [SerializeField]
    private Color NoPackageColor;
    [SerializeField]
    private SpriteRenderer carRender;
    [SerializeField]
    private CarController carController;

    private bool hasPackage;

    private void Start()
    {
        carRender = GetComponent<SpriteRenderer>();
        carController = GetComponent<CarController>();
        //Debug.Log($"hasPackage: {hasPackage}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.gameObject.tag == "Package" && !hasPackage)// == if(hasPackage == false)
        {
            hasPackage = true;
            //Debug.Log($"hasPackage: {hasPackage}");
            Debug.Log($"Pickup package: {collision.gameObject.name}");
            carRender.color = HasPackageColor;
            Destroy(collision.gameObject, 2f);
        }

        if(collision.gameObject.tag == "Customer" && hasPackage)
        {
            Debug.Log($"Package delivered");
            hasPackage = false;
            carRender.color = NoPackageColor;
        }

        if(collision.gameObject.tag == "Booster")
        {
            if(carController != null)
            {
                carController.ResetSpeed();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        if(carController != null)
        {
            carController.SetSlowSpeed();
        }
    }


}
