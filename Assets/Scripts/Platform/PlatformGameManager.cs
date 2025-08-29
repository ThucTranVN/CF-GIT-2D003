using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlatformGameManager : BaseManager<PlatformGameManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlayBGM(AUDIO.BGM_BGM_01);
        }

        Time.timeScale = 0;
    }

    public void StartGame()
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.GamePanel.gameObject.SetActive(true);
            UIManager.Instance.MenuPanel.gameObject.SetActive(false);
        }

        Time.timeScale = 1;
    }

    public void PauseGame()
    {

    }

    public void ResumeGame()
    {

    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("PlatformGame");
        if (UIManager.HasInstance)
        {
            UIManager.Instance.WinPanel.gameObject.SetActive(false);
            UIManager.Instance.LoosePanel.gameObject.SetActive(false);
        }

        if (RespawnManager.HasInstance)
        {
            RespawnManager.Instance.SetDefaultPosition();
            RespawnManager.Instance.Respawn();
        }
    }

    public void WinGame()
    {
        Time.timeScale = 0;
        if (UIManager.HasInstance)
        {
            UIManager.Instance.GamePanel.ActiveBossHealth(false);
            UIManager.Instance.WinPanel.gameObject.SetActive(true);
        }
    }

    public void LooseGame()
    {
        //Debug.Log($"Time before {Time.timeScale}");
        Time.timeScale = 0;
        //Debug.Log($"Time after {Time.timeScale}");
        if (UIManager.HasInstance)
        {
            UIManager.Instance.LoosePanel.gameObject.SetActive(true);
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
