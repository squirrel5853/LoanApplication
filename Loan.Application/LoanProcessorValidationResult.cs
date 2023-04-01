namespace Loan.Application
{
    public class LoanProcessorValidationResult : ValidationResult
    {
        public static LoanProcessorValidationResult Fail { get { return new LoanProcessorValidationResult(); } }
        public static LoanProcessorValidationResult Pass { get { return new LoanProcessorValidationResult() { Success = true }; } }
    }

    public class ValidationResult
    { 
        public bool Success { get; set; }
    }
}