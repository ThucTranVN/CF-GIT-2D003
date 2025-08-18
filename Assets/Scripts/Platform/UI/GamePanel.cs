using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    private Slider playerHealthSlider;

    private int maxHealth;

    public void SetMaxHealth(int maxHealthValue)
    {
        maxHealth = maxHealthValue;
        playerHealthSlider.maxValue = maxHealthValue;
    }

    public void UpdateHealth(int currentHealthValue)
    {
        playerHealthSlider.value = currentHealthValue;
    }

    public void ResetHealth()
    {
        UpdateHealth(maxHealth);
    }
}
