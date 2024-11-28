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

        // 5. Inverse Trigonometric Functions
        case "inverse trig function":
            description = $"Evaluate arcsin(0.5).";
            solution = $"θ = 30° or π/6";
            hint = "Hint: arcsin(0.5) represents the angle whose sine is 0.5.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "graph inverse trig":
            description = $"Graph the function y = arctan(x).";
            solution = "The graph is an increasing curve with horizontal asymptotes at y = ±π/2.";
            hint = "Hint: The arctan(x) function is the inverse of tan(x) and has a restricted range.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        case "inverse trig application":
            description = $"Find the angle θ such that cos(θ) = 0.6 using inverse trigonometric functions.";
            solution = $"θ ≈ 53.13° or 0.93 radians";
            hint = "Hint: Use arccos(0.6) to find the angle.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        // 6. Law of Sines and Law of Cosines
       

         // 7. Trigonometric Applications
        case "angle of elevation":
            description = $"A person standing 50 meters away from a building observes the top at an angle of elevation of 30°. Find the height of the building.";
            solution = $"Height = {50 * Math.Tan(30 * Math.PI / 180):F2} meters";
            hint = "Hint: Use the tangent function: tan(θ) = opposite/adjacent.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "circular motion":
            int radius = random.Next(3, 10);
            int speed = random.Next(1, 5);
            description = $"An object moves in a circle with radius {radius} meters at a speed of {speed} m/s. Find its angular velocity.";
            solution = $"{(double)speed / radius:F2} rad/s";
            hint = "Hint: Angular velocity = linear velocity / radius.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "harmonic motion":
            int period = random.Next(1, 5);
            description = $"Given a mass-spring system with a period of {period} seconds, find its frequency.";
            solution = $"{1.0 / period:F2} Hz";
            hint = "Hint: Frequency = 1 / Period.";
            difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
            break;

        // 8. Polar Coordinates and Complex Numbers
        case "polar conversion":
            int x = random.Next(1, 10);
            int y = random.Next(1, 10);
            double r = Math.Sqrt(x * x + y * y);
            double theta = Math.Atan2(y, x) * (180 / Math.PI);
            description = $"Convert the point ({x}, {y}) to polar coordinates.";
            solution = $"Polar coordinates: (r = {r:F2}, θ = {theta:F2}°)";
            hint = "Hint: Use r = √(x² + y²) and θ = arctan(y/x).";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "polar graphing":
            description = $"Graph the polar equation r = 2 + 2cos(θ).";
            solution = "This is a limacon graph.";
            hint = "Hint: Identify the type of graph (circle, limacon, rose, etc.).";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        case "complex polar":
            int realPart = random.Next(1, 5);
            int imaginaryPart = random.Next(1, 5);
            double magnitude = Math.Sqrt(realPart * realPart + imaginaryPart * imaginaryPart);
            double angle = Math.Atan2(imaginaryPart, realPart) * (180 / Math.PI);
            description = $"Convert the complex number {realPart} + {imaginaryPart}i to polar form.";
            solution = $"Polar form: {magnitude:F2}(cos({angle:F2}°) + i sin({angle:F2}°))";
            hint = "Hint: Use magnitude = √(a² + b²) and angle = arctan(b/a).";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        // 9. Vectors and Their Applications
        case "vector operations":
            int u1 = random.Next(1, 5);
            int u2 = random.Next(1, 5);
            int v1 = random.Next(1, 5);
            int v2 = random.Next(1, 5);
            description = $"Given vectors u = [{u1}, {u2}] and v = [{v1}, {v2}], find u + v.";
            solution = $"[{u1 + v1}, {u2 + v2}]";
            hint = "Hint: Add the corresponding components.";
            difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
            break;

        case "dot product":
            u1 = random.Next(1, 5);
            u2 = random.Next(1, 5);
            v1 = random.Next(1, 5);
            v2 = random.Next(1, 5);
            description = $"Find the dot product of vectors u = [{u1}, {u2}] and v = [{v1}, {v2}].";
            solution = $"{u1 * v1 + u2 * v2}";
            hint = "Hint: Dot product = u₁v₁ + u₂v₂.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        // 10. Parametric Equations
        case "parametric graph":
            description = $"Graph the parametric equations x = t² and y = 2t for -2 ≤ t ≤ 2.";
            solution = "The graph is a parabola opening upwards.";
            hint = "Hint: Plot the points for different values of t.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "parametric conversion":
            description = $"Convert the parametric equations x = 3t, y = 2t to a Cartesian equation.";
            solution = "y = (2/3)x";
            hint = "Hint: Solve for t in terms of x or y, then substitute.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        // 11. Trigonometric Form of Complex Numbers
        case "trig complex":
            realPart = random.Next(1, 5);
            imaginaryPart = random.Next(1, 5);
            magnitude = Math.Sqrt(realPart * realPart + imaginaryPart * imaginaryPart);
            angle = Math.Atan2(imaginaryPart, realPart) * (180 / Math.PI);
            description = $"Represent the complex number {realPart} + {imaginaryPart}i in trigonometric form.";
            solution = $"{magnitude:F2}(cos({angle:F2}°) + i sin({angle:F2}°))";
            hint = "Hint: Use magnitude = √(a² + b²) and angle = arctan(b/a).";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "de moivre":
            description = $"Use De Moivre’s Theorem to find (1 + i)^5.";
            solution = "Use polar form: √2(cos(π/4) + i sin(π/4))^5 = 4√2(cos(5π/4) + i sin(5π/4))";
            hint = "Hint: Convert to polar form, apply the theorem, and simplify.";
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


