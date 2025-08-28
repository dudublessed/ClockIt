using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Shared.DTOs.EmailDTOs
{
    public class CodeValidationDTO
    {
        public string InputCode { get; set; }
        public string ExpectedCode { get; set; }
        public DateTime GenerationTimeUtc { get; private set; }
        public const double ExpirationMinutes = 5;

        public CodeValidationDTO(string inputCode, string expectedCode) {
            InputCode = inputCode;
            ExpectedCode = expectedCode;
            GenerationTimeUtc = DateTime.UtcNow;
        }
    }
}
