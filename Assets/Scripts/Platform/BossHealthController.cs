using UnityEngine;

public class BossHealthController : MonoBehaviour
{
    private int currentHealth;
    [SerializeField]
    private int maxHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        if (UIManager.HasInstance)
        {
            UIManager.Instance.GamePanel.SetBossMaxHealth(maxHealth);
            UIManager.Instance.GamePanel.UpdateBossHealth(currentHealth);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (UIManager.HasInstance)
        {
            UIManager.Instance.GamePanel.UpdateBossHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            if (UIManager.HasInstance)
            {
                UIManager.Instance.GamePanel.ActiveBossHealth(false);
            }

            //Death
            Destroy(this.gameObject);
        }
    }
}
