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
    DifficultyLevel difficulty = DifficultyLevel.Easy; // Default difficulty
    ComplexityLevel complexity = ComplexityLevel.Simple; // Default complexity
    switch (operation.ToLower())
    {
        case "addition":
            description = $"{a} + {b}";
            solution = (a + b).ToString();
            difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
            break;

        case "subtraction":
            description = $"{a} - {b}";
            solution = (a - b).ToString();
            difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
            break;

        case "multiplication":
            description = $"{a} * {b}";
            solution = (a * b).ToString();
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Simple;
            break;

        case "division":
            b = b == 0 ? 1 : b; // Avoid division by zero
            description = $"{a} / {b}";
            solution = (a / (double)b).ToString("F2"); // Format to 2 decimals
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate; // Division is slightly more complex
            break;
        case "modulo":
            b = b == 0 ? 1 : b; // Avoid modulo by zero
            description = $"{a} % {b}";
            solution = (a % b).ToString();
             difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
            //hint = "Hint: Divide the first number by the second and find the remainder.";
            break;
      case "lcd":
    description = $"Find the Least Common Denominator (LCD) of {a} and {b}.";
    solution = LCD(a, b).ToString();
    difficulty = DifficultyLevel.Easy; // Basic arithmetic understanding required
    complexity = ComplexityLevel.Simple; // Single-step calculation
    //hint = "Hint: The LCD is the smallest number divisible by both numbers. Use prime factorization or multiples.";
    break;

case "gcd":
    description = $"Find the Greatest Common Divisor (GCD) of {a} and {b}.";
    solution = GCD(a, b).ToString();
    difficulty = DifficultyLevel.Easy; // Suitable for basic skill level
    complexity = ComplexityLevel.Simple; // Single-step calculation
    //hint = "Hint: The GCD is the largest number that divides both numbers evenly. Use prime factorization or the Euclidean algorithm.";
    break;
        case "exponentiation":
            a = random.Next(1, 10); // Smaller base for readability
            b = random.Next(1, 5); // Smaller exponent for readability
            description = $"{a}^{b}";
            solution = Math.Pow(a, b).ToString();
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced; // Requires understanding of powers
            break;

        case "square root":
            a = random.Next(1, 21); // Smaller values to generate perfect squares
            int square = a * a;
            description = $"√{square}";
            solution = a.ToString();
            difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
            break;

        case "cube root":
            a = random.Next(1, 11); // Smaller values to generate perfect cubes
            int cube = a * a * a;
            description = $"³√{cube}";
            solution = a.ToString();
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "nth root":
            int n = random.Next(2, 5); // Randomly pick root type (e.g., square, cube, etc.)
            a = random.Next(2, 10); // Base value for nth root
            int power = (int)Math.Pow(a, n); // Generate the nth power
            description = $"{n}√{power}";
            solution = a.ToString();
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;
          case "ratio":
            description = $"Simplify the ratio: {a}:{b}";
            int gcd = GCD(a, b); // Find greatest common divisor for simplification
            solution = $"{a / gcd}:{b / gcd}";
            difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
            break;

        case "proportion":
            int c = random.Next(min, max);
            description = $"Solve for x: {a}/{b} = x/{c}";
            solution = ((a * c) / b).ToString("F2");
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate; // Requires solving for x
            break;

        case "percentage":
            description = $"What is {a}% of {b}?";
            solution = ((a / 100.0) * b).ToString("F2");
            difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
            break;

        case "percentage change":
            int newValue = random.Next(min, max);
            description = $"Find the percentage change from {a} to {newValue}.";
            double percentChange = ((double)(newValue - a) / a) * 100;
            solution = percentChange.ToString("F2") + "%";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate; // Requires understanding percentage change
            break;
              case "irrational square root":
                //int n = random.Next(2, 10); // Generate non-perfect square numbers
                int nonPerfectSquare = a * a + random.Next(1, a); // Create a number that is not a perfect square
                description = $"Simplify: √{nonPerfectSquare}";
                solution = $"√{nonPerfectSquare}";
                 difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            //hint = "Hint: This is a non-perfect square root, so leave the solution in its simplified radical form.";
                break;

            case "pi multiplication":
                description = $"{a}π";
                solution = $"{Math.Round(a * Math.PI, 2)}"; // Use Math.PI
                 difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
                break;

            case "e multiplication":
                description = $"{a}e";
                solution = $"{Math.Round(a * Math.E, 2)}"; // Use Math.E
                difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
                break;

            case "logarithmic base e":
                description = $"ln({a})"; // Natural logarithm (base e)
                solution = $"{Math.Round(Math.Log(a), 2)}";
                difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced; // Logarithms require deeper understanding
                break;

            case "logarithmic base 10":
                description = $"log({a})"; // Logarithm base 10
                solution = $"{Math.Round(Math.Log10(a), 2)}";
                 difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced; // Logarithms require deeper understanding
            break;
               
        default:
            description = "Invalid operation provided";
            solution = "N/A";
            difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
            break;
    }

    return new Problem
    {
         Id = random.Next(1, 10000),
        Description = $"Calculate: {description}",
        Solution = solution,
        Category = "Roots and Arithmetic",
        Difficulty = difficulty,
        Complexity = complexity
    };

    
}

 private int LCD(int x, int y)
    {
        return Math.Abs(x * y) / GCD(x, y); // Use GCD to calculate LCD
    }

 // Helper method to calculate the greatest common divisor (GCD)
    private int GCD(int x, int y)
    {
        while (y != 0)
        {
            int temp = y;
            y = x % y;
            x = temp;
        }
        return x;
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
     DifficultyLevel difficulty = DifficultyLevel.Medium; // Default difficulty
    ComplexityLevel complexity = ComplexityLevel.Simple; // Default complexity
    string hint = string.Empty;

    switch (format)
    {
        case 1: // Format: ax + b = c
            description = $"Solve for x: {a}x + {b} = {c}";
            solution = ((double)(c - b) / a).ToString("F2");
            hint = $"Hint: Subtract {b} from both sides, then divide by {a}.";
            complexity = ComplexityLevel.Simple;
            break;

        case 2: // Format: ax - b = c
            description = $"Solve for x: {a}x - {b} = {c}";
            solution = ((double)(c + b) / a).ToString("F2");
            hint = $"Hint: Add {b} to both sides, then divide by {a}.";
            complexity = ComplexityLevel.Simple;
            break;

       case 3: // Format: b - ax = c
    description = $"Solve for x: {b} - {a}x = {c}";
    solution = ((double)(b - c) / a).ToString("F2"); // Rearrange equation to isolate x
    difficulty = DifficultyLevel.Medium; // Moderate challenge
    complexity = ComplexityLevel.Intermediate; // Multi-step solution
    hint = $"Hint: Subtract {c} from {b}, then divide by {-a} to isolate x.";
    break;

        // Inequality Cases
      case 4: // Format: ax + b > c
            description = $"Solve for x: {a}x + {b} > {c}";
            solution = $"x > {((double)(c - b) / a).ToString("F2")}";
            hint = $"Hint: Isolate x and divide by {a}. Reverse the inequality if {a} is negative.";
            complexity = ComplexityLevel.Intermediate;
            break;

     case 5: // Format: ax + b < c
        description = $"Solve for x: {a}x + {b} < {c}";
        solution = $"x < {((double)(c - b) / a).ToString("F2")}";
        difficulty = DifficultyLevel.Medium;
        complexity = ComplexityLevel.Intermediate;
        hint = $"Hint: Subtract {b} from both sides, then divide by {a}. Remember to reverse the inequality if {a} is negative.";
        break;

    case 6: // Format: ax - b >= c
        description = $"Solve for x: {a}x - {b} >= {c}";
        solution = $"x >= {((double)(c + b) / a).ToString("F2")}";
        difficulty = DifficultyLevel.Medium;
        complexity = ComplexityLevel.Intermediate;
        hint = $"Hint: Add {b} to both sides, then divide by {a}. Remember to reverse the inequality if {a} is negative.";
        break;

    case 7: // Format: ax - b <= c
        description = $"Solve for x: {a}x - {b} <= {c}";
        solution = $"x <= {((double)(c + b) / a).ToString("F2")}";
        difficulty = DifficultyLevel.Medium;
        complexity = ComplexityLevel.Intermediate;
        hint = $"Hint: Add {b} to both sides, then divide by {a}. Remember to reverse the inequality if {a} is negative.";
        break;

       case 8: // Format: b - ax > c
            description = $"Solve for x: {b} - {a}x > {c}";
            solution = $"x < {((double)(b - c) / a).ToString("F2")}";
            hint = $"Hint: Rearrange the inequality to isolate x. Reverse the inequality if {a} is negative.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Advanced;
            break;

       case 9: // Format: b - ax < c
    description = $"Solve for x: {b} - {a}x < {c}";
    solution = $"x > {((double)(b - c) / a).ToString("F2")}"; // Rearrange and solve for x
    difficulty = DifficultyLevel.Medium; // Medium difficulty due to inequality handling
    complexity = ComplexityLevel.Intermediate; // Multi-step process with condition checking
    hint = $"Hint: Subtract {c} from {b}, then divide by {-a} to isolate x. Reverse the inequality if {a} is negative.";
    break;

        // Exponents
        case 10: // Format: x^2 = a
            a = random.Next(1, 100); // Ensure 'a' is positive
            description = $"Solve for x: x² = {a}";
            solution = $"x = ±{Math.Sqrt(a):F2}";
            hint = $"Hint: Take the square root of both sides. Don't forget ±!";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;
case 11: // Format: x^n = a
        int n = random.Next(2, 5); // Random exponent
        a = random.Next(1, 10); // Smaller base for readability
        int power = (int)Math.Pow(a, n); // Generate nth power
        description = $"Solve for x: x^{n} = {power}";
        solution = $"x = ±{a}";
        difficulty = DifficultyLevel.Medium;
        complexity = ComplexityLevel.Intermediate;
        hint = $"Hint: Take the nth root of {power} to find x. Remember that x can be ±{a}.";
        break;

    case 12: // Format: √x = b
        b = random.Next(1, 10); // Positive base
        int square = b * b; // Calculate perfect square
        description = $"Solve for x: √x = {b}";
        solution = $"x = {square}";
        difficulty = DifficultyLevel.Easy;
        complexity = ComplexityLevel.Simple;
        hint = $"Hint: Square both sides to find x.";
        break;

    case 13: // Format: nth root of x = b
        n = random.Next(2, 5); // Random root degree
        b = random.Next(2, 5); // Base value
        int nthPower = (int)Math.Pow(b, n); // Calculate nth power
        description = $"Solve for x: {n}√x = {b}";
        solution = $"x = {nthPower}";
        difficulty = DifficultyLevel.Medium;
        complexity = ComplexityLevel.Intermediate;
        hint = $"Hint: Raise both sides to the power of {n} to find x.";
        break;

        // Exponential Inequalities
      case 14: // Format: x^2 > a
            a = random.Next(1, 100); // Ensure 'a' is positive
            description = $"Solve for x: x² > {a}";
            solution = $"x > ±{Math.Sqrt(a):F2}";
            hint = $"Hint: Solve as if it were an equation, then adjust for the inequality.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Challenging;
            break;

       case 15: // Format: √x < b
        b = random.Next(1, 10); // Positive base
        square = b * b; // Calculate perfect square
        description = $"Solve for x: √x < {b}";
        solution = $"x < {square}";
        difficulty = DifficultyLevel.Medium;
        complexity = ComplexityLevel.Intermediate;
        hint = $"Hint: Square both sides to remove the square root. Ensure the result is positive.";
        break;

    case 16: // Format: nth root of x > b
        n = random.Next(2, 5); // Random root degree
        b = random.Next(2, 5); // Base value
        nthPower = (int)Math.Pow(b, n); // Calculate nth power
        description = $"Solve for x: {n}√x > {b}";
        solution = $"x > {nthPower}";
        difficulty = DifficultyLevel.Hard;
        complexity = ComplexityLevel.Advanced;
        hint = $"Hint: Raise both sides to the power of {n} to remove the root. Ensure the result remains valid for inequalities.";
        break;

        default: // Default to ax + b = c
            description = $"Solve for x: {a}x + {b} = {c}";
            solution = ((double)(c - b) / a).ToString("F2");
            difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
             hint = $"Hint: Subtract {b} from both sides, then divide by {a}.";
            break;
    }

    return new Problem
    {
        Id = random.Next(1, 10000), // Unique problem ID
        Description = description,
        Solution = solution,
        Category = "Linear Equations and Inequalities",
        Difficulty = difficulty,
        Complexity = complexity,
        Hint = hint
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
    int a = random.Next(1, 5); // Leading coefficient
    int b = random.Next(1, 10); // One root
    int c = random.Next(1, 10); // Second root

    int constantTerm = b * c; // Constant term in the quadratic
    int linearCoefficient = b + c; // Coefficient of x term

    string description = $"Factor the quadratic expression: {a}x² + {linearCoefficient}x + {constantTerm}";
    string solution = $"({a}x + {b})({a}x + {c})"; // The factored form of the quadratic
    string hint = $"Hint: Look for two numbers that multiply to {constantTerm} and add to {linearCoefficient}.";

    DifficultyLevel difficulty;
    ComplexityLevel complexity;

    // Assign difficulty and complexity based on the size of coefficients
    if (Math.Max(b, c) <= 5)
    {
        difficulty = DifficultyLevel.Easy;
        complexity = ComplexityLevel.Simple;
    }
    else
    {
        difficulty = DifficultyLevel.Medium;
        complexity = ComplexityLevel.Intermediate;
    }

    return new Problem
    {
        Id = random.Next(1, 10000),
        Description = description,
        Solution = solution,
        Hint = hint,
        Category = "Factoring",
        Difficulty = difficulty,
        Complexity = complexity
    };
}

    public Problem GenerateGeometryProblem(string topic = "basic concepts")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;
    DifficultyLevel difficulty = DifficultyLevel.Medium;
    ComplexityLevel complexity = ComplexityLevel.Simple;

    switch (topic.ToLower())
    {
        // 1. Basic Geometric Concepts
        case "points, lines, line segments, and rays":
            description = "What is the length of a line segment with endpoints A(1, 2) and B(4, 6)?";
            solution = $"{Math.Sqrt(Math.Pow(4 - 1, 2) + Math.Pow(6 - 2, 2)):F2}";
            hint = "Hint: Use the distance formula: √((x2 - x1)² + (y2 - y1)²).";
            difficulty = DifficultyLevel.Easy;
            break;

        case "types of angles":
            description = "Classify an angle measuring 120°.";
            solution = "Obtuse";
            hint = "Hint: Angles between 90° and 180° are obtuse.";
            difficulty = DifficultyLevel.Easy;
            break;

        case "parallel and perpendicular lines":
            description = "Are the lines with slopes 3 and -1/3 perpendicular?";
            solution = "Yes";
            hint = "Hint: Perpendicular lines have slopes that are negative reciprocals.";
            difficulty = DifficultyLevel.Medium;
            break;

        // 2. Triangles
        case "pythagorean theorem":
            int baseLength = random.Next(3, 10);
            int height = random.Next(3, 10);
            description = $"Find the hypotenuse of a right triangle with base {baseLength} and height {height}.";
            solution = $"{Math.Sqrt(baseLength * baseLength + height * height):F2}";
            hint = "Hint: Use the formula: Hypotenuse² = Base² + Height².";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "triangle inequality theorem":
            int side1 = random.Next(1, 10);
            int side2 = random.Next(1, 10);
            int side3 = random.Next(1, 20);
            bool isTriangle = side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1;
            description = $"Can the sides {side1}, {side2}, and {side3} form a triangle?";
            solution = isTriangle ? "Yes" : "No";
            hint = "Hint: For any triangle, the sum of any two sides must be greater than the third.";
            difficulty = DifficultyLevel.Medium;
            break;

        // 3. Quadrilaterals
        case "types of quadrilaterals":
            description = "Identify the quadrilateral with opposite sides equal and four right angles.";
            solution = "Rectangle";
            hint = "Hint: A rectangle has equal opposite sides and 90° angles.";
            difficulty = DifficultyLevel.Easy;
            break;

        // 4. Circles
        case "arc length":
            int radius = random.Next(5, 15);
            int centralAngle = random.Next(30, 180);
            description = $"Find the arc length of a circle with radius {radius} and central angle {centralAngle}°.";
            solution = $"{(Math.PI * radius * centralAngle) / 180:F2}";
            hint = "Hint: Arc length = (θ/360) × 2πr.";
            difficulty = DifficultyLevel.Medium;
            break;

        // 5. Polygons
        case "sum of interior angles":
            int sides = random.Next(3, 10);
            int sumAngles = (sides - 2) * 180;
            description = $"What is the sum of the interior angles of a polygon with {sides} sides?";
            solution = $"{sumAngles}°";
            hint = "Hint: Sum of interior angles = (n - 2) × 180, where n is the number of sides.";
            difficulty = DifficultyLevel.Easy;
            break;

        // 6. Transformations
        case "coordinate transformations":
            int x = random.Next(1, 10), y = random.Next(1, 10);
            description = $"If point ({x}, {y}) is reflected over the x-axis, what is its new coordinate?";
            solution = $"({x}, {-y})";
            hint = "Hint: Reflection over the x-axis changes the y-coordinate to its opposite.";
            difficulty = DifficultyLevel.Medium;
            break;

        // 7. Coordinate Geometry
        case "distance formula":
            int x1 = random.Next(1, 10), y1 = random.Next(1, 10);
            int x2 = random.Next(1, 10), y2 = random.Next(1, 10);
            description = $"Find the distance between points ({x1}, {y1}) and ({x2}, {y2}).";
            solution = $"{Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)):F2}";
            hint = "Hint: Use the distance formula: √((x2 - x1)² + (y2 - y1)²).";
            difficulty = DifficultyLevel.Medium;
            break;

        // 8. Area and Volume
        case "volume of a sphere":
            radius = random.Next(1, 10);
            description = $"Find the volume of a sphere with radius {radius}.";
            solution = $"{(4 / 3.0) * Math.PI * Math.Pow(radius, 3):F2}";
            hint = "Hint: Volume of a sphere = (4/3)πr³.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        // Default case for invalid topic
        default:
            description = "Invalid topic selected for Geometry.";
            solution = "N/A";
            difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
            break;
    }

    return new Problem
    {
        Id = random.Next(1, 10000),
        Description = description,
        Solution = solution,
        Hint = hint,
        Category = "Geometry",
        Difficulty = difficulty,
        Complexity = complexity
    };
}

