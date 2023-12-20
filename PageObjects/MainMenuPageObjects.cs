using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CustomerDepositeTest.PageObjects
{
    internal class MainMenuPageObj
    {
        private IWebDriver _webDriver;

        public MainMenuPageObj(IWebDriver webDriver) { _webDriver = webDriver; }

        private readonly By _usertypeButton = By.XPath("//button[@ng-click='customer()']");
        private readonly By _userSelect = By.Id("userSelect");
        private readonly By _loginButton = By.XPath("//button[@type='submit']");


        private IWebElement LoginCustomerUserButton => _webDriver.FindElement(_usertypeButton);
        private IWebElement CustomerSelectObject => _webDriver.FindElement(_userSelect);
        private SelectElement selectCustomer => new SelectElement(CustomerSelectObject);
        private IWebElement UserLoginButton => _webDriver.FindElement(_loginButton);



        public void Login_Customer_Button()
        {
            Thread.Sleep(1000);
            LoginCustomerUserButton.Click();
            Thread.Sleep(1000);
        }
        public void User_Select(string text)
        {
            Thread.Sleep(1000);
            selectCustomer.SelectByText(text);
            Thread.Sleep(1000);
        }
        public void Login_Button()
        {
            UserLoginButton.Click();
            Thread.Sleep(1000);
        }
    }
}