public Problem GeneratePreCalculusProblem(string topic = "functions")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;
    DifficultyLevel difficulty = DifficultyLevel.Medium;
    ComplexityLevel complexity = ComplexityLevel.Simple;

    switch (topic.ToLower())
    {
        // Functions and Graphs
        case "functions":
            string[] functionTypes = { "linear", "quadratic", "exponential", "logarithmic", "trigonometric" };
            string selectedFunction = functionTypes[random.Next(functionTypes.Length)];
            description = $"Describe the graph of a {selectedFunction} function and identify its domain and range.";
            solution = "Solution depends on the function type; include specific properties.";
            hint = "Hint: Linear is a straight line, quadratic is a parabola, etc.";
            difficulty = DifficultyLevel.Easy;
            break;

        case "graph transformations":
            int shift = random.Next(-5, 6);
            description = $"Describe the transformations of the graph of f(x) = x² if it is shifted {shift} units to the right and 3 units up.";
            solution = $"The new equation is f(x) = (x - {shift})² + 3.";
            hint = "Hint: Horizontal shifts affect the x term, vertical shifts affect the constant.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "inverse functions":
            int a = random.Next(1, 10);
            description = $"Find the inverse of f(x) = {a}x + 3.";
            solution = $"f⁻¹(x) = (x - 3)/{a}";
            hint = "Hint: Swap x and y, then solve for y.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "polynomial division":
            int b = random.Next(1, 5);
            int c = random.Next(1, 5);
            description = $"Perform synthetic division for the polynomial x³ + {b}x² + {c}x + 4 divided by x - 2.";
            solution = "Synthetic division steps.";
            hint = "Hint: Use the synthetic division method.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        case "exponential":
            int baseValue = random.Next(2, 5);
            int power = random.Next(1, 10);
            description = $"Simplify: {baseValue}^{power}.";
            solution = $"{Math.Pow(baseValue, power)}";
            hint = "Hint: Use properties of exponents.";
            difficulty = DifficultyLevel.Easy;
            break;

        case "logarithm":
            int number = random.Next(1, 100);
            description = $"Solve: log({number}).";
            solution = $"{Math.Round(Math.Log10(number), 2)}";
            hint = "Hint: log(x) is the power to which 10 must be raised to equal x.";
            difficulty = DifficultyLevel.Medium;
            break;

        case "trigonometry":
            int angle = random.Next(0, 361);
            string[] trigFunctions = { "sin", "cos", "tan" };
            string trigFunc = trigFunctions[random.Next(trigFunctions.Length)];
            description = $"Evaluate {trigFunc}({angle}°) using the unit circle.";
            solution = $"Value depends on the unit circle at {angle}°.";
            hint = "Hint: Refer to the unit circle.";
            difficulty = DifficultyLevel.Medium;
            break;

        // Sequences and Series
        case "arithmetic sequence":
            int firstTerm = random.Next(1, 10);
            int commonDifference = random.Next(1, 10);
            int n = random.Next(1, 20);
            description = $"Find the nth term of the arithmetic sequence with first term {firstTerm} and common difference {commonDifference}, where n = {n}.";
            solution = $"{firstTerm + (n - 1) * commonDifference}";
            hint = "Hint: Use the formula aₙ = a₁ + (n-1)d.";
            difficulty = DifficultyLevel.Medium;
            break;

        case "geometric sequence":
            firstTerm = random.Next(1, 5);
            int commonRatio = random.Next(2, 5);
            n = random.Next(1, 10);
            description = $"Find the nth term of the geometric sequence with first term {firstTerm} and common ratio {commonRatio}, where n = {n}.";
            solution = $"{firstTerm * Math.Pow(commonRatio, n - 1):F2}";
            hint = "Hint: Use the formula aₙ = a₁r^(n-1).";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        // Limits
        case "limits":
            int limitX = random.Next(1, 10);
            description = $"Find the limit as x approaches {limitX} of f(x) = x² + 2x + 1.";
            solution = $"{Math.Pow(limitX, 2) + 2 * limitX + 1}";
            hint = "Hint: Substitute x with the value it approaches.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Intermediate;
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
        Difficulty = difficulty,
        Complexity = complexity
    };
}


