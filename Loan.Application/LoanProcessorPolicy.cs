namespace Loan.Application
{
    public abstract class LoanProcessorPolicy
    {
        public abstract LoanProcessorValidationResult ValidateLTV(decimal loanToValue, int creditScore);
    }

    public class LoanRejectProcessorPolicy : LoanProcessorPolicy
    {
        public override LoanProcessorValidationResult ValidateLTV(decimal loanToValue, int creditScore)
        {
            return LoanProcessorValidationResult.Fail;
        }
    }

    public class HighValueLoanProcessorPolicy : LoanProcessorPolicy
    {
        public override LoanProcessorValidationResult ValidateLTV(decimal loanToValue, int creditScore)
        {
            if (loanToValue < .60m && creditScore >= 950)
            {
                return LoanProcessorValidationResult.Pass;
            }

            return LoanProcessorValidationResult.Fail;
        }
    }

    public class NormalLoanProcessorPolicy : LoanProcessorPolicy
    {
        public override LoanProcessorValidationResult ValidateLTV(decimal loanToValue, int creditScore)
        {
            if (loanToValue < .60m && creditScore >= 750)
            {
                return LoanProcessorValidationResult.Pass;
            }
            else if (loanToValue < .80m && creditScore >= 800)
            {
                return LoanProcessorValidationResult.Pass;
            }
            else if (loanToValue < .90m && creditScore >= 900)
            {
                return LoanProcessorValidationResult.Pass;
            }

            return LoanProcessorValidationResult.Fail;
        }
    }
}