using Loan.Domain;

namespace Loan.Application
{
    public class LoanApplicantProvider
    {
        private ILoanApplicantService _loanApplicantService;

        public LoanApplicantProvider(ILoanApplicantService loanApplicantService)
        { 
            _loanApplicantService = loanApplicantService;
        }

        public LoanApplicant GetLoanApplicantByName(string name)
        {
            return _loanApplicantService.GetByName(name);
        }

        public void SaveResult(LoanApplicationResult loanApplicaionResult)
        {
            
        }
    }
}
