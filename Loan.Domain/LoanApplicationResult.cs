namespace Loan.Domain
{
    public class LoanApplicationResult
    {
        public LoanApplicationResult(int loanApplicantId, int loanApplicationId)
        {
            LoanApplicantId = loanApplicantId;
            LoanApplicationId = loanApplicationId;
        }

        public int LoanApplicationId { get; set; }

        public int LoanApplicantId { get; set; }

        public bool ApplicationApproved { get; set; }
    }
}
