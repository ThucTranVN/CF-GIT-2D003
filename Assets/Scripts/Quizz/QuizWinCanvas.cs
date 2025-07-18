using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class QuizWinCanvas : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI winText;
    [SerializeField]
    private QuizScore quizScore;

    private void SetWinText()
    {
        winText.text = $"Congratulations! \nYour scored: {quizScore.GetScore()}%";
    }

    public void OnClickReplayButton()
    {
        SceneManager.LoadScene("QuizzGame");
    }

    public void OnClickExitButton()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

    private void OnEnable()
    {
        SetWinText();
    }
}
