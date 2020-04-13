using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class AdditionController : ControllerBase
    {
        [HttpGet("math/{one}/{two}")]
        public Answers DoMath(int one, int two)
        {
            return new Answers
            {
                Product = one * two,
                Sum = one + two
            };
        }
    }

    public class Answers
    {
        public int Product { get; set; }
        public int Sum { get; set; }
    }
}