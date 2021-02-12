using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;

namespace RestWithAspNet.Controllers
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

        [HttpGet("sum/{firtNumber}/{secondNumber}")]
        public IActionResult Sum(string firtNumber, string secondNumber)
        {
            if (IsNumeric(firtNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firtNumber) + ConvertToDecimal(secondNumber);
                return Ok( sum.ToString());
            }

            return BadRequest("Invalid Input");
        }


        [HttpGet("sub/{firtNumber}/{secondNumber}")]
        public IActionResult Subtracto(string firtNumber, string secondNumber)
        {
            if (IsNumeric(firtNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firtNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firtNumber}/{secondNumber}")]
        public IActionResult Divisor(string firtNumber, string secondNumber)
        {
            if (IsNumeric(firtNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firtNumber) / ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }


        [HttpGet("mult/{firtNumber}/{secondNumber}")]
        public IActionResult Multiplicator(string firtNumber, string secondNumber)
        {
            if (IsNumeric(firtNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firtNumber) * ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }
        [HttpGet("mean/{firtNumber}/{secondNumber}")]
        public IActionResult Mean(string firtNumber, string secondNumber)
        {
            if (IsNumeric(firtNumber) && IsNumeric(secondNumber))
            {
                var sum = (ConvertToDecimal(firtNumber) + ConvertToDecimal(secondNumber) / 2);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }
        [HttpGet("square-root/{firtNumber}")]
        public IActionResult SquareRoot(string firtNumber)
        {
            if (IsNumeric(firtNumber))
            {
                var sum = Math.Sqrt(Convert.ToDouble(ConvertToDecimal(firtNumber)));
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;    
        }
    }
}
