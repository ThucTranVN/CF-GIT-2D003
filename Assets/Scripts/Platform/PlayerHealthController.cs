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

        if(UIManager.HasInstance)
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

    public void HealPlayer(int healthAmount)
    {
        currentHealth += healthAmount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (UIManager.HasInstance)
        {
            UIManager.Instance.GamePanel.UpdateHealth(currentHealth);
        }
    }

    public void DamagePlayer(int damageAmount)
    {
        if(invicCounter <= 0)
        {
            currentHealth -= damageAmount;

            if (UIManager.HasInstance)
            {
                UIManager.Instance.GamePanel.UpdateHealth(currentHealth);
            }

            if (currentHealth <= 0)
            {
                Instantiate(playerDeathEffect, transform.position, transform.rotation);

                //if(RespawnManager.HasInstance)
                //{
                //    RespawnManager.Instance.Respawn(SetMaxHealth);
                //}

                if (PlatformGameManager.HasInstance)
                {
                    PlatformGameManager.Instance.LooseGame();
                }
            }
            else
            {
                invicCounter = invicibilityTime;
            }
        }  
    }

    private void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
