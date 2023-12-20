using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CustomerDepositeTest.PageObjects
{
    internal class AccountPageObj
    {
        private IWebDriver _webDriver;

        public AccountPageObj(IWebDriver webDriver) { _webDriver = webDriver; }

        private readonly By _accountSelect = By.Id("accountSelect");
        private readonly By _depositeButton = By.XPath("//button[@ng-class='btnClass2']");
        private readonly By _depositeInputButton = By.XPath("//input[@placeholder='amount']");
        private readonly By _depositeAccept = By.XPath("//button[@type='submit']");
        private readonly string _messegeXPath = "/html/body/div/div/div[2]/div/div[4]/div/span";

        private IWebElement AccountSelectObject => _webDriver.FindElement(_accountSelect);
        private SelectElement selectAccount => new SelectElement(AccountSelectObject);
        private IWebElement depositeButton => _webDriver.FindElement(_depositeButton);
        private IWebElement depositeInputButton => _webDriver.FindElement(_depositeInputButton);
        private IWebElement depositeAccept => _webDriver.FindElement(_depositeAccept);
        //private IWebElement messegeAccept => _webDriver.FindElement(_messege);

        public void Account_Select(string value)
        {
            Thread.Sleep(1000);
            selectAccount.SelectByText(value);
            Thread.Sleep(1000);
        }


        public void Deposite_Button()
        {
            depositeButton.Click();
            Thread.Sleep(1000);
        }

        public void DepositeInputButton(string value)
        {
            depositeInputButton.SendKeys(value);
            Thread.Sleep(1000);
        }

        public void DepositeAcceptButton()
        {
            depositeAccept.Click();
            Thread.Sleep(1000);
        }

        public bool MessegeAccepted()
        {

            try
            {
                var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(3));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_messegeXPath)));
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }

        }

    }
}