public Problem GenerateCalculusProblem(string topic = "derivative")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;
    DifficultyLevel difficulty = DifficultyLevel.Hard;
    ComplexityLevel complexity = ComplexityLevel.Intermediate;

    switch (topic.ToLower())
    {
        // Calculus 1: Limits and Continuity
        case "limit":
            int a = random.Next(1, 10);
            description = $"Find the limit as x approaches {a} for f(x) = x^2 + 3x + 5.";
            solution = $"{a * a + 3 * a + 5}";
            hint = "Hint: Substitute the value of x directly.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Simple;
            break;

        case "continuity":
            description = "Is the function f(x) = 1/(x - 3) continuous at x = 3? Justify your answer.";
            solution = "No, the function is undefined at x = 3 due to division by zero.";
            hint = "Hint: Check the denominator for undefined points.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Simple;
            break;

        // Calculus 1: Derivatives
        case "derivative":
            int coefficient = random.Next(1, 10);
            int exponent = random.Next(1, 5);
            description = $"Find the derivative of f(x) = {coefficient}x^{exponent}.";
            solution = $"{coefficient * exponent}x^{exponent - 1}";
            hint = "Hint: Use the power rule: d/dx [x^n] = nx^(n-1).";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Simple;
            break;

        case "product rule":
            int u = random.Next(1, 10);
            int v = random.Next(1, 10);
            description = $"Find the derivative of f(x) = ({u}x + 2)({v}x^2 - 3).";
            solution = $"{u}({v * 2}x) + ({v}x^2 - 3)({u})";
            hint = "Hint: Use the product rule: (uv)' = u'v + uv'.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "implicit differentiation":
            description = "Find dy/dx if x^2 + y^2 = 25.";
            solution = "-x/y";
            hint = "Hint: Differentiate both sides with respect to x and solve for dy/dx.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Intermediate;
            break;

        // Calculus 1: Applications of Derivatives
        case "optimization":
            description = "Find the maximum area of a rectangle with a perimeter of 20 units.";
            solution = "25 units^2";
            hint = "Hint: Use A = l * w and 2(l + w) = 20.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        // Calculus 1: Integration
        case "integral":
            coefficient = random.Next(1, 10);
            exponent = random.Next(1, 5);
            description = $"Find the indefinite integral of f(x) = {coefficient}x^{exponent}.";
            solution = $"{coefficient / (exponent + 1)}x^{exponent + 1} + C";
            hint = "Hint: Use the formula ∫x^n dx = (1/(n+1))x^(n+1) + C.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        // Calculus 2: Sequences and Series
        case "sequence":
            int n = random.Next(1, 10);
            description = $"Find the nth term of the arithmetic sequence with first term 3 and common difference 5, where n = {n}.";
            solution = $"{3 + (n - 1) * 5}";
            hint = "Hint: Use the formula aₙ = a₁ + (n-1)d.";
            difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
            break;

        case "taylor series":
            description = "Find the first three non-zero terms of the Taylor series for e^x about x = 0.";
            solution = "1 + x + x^2/2!";
            hint = "Hint: Use the formula for Taylor series expansion.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        // Calculus 3: Multivariable Calculus
        case "partial derivative":
            description = "Find ∂f/∂x for f(x, y) = 3x^2y + y^2.";
            solution = "6xy";
            hint = "Hint: Differentiate with respect to x, treating y as constant.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "double integral":
            description = "Evaluate ∬(x^2 + y^2) dA over the region 0 ≤ x ≤ 1, 0 ≤ y ≤ 1.";
            solution = "2/3";
            hint = "Hint: Use ∫∫(x^2 + y^2) dx dy with the given bounds.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        default:
            description = "Invalid topic for Calculus.";
            solution = "N/A";
            hint = "Hint: Select a valid topic such as 'derivative', 'limit', or 'integral'.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Simple;
            break;
    }

    return new Problem
    {
        Id = random.Next(1, 10000),
        Description = description,
        Solution = solution,
        Hint = hint,
        Category = "Calculus",
        Difficulty = difficulty,
        Complexity = complexity
    };
}


