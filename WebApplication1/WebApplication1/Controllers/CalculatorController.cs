using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (CheckInputsHasValue(firstNumber,secondNumber) &&
                firstNumber.IsNumeric() && secondNumber.IsNumeric())
            {
                var sum = firstNumber.ConvertToDecimal() + secondNumber.ConvertToDecimal();
                return Ok(sum.ToString());
            }else
                _logger.Log(LogLevel.Error, @$"Inputs are not numeric, firstNumber: {firstNumber}, secondNumber: {secondNumber}");

            return BadRequest("Invalid Input");
        }

        [HttpGet("subtract/{firstNumber}/{secondNumber}")]
        public IActionResult Subtract(string firstNumber, string secondNumber)
        {
            if (CheckInputsHasValue(firstNumber, secondNumber) &&
                firstNumber.IsNumeric() && secondNumber.IsNumeric())
            {
                var subtraction = firstNumber.ConvertToDecimal() - secondNumber.ConvertToDecimal();
                return Ok(subtraction.ToString());
            }
            else
                _logger.Log(LogLevel.Error, @$"Inputs are not numeric, firstNumber: {firstNumber}, secondNumber: {secondNumber}");

            return BadRequest("Ivalid input");
        }

        [HttpGet("multiply/{firstNumber}/{secondNumber}")]
        public IActionResult Multiply(string firstNumber, string secondNumber)
        {
            if (CheckInputsHasValue(firstNumber, secondNumber) &&
                firstNumber.IsNumeric() && secondNumber.IsNumeric())
            {
                var multiplication = firstNumber.ConvertToDecimal() * secondNumber.ConvertToDecimal();
                return Ok(multiplication.ToString());
            }
            else
                _logger.Log(LogLevel.Error, @$"Inputs are not numeric, firstNumber: {firstNumber}, secondNumber: {secondNumber}");

            return BadRequest("Ivalid input");
        }

        [HttpGet("divide/{firstNumber}/{secondNumber}")]
        public IActionResult Divide(string firstNumber, string secondNumber)
        {
            if(CheckInputsHasValue(firstNumber, secondNumber) &&
                firstNumber.IsNumeric() && secondNumber.IsNumeric())
                
                return Ok(firstNumber.ConvertToDecimal()/secondNumber.ConvertToDecimal());
            else
                _logger.Log(LogLevel.Error, @$"Inputs are not numeric, firstNumber: {firstNumber}, secondNumber: {secondNumber}");

            return BadRequest("Ivalid input");
        }

        private bool CheckInputsHasValue(params string[] values)
        {
            return !values.Any(_ => _.IsEmptyOrNull());
        }

        
        
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }
    }
}
