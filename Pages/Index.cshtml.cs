using Microsoft.AspNetCore.Mvc.RazorPages;
using MathProblemWebApp.Services;

public class IndexModel : PageModel
{
    private readonly MathProblemService _mathProblemService;

    public string Problem { get; private set; }

    public IndexModel(MathProblemService mathProblemService)
    {
        _mathProblemService = mathProblemService;
        Problem = string.Empty; // Initialize the property to an empty string or some default value
    }

    public void OnGet()
    {
        Problem = _mathProblemService.GenerateAdditionProblem(); // Generate a math problem
    }
}
