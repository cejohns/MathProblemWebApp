using MathProblemWebApp.Models;

namespace MathProblemWebApp.Services
{
    public class HintService
    {
        // Method to get hints based on the problem
        public string GetHint(Problem problem)
        {
            // Provide basic hints based on the problem category
            switch (problem.Category)
            {
                case "Basic Arithmetic":
                    return "Try breaking down the problem into smaller, simpler steps. Focus on one operation at a time.";
                case "Linear Equations":
                    return "Remember to isolate the variable by using inverse operations on both sides of the equation.";
                case "Quadratic Equations":
                    return "Consider using the quadratic formula: x = (-b ± √(b² - 4ac)) / 2a, or try factoring if possible.";
                case "Polynomials":
                    return "Combine like terms and simplify the expression step by step.";
                case "Factoring":
                    return "Look for common factors or use techniques like grouping or the quadratic method.";
                default:
                    return "No specific hints are available for this type of problem.";
            }
        }

        // Optional: Add more methods for providing explanations or step-by-step guides
    }
}