public Problem GenerateLinearAlgebraProblem(string topic = "matrix")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;
    DifficultyLevel difficulty = DifficultyLevel.Hard;
    ComplexityLevel complexity = ComplexityLevel.Advanced;

    switch (topic.ToLower())
    {
        // Vectors
        case "vector magnitude":
            int x = random.Next(1, 10);
            int y = random.Next(1, 10);
            description = $"Find the magnitude of the vector ({x}, {y}).";
            solution = $"{Math.Sqrt(x * x + y * y):F2}";
            hint = "Hint: Use the formula √(x² + y²).";
            difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
            break;

        case "dot product":
            int u1 = random.Next(1, 10), u2 = random.Next(1, 10);
            int v1 = random.Next(1, 10), v2 = random.Next(1, 10);
            description = $"Find the dot product of u = ({u1}, {u2}) and v = ({v1}, {v2}).";
            solution = $"{(u1 * v1 + u2 * v2)}";
            hint = "Hint: Use the formula u • v = u1*v1 + u2*v2.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "cross product":
            int a1 = random.Next(1, 10), a2 = random.Next(1, 10), a3 = random.Next(1, 10);
            int b1 = random.Next(1, 10), b2 = random.Next(1, 10), b3 = random.Next(1, 10);
            description = $"Find the cross product of vectors A = ({a1}, {a2}, {a3}) and B = ({b1}, {b2}, {b3}).";
            solution = $"({a2 * b3 - a3 * b2}, {a3 * b1 - a1 * b3}, {a1 * b2 - a2 * b1})";
            hint = "Hint: Use the determinant of the 3x3 matrix with i, j, k unit vectors.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        // Matrices
        case "matrix determinant":
            description = "Find the determinant of the matrix:\n| 2  3 |\n| 1  4 |";
            solution = "Determinant = 2(4) - 3(1) = 5";
            hint = "Hint: Use the determinant formula for a 2x2 matrix: ad - bc.";
            difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
            break;

        case "matrix multiplication":
            description = "Multiply the matrices A = |1 2|, B = |3 4|.";
            solution = "|7 10|";
            hint = "Hint: Multiply rows of A by columns of B.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        // Determinants
        case "determinant 3x3":
            description = "Find the determinant of the matrix:\n| 1  2  3 |\n| 4  5  6 |\n| 7  8  9 |";
            solution = "Determinant = 0"; // (Singular matrix example)
            hint = "Hint: Expand along any row or column.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        // Eigenvalues and Eigenvectors
        case "eigenvalue":
            description = "Find the eigenvalues of the matrix:\n| 2  1 |\n| 1  2 |.";
            solution = "λ = 3, 1";
            hint = "Hint: Solve det(A - λI) = 0.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        case "eigenvector":
            description = "Find an eigenvector corresponding to eigenvalue λ = 3 for the matrix:\n| 2  1 |\n| 1  2 |.";
            solution = "(1, 1)";
            hint = "Hint: Solve (A - λI)v = 0.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        // Vector Spaces
        case "linear independence":
            description = "Determine if the vectors v1 = (1, 2, 3), v2 = (2, 4, 6) are linearly independent.";
            solution = "No, they are linearly dependent.";
            hint = "Hint: Check if one vector is a scalar multiple of the other.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        case "rank of matrix":
            description = "Find the rank of the matrix:\n| 1  2  3 |\n| 0  0  0 |\n| 4  5  6 |.";
            solution = "Rank = 2";
            hint = "Hint: Find the number of non-zero rows after row-reduction.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        // Linear Transformations
        case "transformation":
            description = "Determine if the matrix A = |1  0|\n|0  1| represents a rotation, reflection, or scaling.";
            solution = "Scaling with no transformation (Identity matrix).";
            hint = "Hint: Consider how the matrix transforms a standard basis vector.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        default:
            description = "Invalid topic for Linear Algebra.";
            solution = "N/A";
            hint = "Hint: Select a valid topic such as 'vector magnitude', 'eigenvalue', or 'matrix determinant'.";
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
        Category = "Linear Algebra",
        Difficulty = difficulty,
        Complexity = complexity
    };
}



