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
            LoanProcessorPolicy loanProcessorPolicy = GetLoanProcessorPolicy(loanApplication.LoanAmount);

            var result = ValidateApplication(loanApplication, loanProcessorPolicy);

            return result;
        }

        private LoanProcessorPolicy GetLoanProcessorPolicy(decimal loanAmount)
        {
            if (loanAmount > OneMillionFiveHundredThousand || loanAmount < OneHundredThousand)
            {
                return new LoanRejectProcessorPolicy();
            }
            if (loanAmount > OneMillion)
            {
                return new HighValueLoanProcessorPolicy();
            }
            else
            {
                return new NormalLoanProcessorPolicy();
            }
        }

        private LoanApplicationResult ValidateApplication(LoanApplication loanApplication, LoanProcessorPolicy loanProcessorPolicy)
        {
            LoanApplicationResult result = new LoanApplicationResult(loanApplication.LoanApplicant.Id, loanApplication.Id);

            var ltvValidationResult = loanProcessorPolicy.ValidateLTV(loanApplication.LTV, loanApplication.LoanApplicant.CreditScore);

            result.ApplicationApproved = ltvValidationResult.Success;

            return result;
        }
    }
}
