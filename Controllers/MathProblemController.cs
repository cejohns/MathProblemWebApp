using Microsoft.AspNetCore.Mvc;
using MathProblemWebApp.Services;
using MathProblemWebApp.Models;

namespace MathProblemWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MathProblemController : ControllerBase
    {
        private readonly MathProblemService _mathProblemService;
         private readonly HintService _hintService; // Injected HintService

       public MathProblemController(MathProblemService mathProblemService, HintService hintService)
    {
        _mathProblemService = mathProblemService;
        _hintService = hintService;
    }

        // Endpoint to get a basic arithmetic problem
        [HttpGet("arithmetic/{operation}")]
        public ActionResult<Problem> GetArithmeticProblem(string operation)
        {
            try
            {
                var problem = _mathProblemService.GenerateProblem(operation);
                return Ok(problem);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        // Endpoint to get a linear equation problem
        [HttpGet("linear")]
        public ActionResult<Problem> GetLinearProblem()
        {
            var problem = _mathProblemService.GenerateLinearEquationProblem();
            return Ok(problem);
        }

        // Endpoint to get a quadratic equation problem
        [HttpGet("quadratic")]
        public ActionResult<Problem> GetQuadraticProblem()
        {
            var problem = _mathProblemService.GenerateQuadraticEquationProblem();
            return Ok(problem);
        }

        // Additional endpoints for other problem types can be added here
         // Endpoint to get a problem and a hint
    [HttpGet("problem-with-hint")]
    public ActionResult GetProblemWithHint()
    {
        // Generate a problem (e.g., linear equation)
        var problem = _mathProblemService.GenerateLinearEquationProblem(); // Example problem generation
        
        // Get a hint for the generated problem
        var hint = _hintService.GetHint(problem);

        return Ok(new { Problem = problem, Hint = hint });
    }
    }
}
