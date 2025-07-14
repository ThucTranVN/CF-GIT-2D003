using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizGameManager : MonoBehaviour
{
    [SerializeField]
    private QuizzSO quizzSO;
    [SerializeField]
    private TextMeshProUGUI questionText;
    [SerializeField]
    private GameObject[] answerButtons;
    [SerializeField]
    private Sprite defaultSprite;
    [SerializeField]
    private Sprite correctSprite;

    void Start()
    {
        Setup();
    }

    private void Setup()
    {
        questionText.text = quizzSO.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI answerText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            answerText.text = quizzSO.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        Debug.Log($"OnAnswerSelected {index}");

        if (index == quizzSO.GetCorrectAnswerIndex()) //Tra loi dung
        {
            questionText.text = "Correct!";
            Image btnImage = answerButtons[index].GetComponent<Image>();
            btnImage.sprite = correctSprite;

        }
        else //Tra loi sai
        {
            int correctAnswerIndex = quizzSO.GetCorrectAnswerIndex();
            string correctAnswer = quizzSO.GetAnswer(correctAnswerIndex);
            questionText.text = $"Sorry, the correct answer was: {correctAnswer}";
            Image btnImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            btnImage.sprite = correctSprite;
        }
    }
}