public Problem GenerateDifferentialEquationsProblem(string type = "ODE")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;
    DifficultyLevel difficulty = DifficultyLevel.Hard;
    ComplexityLevel complexity = ComplexityLevel.Intermediate;

    switch (type.ToLower())
    {
        // Ordinary Differential Equations (ODEs)
        case "first-order ode":
            int coefficient = random.Next(1, 5);
            description = $"Solve the separable ODE: dy/dx = {coefficient}x.";
            solution = $"y = {coefficient / 2.0}x² + C";
            hint = "Hint: Separate variables and integrate both sides.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Simple;
            break;

        case "linear ode":
            int p = random.Next(1, 5);
            int q = random.Next(1, 5);
            description = $"Solve the linear ODE: dy/dx + {p}y = {q}.";
            solution = "Solution depends on integrating factor e^(∫P(x)dx).";
            hint = "Hint: Find the integrating factor e^(∫P(x)dx).";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "second-order homogeneous":
            int a = random.Next(1, 5);
            int b = random.Next(1, 5);
            int c = random.Next(1, 5);
            description = $"Solve the second-order homogeneous ODE: {a}y'' + {b}y' + {c}y = 0.";
            solution = "Solution depends on roots of the characteristic equation.";
            hint = "Hint: Find the roots of ar² + br + c = 0.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        case "newton's law of cooling":
            description = $"A body cools from 100°C to 70°C in 10 minutes. The surrounding temperature is 20°C. Find the temperature after 20 minutes.";
            solution = "T(t) = 20 + (100 - 20)e^(-kt).";
            hint = "Hint: Use Newton's Law of Cooling: dT/dt = -k(T - T_env).";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        // Partial Differential Equations (PDEs)
        case "heat equation":
            description = "Solve the heat equation: ∂u/∂t = k∂²u/∂x².";
            solution = "Solution depends on initial and boundary conditions.";
            hint = "Hint: Use separation of variables.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        case "wave equation":
            description = "Solve the wave equation: ∂²u/∂t² = c²∂²u/∂x².";
            solution = "Solution depends on initial and boundary conditions.";
            hint = "Hint: Use separation of variables or d'Alembert's solution.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        case "laplace equation":
            description = "Solve Laplace's equation: ∇²u = 0 in a 2D domain.";
            solution = "Solution depends on boundary conditions.";
            hint = "Hint: Use separation of variables or Fourier series.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        // Systems of Differential Equations
        case "linear system":
            description = "Solve the system: dx/dt = x + 2y, dy/dt = -x + y.";
            solution = "Solution depends on eigenvalues and eigenvectors.";
            hint = "Hint: Find eigenvalues and eigenvectors of the coefficient matrix.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        case "predator-prey":
            description = "Solve the predator-prey model: dx/dt = x(1 - y), dy/dt = -y(1 - x).";
            solution = "Solution depends on the equilibrium points.";
            hint = "Hint: Analyze stability at equilibrium points.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        // Advanced Topics
        case "euler's method":
            description = $"Approximate the solution of dy/dx = 2x with y(0) = 1 at x = 1 using Euler's method with step size h = 0.1.";
            solution = "Solution depends on iterative approximation.";
            hint = "Hint: Use the formula y_(n+1) = y_n + h*f(x_n, y_n).";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "runge-kutta":
            description = $"Approximate the solution of dy/dx = x² with y(0) = 1 at x = 1 using the 4th-order Runge-Kutta method.";
            solution = "Solution depends on iterative calculation.";
            hint = "Hint: Use k1, k2, k3, k4 for better approximation.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        default:
            description = "Invalid type for Differential Equations.";
            solution = "N/A";
            hint = "Hint: Select a valid topic such as 'first-order ODE', 'heat equation', or 'eigenvalues'.";
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
        Category = "Differential Equations",
        Difficulty = difficulty,
        Complexity = complexity
    };
}


