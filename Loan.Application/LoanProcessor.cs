using Loan.Domain;

namespace Loan.Application
{
    public class LoanProcessor
    {
        private readonly int OneMillion = 1000000;
        private readonly int OneMillionFiveHundredThousand = 1500000;
        private readonly decimal OneHundredThousand = 100000;

        public LoanApplicationResult ProcessLoanApplication(LoanApplication loanApplication)
        {
            LoanProcessorSpecification loanProcessorSpecification = GetLoanProcessorSpecification(loanApplication.LoanAmount);

            var result = ValidateApplication(loanApplication, loanProcessorSpecification);

            return result;
        }

        private LoanProcessorSpecification GetLoanProcessorSpecification(decimal loanAmount)
        {
            if (loanAmount > OneMillionFiveHundredThousand || loanAmount < OneHundredThousand)
            {
                return new LoanRejectProcessorSpecification();
            }
            if (loanAmount > OneMillion)
            {
                return new HighValueLoanProcessorSpecification();
            }
            else
            {
                return new NormalLoanProcessorSpecification();
            }
        }

        private LoanApplicationResult ValidateApplication(LoanApplication loanApplication, LoanProcessorSpecification loanProcessorSpecification)
        {
            LoanApplicationResult result = new LoanApplicationResult(loanApplication.LoanApplicant.Id, loanApplication.Id);

            var ltvValidationResult = loanProcessorSpecification.ValidateLTV(loanApplication.LTV, loanApplication.LoanApplicant.CreditScore);

            result.ApplicationApproved = ltvValidationResult.Success;

            return result;
        }
    }
}
