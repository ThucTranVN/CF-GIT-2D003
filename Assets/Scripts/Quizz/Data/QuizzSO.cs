using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Quiz Question")]
public class QuizzSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField]
    private string question = "Enter question here";

    [SerializeField]
    private string[] answers = new string[4];

    [SerializeField]
    private int correctAnswerIndex;

    public string GetQuestion()
    {
        return question;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
}