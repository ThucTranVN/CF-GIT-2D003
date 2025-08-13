using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    private Slider playerHealthSlider;

    public void SetMaxHealth(int maxHealthValue)
    {
        playerHealthSlider.maxValue = maxHealthValue;
    }

    public void UpdateHealth(int currentHealthValue)
    {
        playerHealthSlider.value = currentHealthValue;
    }
}
