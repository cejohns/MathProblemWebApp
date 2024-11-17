namespace MathProblemWebApp.Models
{
    public class Problem
    {
        public int Id { get; set; } // Unique identifier for the problem
        public string Description { get; set; } = string.Empty; // The problem statement
        public string? Solution { get; set; } // Optional solution (nullable)
        public string Category { get; set; } = "General"; // Category (e.g., Algebra, Geometry, etc.)
        public DifficultyLevel Difficulty { get; set; } // Enum to represent difficulty levels
    }

    // Enum to represent different difficulty levels
    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard
    }
}