public Problem GenerateDiscreteMathProblem(string topic = "logic")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;
    DifficultyLevel difficulty = DifficultyLevel.Medium;
    ComplexityLevel complexity = ComplexityLevel.Intermediate;

    switch (topic.ToLower())
    {
        // Logic
        case "logic":
            description = "Simplify the logical expression: (A ∧ B) ∨ (¬A ∧ B).";
            solution = "B";
            hint = "Hint: Use distribution and simplification rules.";
            difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
            break;

        case "predicate logic":
            description = "Translate 'For all x, if x is a bird then x can fly' into predicate logic.";
            solution = "∀x (Bird(x) → CanFly(x))";
            hint = "Hint: Use universal quantifier and implication.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        // Set Theory
        case "set theory":
            description = "Find A ∩ B if A = {1, 2, 3} and B = {2, 3, 4}.";
            solution = "{2, 3}";
            hint = "Hint: Intersection includes elements common to both sets.";
            difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
            break;

        case "venn diagram":
            description = "Draw a Venn diagram for sets A = {1, 2}, B = {2, 3}, and C = {3, 4}.";
            solution = "Visual representation: overlap between A, B, and C.";
            hint = "Hint: Place shared elements in intersections.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        // Combinatorics
        case "permutations":
            int n = random.Next(5, 10);
            int r = random.Next(2, n);
            description = $"Find the number of permutations of {r} items from a set of {n}.";
            solution = $"{Factorial(n) / Factorial(n - r)}";
            hint = "Hint: Use the formula nPr = n! / (n-r)!";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "combinations":
            n = random.Next(5, 10);
            r = random.Next(2, n);
            description = $"Find the number of combinations of {r} items from a set of {n}.";
            solution = $"{Factorial(n) / (Factorial(r) * Factorial(n - r))}";
            hint = "Hint: Use the formula nCr = n! / (r!(n-r)!)";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        // Graph Theory
        case "graph theory":
            description = "Find the shortest path between nodes A and E in a weighted graph.";
            solution = "Solution depends on the graph (e.g., Dijkstra's algorithm).";
            hint = "Hint: Use a shortest-path algorithm.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        case "eulerian graph":
            description = "Determine if the given graph is Eulerian.";
            solution = "Check if all vertices have even degrees.";
            hint = "Hint: An Eulerian graph has all vertices with even degrees.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        // Cryptography
       case "rsa":
        {
            int p = 3, q = 11; // Example primes
            int m = p * q, phi = (p - 1) * (q - 1);
            int e = 3; // Public key exponent
            description = $"Given p = {p}, q = {q}, and e = {e}, find the modulus n and φ(n).";
            solution = $"n = {m}, φ(n) = {phi}";
            hint = "Hint: n = p*q, φ(n) = (p-1)*(q-1).";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;
        }


        default:
            description = "Invalid topic for Discrete Mathematics.";
            solution = "N/A";
            hint = "Hint: Choose a valid topic such as 'logic', 'set theory', or 'graph theory'.";
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
        Category = "Discrete Mathematics",
        Difficulty = difficulty,
        Complexity = complexity,
    };
}

// Helper function for factorial calculation
private int Factorial(int num)
{
    if (num <= 1) return 1;
    return num * Factorial(num - 1);
}


public Problem GenerateAbstractAlgebraProblem(string topic = "groups")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;
    DifficultyLevel difficulty = DifficultyLevel.Hard;
    ComplexityLevel complexity = ComplexityLevel.Advanced;

    switch (topic.ToLower())
    {
        case "groups":
            description = "Prove that the set of integers under addition forms a group.";
            solution = "Solution involves verifying closure, associativity, identity, and inverse.";
            hint = "Hint: Use the group axioms.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "subgroups":
            description = "Prove that the set of even integers under addition forms a subgroup of integers.";
            solution = "Even integers form a subgroup as they satisfy closure, identity, and inverse.";
            hint = "Hint: Use the subgroup test.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "cosets":
            description = "Find the left cosets of H = {0, 2} in Z_4.";
            solution = "{0, 2} and {1, 3}.";
            hint = "Hint: Cosets are formed by adding elements of H to each element of Z_4.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        case "rings":
            description = "Verify if (Z, +, ×) is a commutative ring.";
            solution = "Yes, integers form a commutative ring.";
            hint = "Hint: Check the ring axioms.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "fields":
            description = "Determine if Q (rational numbers) is a field.";
            solution = "Yes, Q is a field as it satisfies all field properties.";
            hint = "Hint: Check field axioms such as commutativity, associativity, and existence of multiplicative inverses.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "polynomials":
            description = "Factorize x^2 - 5x + 6 in Z.";
            solution = "(x - 2)(x - 3)";
            hint = "Hint: Use the factorization method.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Simple;
            break;

        case "galois theory":
            description = "Determine the Galois group of x^2 - 2 over Q.";
            solution = "The Galois group is Z_2, corresponding to the field automorphism √2 ↦ -√2.";
            hint = "Hint: Use field extensions and automorphism definitions.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        case "eigenvalues":
            description = "Find the eigenvalues of the matrix:\n| 2  1 |\n| 1  2 |";
            solution = "Eigenvalues are 3 and 1.";
            hint = "Hint: Solve the characteristic equation det(A - λI) = 0.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "modules":
            description = "Prove that R^n (n-dimensional space over R) is a free module over R.";
            solution = "Proof involves showing R^n is isomorphic to a direct sum of R.";
            hint = "Hint: Use the definition of a free module.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        default:
            description = "Invalid topic for Abstract Algebra.";
            solution = "N/A";
            hint = "Hint: Choose a valid topic such as 'groups', 'rings', 'fields', or 'polynomials'.";
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
        Category = "Abstract Algebra",
        Difficulty = difficulty,
        Complexity = complexity
    };
}


