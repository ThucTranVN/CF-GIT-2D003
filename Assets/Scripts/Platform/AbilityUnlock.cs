using UnityEngine;

public class AbilityUnlock : MonoBehaviour
{
    [SerializeField]
    private UnlockType unlockType;
    [SerializeField]
    private string unlockMessage;
    [SerializeField]
    private GameObject pickUpEffect;
    [SerializeField]
    private UnlockAbilityMessage unlockMessagePrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerAbilityTracker abilityTracker = collision.GetComponentInParent<PlayerAbilityTracker>();
            if(abilityTracker != null)
            {
                switch (unlockType)
                {
                    case UnlockType.Doublejump:
                        abilityTracker.IsCanDoubleJump = true;
                        break;
                    case UnlockType.Dash:
                        abilityTracker.IsCanDash = true;
                        break;
                    case UnlockType.BecomeBall:
                        abilityTracker.IsCanBecomeBall = true;
                        break;
                    case UnlockType.DropBomb:
                        abilityTracker.IsCanDropBomb = true;
                        break;
                    case UnlockType.Unknown:
                        Debug.LogWarning("Please set UnlockType in editor");
                        break;
                }

                Instantiate(pickUpEffect, transform.position, transform.rotation);
                UnlockAbilityMessage unlockAbilityMessage = Instantiate(
                    unlockMessagePrefab,
                    transform.position,
                    transform.rotation);
                unlockAbilityMessage.SetUnlockMessage(unlockMessage);
                Destroy(gameObject);
            }
        }
    }
}

public enum UnlockType
{
    Unknown = 0,
    Doublejump,
    Dash,
    BecomeBall,
    DropBomb
}

