using System;
using MathProblemWebApp.Models;

namespace MathProblemWebApp.Services
{
    public class MathProblemService
    {
        private static Random random = new Random();

        // Generate a basic arithmetic problem
      public Problem GenerateBasicMathProblem(string operation = "")
{
    int min = 1;
    int max = 100;
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
            solution = (a / (double)b).ToString("F2"); // Format to 2 decimals
            break;
            case "modulo":
            b = b == 0 ? 1 : b; // Avoid modulo by zero
            description = $"{a} % {b}";
            solution = (a % b).ToString();
            break;

        case "exponentiation":
            a = random.Next(1, 10); // Smaller base for readability
            b = random.Next(1, 5); // Smaller exponent for readability
            description = $"{a}^{b}";
            solution = Math.Pow(a, b).ToString();
            break;

        case "square root":
            a = random.Next(1, 21); // Smaller values to generate perfect squares
            int square = a * a;
            description = $"√{square}";
            solution = a.ToString();
            break;

        case "cube root":
            a = random.Next(1, 11); // Smaller values to generate perfect cubes
            int cube = a * a * a;
            description = $"³√{cube}";
            solution = a.ToString();
            break;

        case "nth root":
            int n = random.Next(2, 5); // Randomly pick root type (e.g., square, cube, etc.)
            a = random.Next(2, 10); // Base value for nth root
            int power = (int)Math.Pow(a, n); // Generate the nth power
            description = $"{n}√{power}";
            solution = a.ToString();
            break;

        default:
            description = "Invalid operation provided";
            solution = "N/A";
            break;
    }

    return new Problem
    {
        Id = random.Next(1, 10000),
        Description = $"Calculate: {description}",
        Solution = solution,
        Category = "Roots and Arithmetic",
        Difficulty = DifficultyLevel.Easy
    };
}


