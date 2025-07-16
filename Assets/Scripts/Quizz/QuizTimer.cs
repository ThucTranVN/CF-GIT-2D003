using UnityEngine;

public class QuizTimer : MonoBehaviour
{
    [SerializeField]
    private float timeToCompleteQuestion = 10f;
    [SerializeField]
    private float timeToShowCorrectAnswer = 5f;

    private float timerValue;
    private float fillFraction;
    public float FillFraction => fillFraction;
    public bool isLoadNextQuestion;
    public bool isAnsweringQuestion = false;

    void Update()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;  //10/10
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                isLoadNextQuestion = true;
            }
        }

        Debug.Log($"timerValue: {timerValue}");
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }
}
