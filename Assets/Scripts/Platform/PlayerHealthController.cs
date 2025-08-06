using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    private int currentHealth;
    [SerializeField]
    private int maxHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void DamagePlayer(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