public Problem GenerateTrigonometryProblem(string topic = "trig ratios")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;
    DifficultyLevel difficulty = DifficultyLevel.Medium;
    ComplexityLevel complexity = ComplexityLevel.Simple; // Default complexity

    switch (topic.ToLower())
    {
        // 1. Trigonometric Ratios and Functions
        case "trig ratios":
            string[] functions = { "sine", "cosine", "tangent", "cotangent", "secant", "cosecant" };
            string selectedFunction = functions[random.Next(functions.Length)];
            description = $"Define the trigonometric function {selectedFunction} and describe its relationship in a right triangle.";
            solution = "Depends on the function. For example: sine = opposite/hypotenuse.";
            hint = "Hint: Think of the sides of a right triangle.";
            difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
            break;

        case "right triangle":
            int a = random.Next(3, 10);
            int b = random.Next(3, 10);
            description = $"Given a right triangle with adjacent side {a} and opposite side {b}, find the value of sine, cosine, and tangent for the corresponding angle.";
            solution = $"Sine = {Math.Round((double)b / Math.Sqrt(a * a + b * b), 2)}, Cosine = {Math.Round((double)a / Math.Sqrt(a * a + b * b), 2)}, Tangent = {Math.Round((double)b / a, 2)}";
            hint = "Hint: Use SOH-CAH-TOA.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        // 2. Unit Circle and Radian Measure
        case "unit circle":
            description = $"Using the unit circle, find the coordinates of the point corresponding to an angle of π/4 radians.";
            solution = "(√2/2, √2/2)";
            hint = "Hint: Think about the coordinates of points on the unit circle.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Simple;
            break;

        case "degree to radian":
            int degrees = random.Next(0, 361);
            description = $"Convert {degrees}° to radians.";
            solution = $"{Math.Round(degrees * Math.PI / 180, 2)} radians";
            hint = "Hint: Use the formula radians = degrees × π / 180.";
            difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
            break;

        case "unit circle value":
            string[] angles = { "π/6", "π/4", "π/3", "π/2" };
            string selectedAngle = angles[random.Next(angles.Length)];
            string[] trigFunctions = { "sin", "cos", "tan" };
            string selectedTrigFunction = trigFunctions[random.Next(trigFunctions.Length)];
            description = $"Using the unit circle, find {selectedTrigFunction}({selectedAngle}).";
            solution = selectedTrigFunction switch
            {
                "sin" => selectedAngle == "π/6" ? "1/2" : selectedAngle == "π/4" ? "√2/2" : "√3/2",
                "cos" => selectedAngle == "π/6" ? "√3/2" : selectedAngle == "π/4" ? "√2/2" : "1/2",
                "tan" => selectedAngle == "π/6" ? "1/√3" : selectedAngle == "π/4" ? "1" : "√3",
                _ => "N/A"
            };
            hint = "Hint: Use the coordinates of points on the unit circle.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        // 3. Trigonometric Identities and Equations
        case "pythagorean identity":
            description = $"Prove that sin²(x) + cos²(x) = 1 for any angle x.";
            solution = "By definition, the sum of the squares of sine and cosine equals 1 on the unit circle.";
            hint = "Hint: Recall the equation of the unit circle.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "double angle":
            description = "Use the double-angle formula to find cos(2x) when x = 30°.";
            solution = "Cos(2x) = 1 - 2sin²(x) = 1 - 2(1/4) = 1/2";
            hint = "Hint: Use the formula cos(2x) = 1 - 2sin²(x).";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "solve trig equation":
            description = "Solve the equation sin(x) = 0.5 for 0° ≤ x ≤ 360°.";
            solution = "x = 30° or x = 150°";
            hint = "Hint: Think of angles where the sine value is 0.5.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        // 4. Law of Sines and Law of Cosines
        case "law of sines":
            description = "Given a triangle with angles A = 30°, B = 45°, and side a = 10, find the length of side b using the Law of Sines.";
            solution = "b = 10 × sin(45°) / sin(30°) = 10√2";
            hint = "Hint: Use the formula a/sin(A) = b/sin(B).";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "law of cosines":
            description = "Find the length of the third side of a triangle with sides a = 7, b = 10, and angle C = 60° using the Law of Cosines.";
            solution = "c = √(7² + 10² - 2(7)(10)cos(60°)) = 9";
            hint = "Hint: Use the formula c² = a² + b² - 2abcos(C).";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        default:
            description = "Invalid topic for Trigonometry.";
            solution = "N/A";
            break;
    }

    return new Problem
    {
        Id = random.Next(1, 10000),
        Description = description,
        Solution = solution,
        Hint = hint,
        Category = "Trigonometry",
        Difficulty = difficulty,
        Complexity = complexity
    };
}


