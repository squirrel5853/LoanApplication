namespace Loan.Domain.Tests
{
    public class LoanApplicationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(100000, 50000, .50)]
        [TestCase(100000, 25000, .25)]
        public void LoanApplication_LTV_CalculatesCorrectly(decimal assetValue, decimal loanAmount, decimal expectedPercentage)
        {
            LoanApplication loanApplication = new LoanApplication();
            loanApplication.AssetValue = assetValue;
            loanApplication.LoanAmount = loanAmount;

            Assert.That(loanApplication.LTV, Is.EqualTo(expectedPercentage));
        }
    }
}