using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuizGameManager : MonoBehaviour
{
    [SerializeField]
    private List<QuizzSO> quizzes = new();
    [SerializeField]
    private QuizzSO currentQuizzSO;
    [SerializeField]
    private TextMeshProUGUI questionText;
    [SerializeField]
    private GameObject[] answerButtons;
    [SerializeField]
    private Sprite defaultSprite;
    [SerializeField]
    private Sprite correctSprite;
    [SerializeField]
    private Image timerImage;
    [SerializeField]
    private QuizTimer quizTimer;
    [SerializeField]
    private QuizScore quizScore;
    [SerializeField]
    private Slider progressSlider;
    [SerializeField]
    private TextMeshProUGUI progressText;

    private bool hasAnswered;
    private int currentProgess = 0;

    [SerializeField]
    private GameObject winCanvas;

    void Start()
    {
        progressSlider.maxValue = GetTotalQuestion();
        winCanvas.SetActive(false);
    }

    private void Update()
    {
        if(timerImage != null && quizTimer != null)
        {
            timerImage.fillAmount = quizTimer.FillFraction;

            if (quizTimer.isLoadNextQuestion)
            {
                hasAnswered = false;
                GetNextQuestion();
                quizTimer.isLoadNextQuestion = false;
            }
            else if(!hasAnswered && !quizTimer.isAnsweringQuestion)
            {
                DisplayAnswer(-1);
                SetButtonState(false);
            }
        }
    }

    public int GetTotalQuestion()
    {
        return quizzes.Count;
    }

    private void DisplayQuestion()
    {
        questionText.text = currentQuizzSO.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI answerText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            answerText.text = currentQuizzSO.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        Debug.Log($"OnAnswerSelected {index}");

        hasAnswered = true;
        quizTimer.CancelTimer();
        DisplayAnswer(index);
        SetButtonState(false);
    }

    private void DisplayAnswer(int index)
    {
        if (index == currentQuizzSO.GetCorrectAnswerIndex()) //Tra loi dung
        {
            questionText.text = "Correct!";
            Image btnImage = answerButtons[index].GetComponent<Image>();
            btnImage.sprite = correctSprite;
            quizScore.IncrementCorrectAnswers();
            quizScore.DisplayScore();
        }
        else //Tra loi sai
        {
            int correctAnswerIndex = currentQuizzSO.GetCorrectAnswerIndex();
            string correctAnswer = currentQuizzSO.GetAnswer(correctAnswerIndex);
            questionText.text = $"Sorry, the correct answer was: {correctAnswer}";
            Image btnImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            btnImage.sprite = correctSprite;
        }
    }

    private void GetNextQuestion()
    {
        if(quizzes.Count > 0)
        {
            currentProgess++;
            progressSlider.value = currentProgess;
            progressText.text = $"Current progress: {currentProgess}/{progressSlider.maxValue}";
            ResetButtonsSprite();
            SetButtonState(true);
            GetRandomQuestion();
            DisplayQuestion();
        }
        else
        {
            winCanvas.SetActive(true);
        }
    }

    private void GetRandomQuestion()
    {
        int randomIndex = Random.Range(0, quizzes.Count);
        currentQuizzSO = quizzes[randomIndex];
        if (quizzes.Contains(currentQuizzSO))
        {
            quizzes.Remove(currentQuizzSO);
        }
    }

    private void ResetButtonsSprite()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImg = answerButtons[i].GetComponent<Image>();
            buttonImg.sprite = defaultSprite;
        }
    }

    private void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
}
