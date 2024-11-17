using System;
using MathProblemWebApp.Models;

namespace MathProblemWebApp.Services
{
    public class MathProblemService
    {
        private static Random random = new Random();

        // Generate a basic arithmetic problem
        public Problem GenerateBasicMathProblem()
        {
            string operation= ""; int min = 1; int max = 100;
            int a = random.Next(min, max);
            int b = random.Next(min, max);
            string description = string.Empty;
            string solution = string.Empty;

            switch (operation.ToLower())
            {
                case "addition":
                    description = $"{a} + {b}";
                    solution = (a + b).ToString();
                    break;
                case "subtraction":
                    description = $"{a} - {b}";
                    solution = (a - b).ToString();
                    break;
                case "multiplication":
                    description = $"{a} * {b}";
                    solution = (a * b).ToString();
                    break;
                case "division":
                    b = b == 0 ? 1 : b; // Avoid division by zero
                    description = $"{a} / {b}";
                    solution = (a / b).ToString();
                    break;
                case "modulo":
                    b = b == 0 ? 1 : b; // Avoid modulo by zero
                    description = $"{a} % {b}";
                    solution = (a % b).ToString();
                    break;
                default:
                    throw new ArgumentException("Invalid operation");
            }

            return new Problem
            {
                Id = random.Next(1, 10000),
                Description = $"Calculate: {description}",
                Solution = solution,
                Category = "Arithmetic",
                Difficulty = DifficultyLevel.Easy
            };
        }

        // Generate a linear equation problem
        public Problem GenerateLinearEquationProblem()
        {
            int a = random.Next(1, 10);
            int b = random.Next(-10, 10);
            int c = random.Next(-10, 10);

            string description = $"Solve for x: {a}x + {b} = {c}";
            // Solution calculation omitted for simplicity; would involve algebraic manipulation

            return new Problem
            {
                Id = random.Next(1, 10000),
                Description = description,
                Solution = "N/A", // Placeholder for the actual solution
                Category = "Linear Equations",
                Difficulty = DifficultyLevel.Medium
            };
        }

        // Generate a quadratic equation problem
        public Problem GenerateQuadraticEquationProblem()
        {
            int a = random.Next(1, 5);
            int b = random.Next(-10, 10);
            int c = random.Next(-10, 10);

            string description = $"Solve for x: {a}x² + {b}x + {c} = 0";
            // Solution calculation omitted for simplicity

            return new Problem
            {
                Id = random.Next(1, 10000),
                Description = description,
                Solution = "N/A", // Placeholder for the actual solution
                Category = "Quadratic Equations",
                Difficulty = DifficultyLevel.Hard
            };
        }

        // Generate a polynomial problem for simplification
        public Problem GeneratePolynomialProblem()
        {
            int a = random.Next(1, 10);
            int b = random.Next(1, 10);
            int c = random.Next(1, 10);

            string description = $"Simplify: {a}x² + {b}x + {c} + {b}x - {a}x²";
            // Solution calculation omitted for simplicity

            return new Problem
            {
                Id = random.Next(1, 10000),
                Description = description,
                Solution = "N/A", // Placeholder for the actual solution
                Category = "Polynomials",
                Difficulty = DifficultyLevel.Easy
            };
        }

        // Generate a factoring problem
        public Problem GenerateFactoringProblem()
        {
            int a = random.Next(1, 5);
            int b = random.Next(1, 10);
            int c = a * b;

            string description = $"Factor the expression: x² + {c}x + {b * b}";
            // Solution calculation omitted for simplicity

            return new Problem
            {
                Id = random.Next(1, 10000),
                Description = description,
                Solution = "N/A", // Placeholder for the actual solution
                Category = "Factoring",
                Difficulty = DifficultyLevel.Medium
            };
        }

        // Generate an inequality problem
        public Problem GenerateInequalityProblem()
        {
            int a = random.Next(1, 10);
            int b = random.Next(1, 10);

            string description = $"Solve the inequality: {a}x > {b}";
            // Solution calculation omitted for simplicity

            return new Problem
            {
                Id = random.Next(1, 10000),
                Description = description,
                Solution = "N/A", // Placeholder for the actual solution
                Category = "Inequalities",
                Difficulty = DifficultyLevel.Medium
            };
        }
    }
}
