using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static Competition.Global.GlobalDefinitions;
using Competition.Global;
using NUnit.Framework;
using SeleniumExtras.PageObjects;

namespace Competition.Pages
{

    public class LoginPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(driver, this);
        }
        IWebElement signinButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        IWebElement emailTextbox => driver.FindElement(By.Name("email"));
        IWebElement passwordTextbox => driver.FindElement(By.Name("password"));
        IWebElement rememberMeCheckbox => driver.FindElement(By.Name("rememberDetails"));
        IWebElement loginButton => driver.FindElement(By.XPath("//*[contains(text(),'Login')]"));

        public void LogInActions(IWebDriver driver)
        {
            // Referencing to an excel file and sheet name
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ExcelLib.PopulateInCollection(Base.ExcelPath, "LogIn");
            
            signinButton.Click();
            emailTextbox.SendKeys(ExcelLib.ReadData(2, "UserEmail"));
            passwordTextbox.SendKeys(ExcelLib.ReadData(2, "password"));
            rememberMeCheckbox.Click();
            loginButton.Click();

        }
    }
}
       
           