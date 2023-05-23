using Allure.Commons;
using NUnit.Allure.Attributes;
using TAF_TMS_C1onl.Utilites.Configuration;

namespace TAF_TMS_C1onl.Tests;

public class LoginTest : BaseTest
{
    [Test(Description = "Successful Login")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("User")]
    [AllureSuite("PassedSuit")]
    [AllureSubSuite("GUI")]
    [AllureIssue(name:"TMS-12")]
    [AllureTms(name:"TMS-13")]
    [AllureTag("Smoke")]
    [AllureLink(url:"https://onliner.by")]
    [Description("More details description")]
    public void SuccessLoginTest()
    {
        NavigationSteps.NavigateToLoginPage();
        NavigationSteps.SuccessfulLogin(Configurator.Admin);
        
        Assert.IsTrue(NavigationSteps.DashboardPage.IsPageOpened());
    }
}