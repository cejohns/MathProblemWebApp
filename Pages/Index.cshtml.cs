using Microsoft.AspNetCore.Mvc.RazorPages;
using MathProblemWebApp.Models;
using MathProblemWebApp.Services;

public class IndexModel : PageModel
{
    private readonly MathProblemService _mathProblemService;

    public Dictionary<string, Problem> MathProblems { get; private set; }

    public IndexModel(MathProblemService mathProblemService)
    {
        _mathProblemService = mathProblemService;
        MathProblems = new Dictionary<string, Problem>();
    }

    public void OnGet()
    {
        // Populate MathProblems dictionary with problems from all service methods
        MathProblems["Linear Equation"] = _mathProblemService.GenerateLinearEquationProblem();
        MathProblems["Basic Math (Addition)"] = _mathProblemService.GenerateBasicMathProblem("addition");
        MathProblems["Basic Math (Subtraction)"] = _mathProblemService.GenerateBasicMathProblem("subtraction");
        MathProblems["Basic Math (Multiplication)"] = _mathProblemService.GenerateBasicMathProblem("multiplication");
        MathProblems["Basic Math (Division)"] = _mathProblemService.GenerateBasicMathProblem("division");
        MathProblems["Basic Math (Modulo)"] = _mathProblemService.GenerateBasicMathProblem("modulo");
        MathProblems["Algebra (Factoring)"] = _mathProblemService.GenerateFactoringProblem();
        MathProblems["Algebra (Quadratic)"] = _mathProblemService.GenerateQuadraticEquationProblem();
        MathProblems["Algebra (Polynomial)"] = _mathProblemService.GeneratePolynomialProblem();
        MathProblems["Geometry (Basic Concepts)"] = _mathProblemService.GenerateGeometryProblem("basic concepts");
        MathProblems["Trigonometry (Ratios)"] = _mathProblemService.GenerateTrigonometryProblem("trig ratios");
        MathProblems["Pre-Calculus (Functions)"] = _mathProblemService.GeneratePreCalculusProblem("functions");
        MathProblems["Calculus (Derivative)"] = _mathProblemService.GenerateCalculusProblem("derivative");
        MathProblems["Linear Algebra (Matrix Determinant)"] = _mathProblemService.GenerateLinearAlgebraProblem("matrix determinant");
        MathProblems["Differential Equations (First-Order ODE)"] = _mathProblemService.GenerateDifferentialEquationsProblem("first-order ode");
        MathProblems["Discrete Math (Logic)"] = _mathProblemService.GenerateDiscreteMathProblem("logic");
        MathProblems["Abstract Algebra (Groups)"] = _mathProblemService.GenerateAbstractAlgebraProblem("groups");
    }
}