public Problem GenerateProbabilityProblem(string topic = "probability")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;
    DifficultyLevel difficulty = DifficultyLevel.Medium;
    ComplexityLevel complexity = ComplexityLevel.Intermediate;

    switch (topic.ToLower())
    {
        // Basic Probability
        case "basic probability":
            description = "What is the probability of drawing an Ace from a standard deck of 52 cards?";
            solution = "4/52 or 1/13";
            hint = "Hint: There are 4 Aces in a deck.";
            difficulty = DifficultyLevel.Easy;
            complexity = ComplexityLevel.Simple;
            break;

        case "conditional probability":
            description = "Given P(A) = 0.4, P(B) = 0.5, and P(A ∩ B) = 0.2, find P(A | B).";
            solution = "P(A | B) = P(A ∩ B) / P(B) = 0.2 / 0.5 = 0.4";
            hint = "Hint: Use the formula P(A | B) = P(A ∩ B) / P(B).";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        // Counting Methods
        case "permutations":
            int n = random.Next(5, 10);
            int r = random.Next(2, n);
            description = $"Find the number of ways to arrange {r} objects out of {n} distinct objects.";
            solution = $"{Factorial(n) / Factorial(n - r)}";
            hint = "Hint: Use the formula nPr = n! / (n-r)!";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Simple;
            break;

        case "combinations":
            n = random.Next(5, 10);
            r = random.Next(2, n);
            description = $"Find the number of ways to choose {r} objects from {n} distinct objects.";
            solution = $"{Factorial(n) / (Factorial(r) * Factorial(n - r))}";
            hint = "Hint: Use the formula nCr = n! / (r!(n-r)!)";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Simple;
            break;

        // Random Variables
        case "expected value":
            int[] outcomes = { 1, 2, 3, 4, 5, 6 };
            double[] probabilities = { 1.0 / 6, 1.0 / 6, 1.0 / 6, 1.0 / 6, 1.0 / 6, 1.0 / 6 };
            description = "Find the expected value of a fair six-sided die.";
            solution = $"{CalculateExpectedValue(outcomes, probabilities)}";
            hint = "Hint: Use the formula E(X) = Σ[x * P(x)].";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "variance":
            description = "Find the variance of a fair six-sided die.";
            solution = "Variance = E(X²) - [E(X)]²";
            hint = "Hint: Use the formula Var(X) = E(X²) - [E(X)]².";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        // Statistical Inference
        case "confidence interval":
            int sampleMean = random.Next(50, 100);
            int sampleSize = random.Next(10, 30);
            double stdDev = random.Next(5, 15);
            description = $"Find the 95% confidence interval for a sample mean of {sampleMean} with standard deviation {stdDev} and sample size {sampleSize}.";
            solution = "Use the formula CI = Mean ± (Z * (StdDev / √n))";
            hint = "Hint: Z-value for 95% confidence is 1.96.";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        // Regression Analysis
        case "linear regression":
            description = "Find the line of best fit for the dataset (1,2), (2,4), (3,6).";
            solution = "y = 2x";
            hint = "Hint: Use the least squares method.";
            difficulty = DifficultyLevel.Medium;
            complexity = ComplexityLevel.Intermediate;
            break;

        case "logistic regression":
            description = "Explain how logistic regression can predict a binary outcome (e.g., pass/fail).";
            solution = "Logistic regression predicts probabilities using the sigmoid function.";
            hint = "Hint: The sigmoid function is 1 / (1 + e^(-z)).";
            difficulty = DifficultyLevel.Hard;
            complexity = ComplexityLevel.Advanced;
            break;

        default:
            description = "Invalid topic for Probability and Statistics.";
            solution = "N/A";
            hint = "Hint: Select a valid topic such as 'basic probability', 'expected value', or 'confidence interval'.";
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
        Category = "Probability and Statistics",
        Difficulty = difficulty,
        Complexity = complexity
    };
}

// Helper function to calculate factorial


// Helper function to calculate expected value
private double CalculateExpectedValue(int[] outcomes, double[] probabilities)
{
    double expectedValue = 0.0;
    for (int i = 0; i < outcomes.Length; i++)
    {
        expectedValue += outcomes[i] * probabilities[i];
    }
    return expectedValue;
}

