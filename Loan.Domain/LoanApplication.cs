namespace Loan.Domain
{
    public class LoanApplication
    {
        public int Id { get; set; }

        public LoanApplicant LoanApplicant { get;set;}

        public decimal LoanAmount { get; set; }

        public decimal AssetValue { get; set; }

        public decimal LTV { get { return LoanAmount / AssetValue; } }

        
    }
}