public Problem GeneratePreCalculusProblem(string topic = "sequence")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;
    DifficultyLevel difficulty = DifficultyLevel.Medium;

    switch (topic.ToLower())
    {
        case "sequence":
            int firstTerm = random.Next(1, 10);
            int commonDifference = random.Next(1, 5);
            description = $"Find the 5th term of the arithmetic sequence starting with {firstTerm} and having a common difference of {commonDifference}.";
            solution = $"{firstTerm + 4 * commonDifference}";
            hint = "Hint: Use the formula Tn = a + (n-1)d.";
            break;

        case "limit":
            int a = random.Next(1, 10);
            description = $"Find the limit as x approaches {a} of (x² - {a * a}) / (x - {a}).";
            solution = $"{2 * a}"; // Simplify (x² - a²) to (x - a)(x + a)
            hint = "Hint: Simplify the expression by factoring.";
            break;

        default:
            description = "Invalid topic for Pre-Calculus.";
            solution = "N/A";
            break;
    }

    return new Problem
    {
        Id = random.Next(1, 10000),
        Description = description,
        Solution = solution,
        Hint = hint,
        Category = "Pre-Calculus",
        Difficulty = difficulty
    };
}

public Problem GenerateCalculusProblem(string topic = "derivative")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;
    DifficultyLevel difficulty = DifficultyLevel.Hard;

    switch (topic.ToLower())
    {
        case "derivative":
            int coefficient = random.Next(1, 10);
            int exponent = random.Next(1, 5);
            description = $"Find the derivative of f(x) = {coefficient}x^{exponent}.";
            solution = $"{coefficient * exponent}x^{exponent - 1}";
            hint = "Hint: Use the power rule: d/dx [x^n] = nx^(n-1).";
            break;

        case "integral":
            coefficient = random.Next(1, 10);
            exponent = random.Next(1, 5);
            description = $"Find the indefinite integral of f(x) = {coefficient}x^{exponent}.";
            solution = $"{coefficient / (exponent + 1)}x^{exponent + 1} + C";
            hint = "Hint: Use the formula ∫x^n dx = (1/(n+1))x^(n+1) + C.";
            break;

        default:
            description = "Invalid topic for Calculus.";
            solution = "N/A";
            break;
    }

    return new Problem
    {
        Id = random.Next(1, 10000),
        Description = description,
        Solution = solution,
        Hint = hint,
        Category = "Calculus",
        Difficulty = difficulty
    };
}

