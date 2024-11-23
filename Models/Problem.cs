namespace MathProblemWebApp.Models
{
    public class Problem
    {
        public int Id { get; set; } // Unique identifier for the problem
        public string Description { get; set; } = string.Empty; // The problem statement
        public string? Solution { get; set; } // Optional solution (nullable)
        public string Category { get; set; } = "General"; // Category (e.g., Algebra, Geometry, etc.)
        public DifficultyLevel Difficulty { get; set; } // Enum to represent difficulty levels

        public string Hint  { get; set; } = string.Empty;

          // Additional properties for subject-specific complexity
        public string Subject { get; set; } = "General"; // Mathematical subject (e.g., Arithmetic, Algebra, etc.)
        public ComplexityLevel Complexity { get; set; } // Enum for more granular complexity levels
    }

    // Enum to represent different difficulty levels
    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard
    }

    // Enum for subject-specific complexity levels
    public enum ComplexityLevel
    {
        Simple,       // Basic single-step problems
        Intermediate, // Multi-step or slightly advanced problems
        Advanced,     // Complex problems requiring deeper understanding
        Challenging   // Problems that combine multiple concepts or require high-level reasoning
    }
}
