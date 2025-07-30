using UnityEngine;

public class AbilityUnlock : MonoBehaviour
{
    public UnlockType UnlockType;

    
}

public enum UnlockType
{
    Unknown = 0,
    Doublejump,
    Dash,
    BecomeBall,
    DropBomb
}

