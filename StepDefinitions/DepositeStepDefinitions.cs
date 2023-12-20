using CustomerDepositeTest.PageObjects;
using Lab2.Drivers;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CustomerDepositeTest.StepDefinitions
{
    namespace CustomerDepositeTest.StepDefinitions
    {
        [Binding]
        public sealed class DepositeStepDefinitions
        {
            private readonly MainMenuPageObj _mainMenuPage;
            private readonly AccountPageObj _accountPage;
            private readonly ScenarioContext _scenarioContext;
            private Customer_Depo Customer_Deposite;
            public DepositeStepDefinitions(BrowserDriver browserDriver, ScenarioContext scenarioContext)
            {
                _scenarioContext = scenarioContext;
                _mainMenuPage = new MainMenuPageObj(browserDriver.Current);
                _accountPage = new AccountPageObj(browserDriver.Current);
                Customer_Deposite = new Customer_Depo();
            }

            [Given(@"Customer with: '([^']*)', '([^']*)', '([^']*)'")]
            public void GivenCustomerWith(string name, string Deposite, string Account_Number)
            {
                Customer_Deposite = new Customer_Depo(name, Deposite, Account_Number);
            }

            [When(@"I log in my personal page")]
            public void WhenILogInMyPersonalPage()
            {
                _mainMenuPage.Login_Customer_Button();
                _mainMenuPage.User_Select(Customer_Deposite.Name);
                _mainMenuPage.Login_Button();
            }

            [When(@"I choose my Account")]
            public void WhenIChooseMyAccount()
            {
                _accountPage.Account_Select(Customer_Deposite.Account_Number);
            }

            [When(@"I press ""([^""]*)"" button")]
            public void WhenIPressButton(string deposite)
            {
                _accountPage.Deposite_Button();
            }

            [When(@"fill the data")]
            public void WhenFillTheData()
            {
                _accountPage.DepositeInputButton(Customer_Deposite.Deposite);
            }

            [When(@"submit changes")]
            public void WhenSubmitChanges()
            {
                _accountPage.DepositeAcceptButton();
            }

            [Then(@"I receive the messege: Deposite Successful")]
            public void ThenIReceiveTheMessegeDepositeSuccessful()
            {
                Assert.IsTrue(_accountPage.MessegeAccepted());
            }

            [Then(@"I don`t receive the messege: Deposite Successful")]
            public void ThenIDonTReceiveTheMessegeDepositeSuccessful()
            {
                Assert.IsFalse(_accountPage.MessegeAccepted());
            }
        }
    }

}