public Problem GenerateRealAnalysisProblem(string topic = "continuity")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;
    DifficultyLevel difficulty = DifficultyLevel.Hard;
    ComplexityLevel complexity = ComplexityLevel.Advanced;

    switch (topic.ToLower())
    {
        case "continuity":
            description = "Prove that f(x) = x^2 is continuous at x = 2.";
            solution = "Solution involves using the definition of continuity: f(2) = lim x->2 f(x) = 4.";
            hint = "Hint: Check the limit definition of continuity.";
            break;

        case "differentiation":
            description = "Find the derivative of f(x) = sin(x) using the definition of the derivative.";
            solution = "f'(x) = cos(x).";
            hint = "Hint: Use lim h->0 [f(x+h) - f(x)] / h.";
            break;

        case "metric spaces":
            description = "Prove that the Euclidean metric d(x, y) = ||x - y|| satisfies the triangle inequality.";
            solution = "Use ||x - y|| + ||y - z|| >= ||x - z|| by the norm properties.";
            hint = "Hint: Apply the properties of vector norms.";
            break;

        default:
            description = "Invalid topic for Real Analysis.";
            solution = "N/A";
            break;
    }

    return new Problem
    {
        Id = random.Next(1, 10000),
        Description = description,
        Solution = solution,
        Hint = hint,
        Category = "Real Analysis",
        Difficulty = difficulty,
        Complexity = complexity
    };
}

public Problem GenerateComplexAnalysisProblem(string topic = "complex functions")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;
    DifficultyLevel difficulty = DifficultyLevel.Hard;

    switch (topic.ToLower())
    {
        case "complex functions":
            description = "Evaluate f(z) = z^2 for z = 1 + i.";
            solution = "f(z) = (1 + i)^2 = 1 + 2i - 1 = 2i.";
            hint = "Hint: Use (a + bi)^2 = a^2 + 2abi + b^2.";
            break;

        case "conformal mapping":
            description = "Show that f(z) = z^2 is a conformal map.";
            solution = "Use the Cauchy-Riemann equations to prove f(z) is holomorphic.";
            hint = "Hint: Check partial derivatives satisfy Cauchy-Riemann equations.";
            break;

        case "complex integration":
            description = "Evaluate ∫_C (z^2) dz where C is the unit circle.";
            solution = "Integral = 0 (by Cauchy-Goursat theorem).";
            hint = "Hint: Use Cauchy-Goursat theorem for analytic functions.";
            break;

        default:
            description = "Invalid topic for Complex Analysis.";
            solution = "N/A";
            break;
    }

    return new Problem
    {
        Id = random.Next(1, 10000),
        Description = description,
        Solution = solution,
        Hint = hint,
        Category = "Complex Analysis",
        Difficulty = difficulty,
        Complexity = ComplexityLevel.Advanced
    };
}

public Problem GenerateTopologyProblem(string topic = "open and closed sets")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;

    switch (topic.ToLower())
    {
        case "open and closed sets":
            description = "Prove that the interval (0, 1) is open in R.";
            solution = "Use the definition of an open set: For any x in (0, 1), there exists ε > 0 such that (x - ε, x + ε) ⊆ (0, 1).";
            hint = "Hint: Use the epsilon definition of openness.";
            break;

        default:
            description = "Invalid topic for Topology.";
            solution = "N/A";
            break;
    }

    return new Problem
    {
        Id = random.Next(1, 10000),
        Description = description,
        Solution = solution,
        Hint = hint,
        Category = "Topology",
        Difficulty = DifficultyLevel.Hard,
        Complexity = ComplexityLevel.Advanced
    };
}


public Problem GenerateNumberTheoryProblem(string topic = "divisibility")
{
    string description = string.Empty;
    string solution = string.Empty;
    string hint = string.Empty;

    switch (topic.ToLower())
    {
        case "divisibility":
            description = "Prove that 3 divides 9n for any integer n.";
            solution = "By definition of divisibility, 9n = 3(3n), so 3 divides 9n.";
            hint = "Hint: Use the definition of divisibility.";
            break;

        default:
            description = "Invalid topic for Number Theory.";
            solution = "N/A";
            break;
    }

    return new Problem
    {
        Id = random.Next(1, 10000),
        Description = description,
        Solution = solution,
        Hint = hint,
        Category = "Number Theory",
        Difficulty = DifficultyLevel.Medium,
        Complexity = ComplexityLevel.Intermediate
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
