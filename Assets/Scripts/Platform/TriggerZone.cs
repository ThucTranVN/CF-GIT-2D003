using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToActive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            objectToActive.SetActive(true);
            this.gameObject.SetActive(false);

            if (UIManager.HasInstance)
            {
                UIManager.Instance.GamePanel.ActiveBossHealth(true);
            }

        }
    }
}
