/*
1. Create a List to store each game round
2. Should have; the operation performed, first number, second number
correct answer, user answer, score after round, bool correct/incorrect. 
*/
namespace MathGameLogic;

public class GameHistory
{
    public string Operations { get; set; }
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }
    public int CorrectAnswer { get; set; }
    public int UserAnswer { get; set; }
    public int ScoreAfterRound { get; set; }
    public bool IsCorrect { get; set; }

    public GameHistory(string operations, int firstNumber, int secondNumber, int correctAnswer, int userAnswer, int scoreAfterRound, bool isCorrect)
    {
        Operations = operations;
        FirstNumber = firstNumber;
        SecondNumber = secondNumber;
        CorrectAnswer = correctAnswer;
        UserAnswer = userAnswer;
        ScoreAfterRound = scoreAfterRound;
        IsCorrect = isCorrect;
    }
}