        // Generate a linear equation problem
    public Problem GenerateLinearEquationProblem()
{
    int a, b, c;

    do
    {
        a = random.Next(-10, 10); // Include negative values for variety
    } while (a == 0); // Ensure 'a' is non-zero

    b = random.Next(-20, 20);
    c = random.Next(-20, 20);

    // Randomly choose a format for the equation or inequality
    int format = random.Next(1, 10); // Formats 1-3 for equations, 4-9 for inequalities
    string description;
    string solution;

    switch (format)
    {
        case 1: // Format: ax + b = c
            description = $"Solve for x: {a}x + {b} = {c}";
            solution = ((double)(c - b) / a).ToString("F2");
            break;

        case 2: // Format: ax - b = c
            description = $"Solve for x: {a}x - {b} = {c}";
            solution = ((double)(c + b) / a).ToString("F2");
            break;

        case 3: // Format: b - ax = c
            description = $"Solve for x: {b} - {a}x = {c}";
            solution = ((double)(b - c) / a).ToString("F2");
            break;

        // Inequality Cases
        case 4: // Format: ax + b > c
            description = $"Solve for x: {a}x + {b} > {c}";
            solution = $"x > {((double)(c - b) / a).ToString("F2")}";
            break;

        case 5: // Format: ax + b < c
            description = $"Solve for x: {a}x + {b} < {c}";
            solution = $"x < {((double)(c - b) / a).ToString("F2")}";
            break;

        case 6: // Format: ax - b >= c
            description = $"Solve for x: {a}x - {b} >= {c}";
            solution = $"x >= {((double)(c + b) / a).ToString("F2")}";
            break;

        case 7: // Format: ax - b <= c
            description = $"Solve for x: {a}x - {b} <= {c}";
            solution = $"x <= {((double)(c + b) / a).ToString("F2")}";
            break;

        case 8: // Format: b - ax > c
            description = $"Solve for x: {b} - {a}x > {c}";
            solution = $"x < {((double)(b - c) / a).ToString("F2")}";
            break;

        case 9: // Format: b - ax < c
            description = $"Solve for x: {b} - {a}x < {c}";
            solution = $"x > {((double)(b - c) / a).ToString("F2")}";
            break;

        // Exponents
        case 10: // Format: x^2 = a
            a = random.Next(1, 100); // Ensure 'a' is positive for square root
            description = $"Solve for x: x² = {a}";
            solution = $"x = ±{Math.Sqrt(a):F2}";
            break;

        case 11: // Format: x^n = a
            int n = random.Next(2, 5); // Random exponent
            a = random.Next(1, 10); // Smaller base for readability
            int power = (int)Math.Pow(a, n); // Generate nth power
            description = $"Solve for x: x^{n} = {power}";
            solution = $"x = ±{a}";
            break;

        // Roots
        case 12: // Format: √x = b
            b = random.Next(1, 10);
            int square = b * b;
            description = $"Solve for x: √x = {b}";
            solution = $"x = {square}";
            break;

        case 13: // Format: nth root of x = b
            n = random.Next(2, 5); // Random root degree
            b = random.Next(2, 5); // Base value
            int nthPower = (int)Math.Pow(b, n);
            description = $"Solve for x: {n}√x = {b}";
            solution = $"x = {nthPower}";
            break;

        // Exponential Inequalities
        case 14: // Format: x^2 > a
            a = random.Next(1, 100); // Ensure 'a' is positive
            description = $"Solve for x: x² > {a}";
            solution = $"x > ±{Math.Sqrt(a):F2}";
            break;

        case 15: // Format: √x < b
            b = random.Next(1, 10);
            square = b * b;
            description = $"Solve for x: √x < {b}";
            solution = $"x < {square}";
            break;

        case 16: // Format: nth root of x > b
            n = random.Next(2, 5); // Random root degree
            b = random.Next(2, 5); // Base value
            nthPower = (int)Math.Pow(b, n);
            description = $"Solve for x: {n}√x > {b}";
            solution = $"x > {nthPower}";
            break;

        default: // Default to ax + b = c
            description = $"Solve for x: {a}x + {b} = {c}";
            solution = ((double)(c - b) / a).ToString("F2");
            break;
    }

    return new Problem
    {
        Id = random.Next(1, 10000), // Unique problem ID
        Description = description,
        Solution = solution,
        Category = "Linear Equations and Inequalities",
        Difficulty = DifficultyLevel.Medium,
        // Hint to solve the inequality or equation
        Hint = $"Step 1: Isolate x by moving constants to the other side.\nStep 2: Divide both sides by {a}. Remember to reverse the inequality if dividing by a negative."
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
    int a = random.Next(1, 10); // Coefficient for x²
    int b = random.Next(1, 10); // Coefficient for x
    int c = random.Next(1, 10); // Constant term

    // Randomly add terms to make the polynomial varied
    int extraX2 = random.Next(-5, 5); // Additional x² terms
    int extraX = random.Next(-10, 10); // Additional x terms
    int extraConst = random.Next(-15, 15); // Additional constant terms

    // Generate the polynomial expression
    string description = $"Simplify: {a}x² + {b}x + {c} + {extraX2}x² + {extraX}x + {extraConst}";

    // Combine like terms to simplify the polynomial
    int simplifiedX2 = a + extraX2;
    int simplifiedX = b + extraX;
    int simplifiedConst = c + extraConst;

    // Generate the simplified solution as a string
    string solution = $"{simplifiedX2}x² + {simplifiedX}x + {simplifiedConst}";

    // Remove unnecessary terms (e.g., "0x²" or "0x")
    if (simplifiedX2 == 0) solution = solution.Replace("0x² + ", "").Replace("0x²", "");
    if (simplifiedX == 0) solution = solution.Replace(" + 0x + ", " + ").Replace(" + 0x", "");
    if (simplifiedConst == 0) solution = solution.Replace(" + 0", "");

    return new Problem
    {
        Id = random.Next(1, 10000), // Unique problem ID
        Description = description,
        Solution = solution,
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

        public Problem GenerateAdaptiveProblem(string userId, UserProgressService userProgressService)
{
    var userProfile = userProgressService.GetUserProfile(userId);
    DifficultyLevel difficulty = userProfile.CurrentDifficulty;

    switch (difficulty)
    {
        case DifficultyLevel.Easy:
            return GenerateBasicMathProblem(); // Assume this method exists
        case DifficultyLevel.Medium:
            return GenerateLinearEquationProblem(); // Assume this method exists
        case DifficultyLevel.Hard:
            return GenerateQuadraticEquationProblem(); // Assume this method exists
        default:
            return GenerateBasicMathProblem(); // Default fallback
    }
}


        internal object GenerateProblem(string operation)
        {
            throw new NotImplementedException();
        }
    }
}