public Problem GenerateLinearAlgebraProblem(string topic = "matrix")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;
    DifficultyLevel difficulty = DifficultyLevel.Hard;

    switch (topic.ToLower())
    {
        case "matrix":
            description = "Find the determinant of the matrix:\n| 2  3 |\n| 1  4 |";
            solution = "Determinant = 2(4) - 3(1) = 5";
            hint = "Hint: Use the determinant formula for a 2x2 matrix: ad - bc.";
            break;

        case "vector":
            int x = random.Next(1, 10);
            int y = random.Next(1, 10);
            description = $"Find the magnitude of the vector ({x}, {y}).";
            solution = $"{Math.Sqrt(x * x + y * y):F2}";
            hint = "Hint: Use the formula √(x² + y²).";
            break;

        default:
            description = "Invalid topic for Linear Algebra.";
            solution = "N/A";
            break;
    }

    return new Problem
    {
        Id = random.Next(1, 10000),
        Description = description,
        Solution = solution,
        Hint = hint,
        Category = "Linear Algebra",
        Difficulty = difficulty
    };
}


public Problem GenerateDifferentialEquationsProblem(string type = "ODE")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;
    DifficultyLevel difficulty = DifficultyLevel.Hard;

    switch (type.ToLower())
    {
        case "ode":
            description = "Solve the ordinary differential equation: dy/dx = 3x².";
            solution = "y = x³ + C";
            hint = "Hint: Integrate both sides with respect to x.";
            break;

        case "pde":
            description = "Solve the partial differential equation: ∂u/∂t = ∂²u/∂x².";
            solution = "Solution depends on boundary conditions (e.g., Fourier series).";
            hint = "Hint: Use separation of variables.";
            break;

        default:
            description = "Invalid type for Differential Equations.";
            solution = "N/A";
            break;
    }

    return new Problem
    {
        Id = random.Next(1, 10000),
        Description = description,
        Solution = solution,
        Hint = hint,
        Category = "Differential Equations",
        Difficulty = difficulty
    };
}

