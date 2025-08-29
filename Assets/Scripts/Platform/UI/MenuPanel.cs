using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public void OnClickStartGame()
    {
        if (PlatformGameManager.HasInstance)
        {
            PlatformGameManager.Instance.StartGame();
        }
    }

    public void OnClickSetting()
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.SettingPanel.gameObject.SetActive(true);
        }
    }

    public void OnClickQuitGame()
    {
        if (PlatformGameManager.HasInstance)
        {
            PlatformGameManager.Instance.QuitGame();
        }
    }
}
