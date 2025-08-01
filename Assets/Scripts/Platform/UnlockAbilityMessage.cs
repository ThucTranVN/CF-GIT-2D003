using UnityEngine;
using TMPro;

public class UnlockAbilityMessage : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI txtMessage;

    public void SetUnlockMessage(string message)
    {
        txtMessage.text = message;
    }
}
