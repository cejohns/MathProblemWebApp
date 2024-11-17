using Microsoft.AspNetCore.Mvc.RazorPages;
using MathProblemWebApp.Models;
using MathProblemWebApp.Services;

public class IndexModel : PageModel
{
    private readonly MathProblemService _mathProblemService;

    public string AlgebraProblem { get; private set; } = string.Empty;
    public Problem GeneratedBasicMathProblem { get; private set; } // You can make this nullable if needed

    public IndexModel(MathProblemService mathProblemService)
    {
        _mathProblemService = mathProblemService;
        GeneratedBasicMathProblem  = new Problem(); // Initialize to avoid nullability warnings
    }

    public void OnGet()
    {
        // Correct assignment for string property
        AlgebraProblem = _mathProblemService.GenerateLinearEquationProblem().Description;
        GeneratedBasicMathProblem  = _mathProblemService.GenerateBasicMathProblem();
    }
}
