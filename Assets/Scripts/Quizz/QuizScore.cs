using UnityEngine;
using TMPro;

public class QuizScore : MonoBehaviour
{
    [SerializeField]
    private QuizGameManager quizGameManager;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private int correctAnswers = 0;
    private int totalQuestion = 0;

    void Start()
    {
        totalQuestion = quizGameManager.GetTotalQuestion();
        DisplayScore();
    }

    public void IncrementCorrectAnswers()
    {
        correctAnswers++;
        //correctAnswers = correctAnswers + 1;
        //correctAnswers += 1;
    }

    public void DisplayScore()
    {
        //Debug.Log($"correctAnswers: {correctAnswers} - totalQuestion {totalQuestion}");
        //Debug.Log($"(correctAnswers/ totalQuestion): {(correctAnswers / (float)totalQuestion)}");
        scoreText.text = $"Score: {GetScore()}%";
    }

    public float GetScore()
    {
        return (correctAnswers / (float)totalQuestion) * 100;
    }
}