public Problem GenerateDiscreteMathProblem(string topic = "logic")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;
    DifficultyLevel difficulty = DifficultyLevel.Medium;

    switch (topic.ToLower())
    {
        case "logic":
            description = "Simplify the logical expression: (A ∧ B) ∨ (¬A ∧ B).";
            solution = "B";
            hint = "Hint: Use distribution and simplification rules.";
            break;

        case "graph theory":
            description = "Find the shortest path between nodes A and E in a weighted graph.";
            solution = "Solution depends on the graph (e.g., Dijkstra's algorithm).";
            hint = "Hint: Use a shortest-path algorithm.";
            break;

        case "set theory":
            description = "Find A ∩ B if A = {1, 2, 3} and B = {2, 3, 4}.";
            solution = "{2, 3}";
            hint = "Hint: Intersection includes elements common to both sets.";
            break;

        default:
            description = "Invalid topic for Discrete Mathematics.";
            solution = "N/A";
            break;
    }

    return new Problem
    {
        Id = random.Next(1, 10000),
        Description = description,
        Solution = solution,
        Hint = hint,
        Category = "Discrete Mathematics",
        Difficulty = difficulty
    };
}

public Problem GenerateAbstractAlgebraProblem(string topic = "groups")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;
    DifficultyLevel difficulty = DifficultyLevel.Hard;

    switch (topic.ToLower())
    {
        case "groups":
            description = "Prove that the set of integers under addition forms a group.";
            solution = "Solution involves verifying closure, associativity, identity, and inverse.";
            hint = "Hint: Use the group axioms.";
            break;

        case "rings":
            description = "Verify if (Z, +, ×) is a commutative ring.";
            solution = "Yes, integers form a commutative ring.";
            hint = "Hint: Check the ring axioms.";
            break;

        default:
            description = "Invalid topic for Abstract Algebra.";
            solution = "N/A";
            break;
    }

    return new Problem
    {
        Id = random.Next(1, 10000),
        Description = description,
        Solution = solution,
        Hint = hint,
        Category = "Abstract Algebra",
        Difficulty = difficulty
    };
}

public Problem GenerateProbabilityProblem(string topic = "probability")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;
    DifficultyLevel difficulty = DifficultyLevel.Medium;

    switch (topic.ToLower())
    {
        case "probability":
            description = "What is the probability of rolling a sum of 7 with two dice?";
            solution = "6/36 or 1/6";
            hint = "Hint: Count favorable outcomes over total outcomes.";
            break;

        case "regression":
            description = "Find the line of best fit for the dataset (1,2), (2,4), (3,6).";
            solution = "y = 2x";
            hint = "Hint: Use the least squares method.";
            break;

        default:
            description = "Invalid topic for Probability and Statistics.";
            solution = "N/A";
            break;
    }

    return new Problem
    {
        Id = random.Next(1, 10000),
        Description = description,
        Solution = solution,
        Hint = hint,
        Category = "Probability and Statistics",
        Difficulty = difficulty
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
