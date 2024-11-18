namespace MathProblemWebApp.Models
{
    public class UserProfile
    {
        public string UserId { get; set; } = string.Empty;
        public int TotalProblemsSolved { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
        public DifficultyLevel CurrentDifficulty { get; set; } = DifficultyLevel.Easy;
    }
}
