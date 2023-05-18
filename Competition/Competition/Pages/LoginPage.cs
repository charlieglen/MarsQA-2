using Competition.Global;
using OpenQA.Selenium;
using static Competition.Global.GlobalDefinitions;

namespace Competition.Pages
{

    public class LoginPage : Base
    {
        public LoginPage()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "LogIn");
        }

        IWebElement signinButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        IWebElement emailTextbox => driver.FindElement(By.Name("email"));
        IWebElement passwordTextbox => driver.FindElement(By.Name("password"));
        IWebElement rememberMeCheckbox => driver.FindElement(By.Name("rememberDetails"));
        IWebElement loginButton => driver.FindElement(By.XPath("//*[contains(text(),'Login')]"));

        public void LogInActions()
        {
            signinButton.Click();
            emailTextbox.SendKeys(ExcelLib.ReadData(2, "UserEmail"));
            passwordTextbox.SendKeys(ExcelLib.ReadData(2, "Password"));
            rememberMeCheckbox.Click();
            loginButton.Click();
        }
    }
}

