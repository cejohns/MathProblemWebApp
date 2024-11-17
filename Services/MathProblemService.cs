using System;

namespace MathProblemWebApp.Services
{
    public class MathProblemService
    {
        private static Random random = new Random();

        public string GenerateAdditionProblem()
        {
            int a = random.Next(1, 100);
            int b = random.Next(1, 100);
            return $"Calculate: {a} + {b}";
        }
    }
}
