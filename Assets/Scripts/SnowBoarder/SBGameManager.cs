using UnityEngine;
using UnityEngine.SceneManagement;

public class SBGameManager : MonoBehaviour
{
    [SerializeField]
    private float delayLoadScene = 1f;
    [SerializeField]
    private string sceneName = "SnowBoarder";

    public void ReloadScene()
    {
        Invoke(nameof(DelayLoadScene), delayLoadScene);
    }

    private void DelayLoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
