// See https://aka.ms/new-console-template for more information
using Loan.Application;
using Loan.Domain;
using Moq;

Console.WriteLine("Hello, Applicant!");


string applicantName = null;
decimal m_assetValue = 0;
decimal m_loanValue = 0;

Console.WriteLine("Please enter name:");
while (applicantName is null)
{
    applicantName = Console.ReadLine();
}

Console.WriteLine("enter Asset Value:");
string assetValue = null;
while (assetValue is null)
{
    assetValue = Console.ReadLine();
    if (!decimal.TryParse(assetValue, out m_assetValue))
    {
        assetValue = null;
    }
}

Console.WriteLine("enter Loan Value:");
string loanValue = null;
while (loanValue is null)
{
    loanValue = Console.ReadLine();
    if (!decimal.TryParse(loanValue, out m_loanValue))
    {
        loanValue = null;
    }
}

Mock<ILoanApplicantService> loanApplicantServiceMock = new Mock<ILoanApplicantService>();

Random random = new Random(DateTime.UtcNow.Second);

loanApplicantServiceMock.Setup(x => x.GetByName(It.IsAny<string>())).Returns(new Loan.Domain.LoanApplicant() { CreditScore = random.Next(500, 1000) }); ; ;

LoanApplicantProvider loanApplicantProvider = new LoanApplicantProvider(loanApplicantServiceMock.Object);


var loanApplicant = loanApplicantProvider.GetLoanApplicantByName(applicantName);

Console.WriteLine("Your credit score is : " + loanApplicant.CreditScore);

LoanApplication loanApplication = new Loan.Domain.LoanApplication() { LoanApplicant = loanApplicant, AssetValue = m_assetValue, LoanAmount = m_loanValue };

Console.WriteLine("LTV is : " + loanApplication.LTV * 100 + "%");

LoanProcessor loanProcessor = new LoanProcessor();
var loanApplicaionResult = loanProcessor.ProcessLoanApplication(loanApplication);

loanApplicantProvider.SaveResult(loanApplicaionResult);

Console.WriteLine(loanApplicaionResult.ApplicationApproved ? "Approved" : "Rejected");

