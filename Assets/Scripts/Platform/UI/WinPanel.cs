using UnityEngine;

public class WinPanel : MonoBehaviour
{
    public void OnClickQuitGame()
    {
        if (PlatformGameManager.HasInstance)
        {
            PlatformGameManager.Instance.QuitGame();
        }
    }

    public void OnClickRestart()
    {
        if (PlatformGameManager.HasInstance)
        {
            PlatformGameManager.Instance.RestartGame();
        }
    }

}
