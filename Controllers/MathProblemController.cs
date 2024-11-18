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

        public MathProblemController(MathProblemService mathProblemService)
        {
            _mathProblemService = mathProblemService;
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
    }
}
