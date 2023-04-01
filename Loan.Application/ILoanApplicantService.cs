using Loan.Domain;

namespace Loan.Application
{
    public interface ILoanApplicantService
    {
        LoanApplicant GetByName(string name);
    }
}