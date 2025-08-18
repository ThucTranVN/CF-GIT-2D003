using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    private int currentHealth;
    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private float invicibilityTime;
    private float invicCounter;

    [SerializeField]
    private float flashTime;
    private float flashCounter;

    [SerializeField]
    private SpriteRenderer[] playerSprites;

    [SerializeField]
    private GameObject playerDeathEffect;


    void Start()
    {
        currentHealth = maxHealth;

        if(UIManager.Instance != null)
        {
            UIManager.Instance.GamePanel.SetMaxHealth(maxHealth);
            UIManager.Instance.GamePanel.UpdateHealth(currentHealth);
        }
    }

    private void Update()
    {
        if(invicCounter > 0)
        {
            invicCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;

            if(flashCounter <= 0)
            {
                foreach (SpriteRenderer sprite in playerSprites)
                {
                    sprite.enabled = !sprite.enabled;
                }

                flashCounter = flashTime;
            }

            if(invicCounter <= 0)
            {
                foreach (SpriteRenderer sprite in playerSprites)
                {
                    sprite.enabled = true;
                }
                flashCounter = 0;
            }
        }
    }

    public void DamagePlayer(int damageAmount)
    {
        if(invicCounter <= 0)
        {
            currentHealth -= damageAmount;

            if (UIManager.Instance != null)
            {
                UIManager.Instance.GamePanel.UpdateHealth(currentHealth);
            }

            if (currentHealth <= 0)
            {
                Instantiate(playerDeathEffect, transform.position, transform.rotation);

                //Respawn:TODO
                gameObject.SetActive(false);
            }
            else
            {
                invicCounter = invicibilityTime;
            }
        }  
    }
}
