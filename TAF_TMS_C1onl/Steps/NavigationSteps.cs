using NUnit.Framework.Internal;
using OpenQA.Selenium;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Pages;

namespace TAF_TMS_C1onl.Steps;

public class NavigationSteps : BaseStep
{
    public NavigationSteps(IWebDriver driver) : base(driver) { }


    public LoginPage NavigateToLoginPage()
    {
        return new LoginPage(Driver, true);
    }
    
    public DashboardPage SuccessfulLogin(string username, string psw)
    {
        Login(username, psw);
        return DashboardPage;
    }

    public DashboardPage SuccessfulLogin(User user)
    {
        return SuccessfulLogin(user.Username, user.Password);
    }

    public LoginPage IncorrectLogin(string username, string psw)
    {
        Login(username, psw);
        return LoginPage;
    }

    private void Login(string username, string psw)
    {
        LoginPage.EmailInput().SendKeys(username);
        LoginPage.PswInput().SendKeys(psw);
        LoginPage.LoginInButton().Click();
    }

}