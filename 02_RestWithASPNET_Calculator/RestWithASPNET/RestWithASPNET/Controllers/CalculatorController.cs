using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {        
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult GetSub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("multi/{firstNumber}/{secondNumber}")]
        public IActionResult GetMulti(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                if(firstNumber.Equals("0") || secondNumber.Equals("0"))
                {
                    return BadRequest("Enter a non-zero value");
                }

                else
                {
                    var multi = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                    return Ok(multi.ToString());
                }
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("divi/{firstNumber}/{secondNumber}")]
        public IActionResult GetDivi(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                if (firstNumber.Equals("0") || secondNumber.Equals("0"))
                {
                    return BadRequest("Enter a non-zero value");
                }

                else
                {
                    var divi = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                    return Ok(divi.ToString());
                }
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("avg/{firstNumber}/{secondNumber}")]
        public IActionResult GetAvg(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                if (firstNumber.Equals("0"))
                {
                    return BadRequest("Enter a non-zero value");
                }

                else
                {
                    var avg = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                    return Ok(avg.ToString());
                }
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("root/{firstNumber}")]
        public IActionResult GetRoot(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                if(firstNumber.Equals("0"))
                {
                    return BadRequest("Enter a non-zero value");
                }

                else
                {
                    var root = (Math.Sqrt((double)ConvertToDecimal(firstNumber)));
                    return Ok(root.ToString());
                }
            }

            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }        
    }
}