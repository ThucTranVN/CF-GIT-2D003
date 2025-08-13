using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    private int currentHealth;
    [SerializeField]
    private int maxHealth;

    void Start()
    {
        currentHealth = maxHealth;

        if(UIManager.Instance != null)
        {
            UIManager.Instance.GamePanel.SetMaxHealth(maxHealth);
            UIManager.Instance.GamePanel.UpdateHealth(currentHealth);
        }
    }

    public void DamagePlayer(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.GamePanel.UpdateHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
