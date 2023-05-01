using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Competition.Config;
using Competition.Pages;
using Competition.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.PageObjects;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Competition.Global.GlobalDefinitions;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;


namespace Competition.Global
{
    public class Base
    {
       
        //Initialize resource paths
        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static string ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        //public static string FileUploadPath = MarsResource.FileUploadPath;
        public static int testRow = Int32.Parse(MarsResource.testRow);

        //Initialize extent reports
        public static ExtentReports extent;
        public static ExtentTest test;

        #region Initializing web elements
        // Initialize web elements
        public static IWebElement signinButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        public static IWebElement emailTextbox => driver.FindElement(By.Name("email"));
        public static IWebElement passwordTextbox => driver.FindElement(By.Name("password"));
        public static IWebElement rememberMeCheckbox => driver.FindElement(By.Name("rememberDetails"));
        public static IWebElement loginButton => driver.FindElement(By.XPath("//*[contains(text(),'Login')]"));

        public static IWebElement shareSkillButton => driver.FindElement(By.CssSelector("[href=\"/Home/ServiceListing\"]"));
        public static IWebElement titleTextbox => driver.FindElement(By.Name("title"));
        public static IWebElement descriptionTextbox => driver.FindElement(By.Name("description"));
        public static IWebElement category => driver.FindElement(By.Name("categoryId"));
        public static IWebElement subCategory => driver.FindElement(By.Name("subcategoryId"));
        public static IWebElement tagsTextbox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
        public static IWebElement tagsListed => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/span[last()]/a"));
        public static IWebElement serviceTypeHourly => driver.FindElement(By.XPath("//*[@name=\"serviceType\" and @value=\"0\"]"));
        public static IWebElement serviceTypeOneOff => driver.FindElement(By.XPath("//*[@name=\"serviceType\" and @value=\"1\"]"));
        public static IWebElement locationOnSite => driver.FindElement(By.XPath("//*[@name=\"locationType\" and @value=\"0\"]"));
        public static IWebElement locationOnline => driver.FindElement(By.XPath("//*[@name=\"locationType\" and @value=\"1\"]"));

        // Date and Time table start
        public static IWebElement startDate => driver.FindElement(By.Name("startDate"));
        public static IWebElement endDate => driver.FindElement(By.Name("endDate"));
        public static IWebElement selectSunday => driver.FindElement(By.XPath("//*[@name=\"Available\" and @index=\"0\"]"));
        public static IWebElement selectMonday => driver.FindElement(By.XPath("//*[@name=\"Available\" and @index=\"1\"]"));
        public static IWebElement selectTuesday => driver.FindElement(By.XPath("//*[@name=\"Available\" and @index=\"2\"]"));
        public static IWebElement selectWednesday => driver.FindElement(By.XPath("//*[@name=\"Available\" and @index=\"3\"]"));
        public static IWebElement selectThursday => driver.FindElement(By.XPath("//*[@name=\"Available\" and @index=\"4\"]"));
        public static IWebElement selectFriday => driver.FindElement(By.XPath("//*[@name=\"Available\" and @index=\"5\"]"));
        public static IWebElement selectSaturday => driver.FindElement(By.XPath("//*[@name=\"Available\" and @index=\"6\"]"));

        public static IWebElement startSunday => driver.FindElement(By.XPath("//*[@name=\"StartTime\" and @index=\"0\"]"));
        public static IWebElement startMonday => driver.FindElement(By.XPath("//*[@name=\"StartTime\" and @index=\"1\"]"));
        public static IWebElement startTuesday => driver.FindElement(By.XPath("//*[@name=\"StartTime\" and @index=\"2\"]"));
        public static IWebElement startWednesday => driver.FindElement(By.XPath("//*[@name=\"StartTime\" and @index=\"3\"]"));
        public static IWebElement startThursday => driver.FindElement(By.XPath("//*[@name=\"StartTime\" and @index=\"4\"]"));
        public static IWebElement startFriday => driver.FindElement(By.XPath("//*[@name=\"StartTime\" and @index=\"5\"]"));
        public static IWebElement startSaturday => driver.FindElement(By.XPath("//*[@name=\"StartTime\" and @index=\"6\"]"));

        public static IWebElement endSunday => driver.FindElement(By.XPath("//*[@name=\"EndTime\" and @index=\"0\"]"));
        public static IWebElement endMonday => driver.FindElement(By.XPath("//*[@name=\"EndTime\" and @index=\"1\"]"));
        public static IWebElement endTuesday => driver.FindElement(By.XPath("//*[@name=\"EndTime\" and @index=\"2\"]"));
        public static IWebElement endWednesday => driver.FindElement(By.XPath("//*[@name=\"EndTime\" and @index=\"3\"]"));
        public static IWebElement endThursday => driver.FindElement(By.XPath("//*[@name=\"EndTime\" and @index=\"4\"]"));
        public static IWebElement endFriday => driver.FindElement(By.XPath("//*[@name=\"EndTime\" and @index=\"5\"]"));
        public static IWebElement endSaturday => driver.FindElement(By.XPath("//*[@name=\"EndTime\" and @index=\"6\"]"));
        //end
        public static IWebElement skillExchangeSelect => driver.FindElement(By.XPath("//*[@name=\"skillTrades\" and @value=\"true\"]"));
        public static IWebElement skillExchange => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
        public static IWebElement creditSelect => driver.FindElement(By.XPath("//*[@name=\"skillTrades\" and @value=\"false\"]"));
        public static IWebElement credit => driver.FindElement(By.Name("charge"));
        public static IWebElement workSampleUpload => driver.FindElement(By.CssSelector("[class='huge plus circle icon padding-25']"));
        public static IWebElement isActiveStatus => driver.FindElement(By.XPath("//*[@name=\"isActive\" and @value=\"true\"]"));
        public static IWebElement isHiddenStatus => driver.FindElement(By.XPath("//*[@name=\"isActive\" and @value=\"false\"]"));
        public static IWebElement saveButton => driver.FindElement(By.XPath("//*[@value='Save']"));
        public static IWebElement confirmationAlert => driver.FindElement(By.CssSelector("[class=\"ns-box ns-growl ns-effect-jelly ns-type-success ns-show\"]"));
        //Manage listings elements
        public static IWebElement goToManageListings => driver.FindElement(By.CssSelector("[href=\"/Home/ListingManagement\"]"));
        public static IWebElement viewListingsIcon => driver.FindElement(By.XPath("//*[@class=\"ui striped table\"]/tbody/tr[1]/td[8]/div/button[1]"));
        public static IWebElement editListingsIcon => driver.FindElement(By.XPath("//*[@class=\"ui striped table\"]/tbody/tr[1]/td[8]/div/button[2]"));
        public static IWebElement deleteListingsIcon => driver.FindElement(By.XPath("//*[@class=\"ui striped table\"]/tbody/tr[1]/td[8]/div/button[3]"));
        public static IWebElement deleteConfirm => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
        public static IWebElement lastListing => driver.FindElement(By.XPath("//*[@class=\"ui striped table\"]/tbody/tr[1]/td[3]"));
        public static List<IWebElement> daysList => new List<IWebElement>(driver.FindElements(By.XPath("//input[@name=\"Available\" and @type=\"checkbox\"]")));
        public static List<IWebElement> startTimeList => new List<IWebElement>(driver.FindElements(By.XPath("//input[@name=\"StartTime\" and @type=\"time\"]")));
        public static List<IWebElement> endTimeList => new List<IWebElement>(driver.FindElements(By.XPath("//input[@name=\"EndTime\" and @type=\"time\"]")));

        #endregion

        [SetUp]
        public void Initialize()
        {

            //switch (Browser)
            //{
            //    case 1:
            //        driver = new FirefoxDriver();
            //        break;
            //    case 2:
            //        driver = new ChromeDriver();
            //        break;
            //}

            // Maximize browser window
            ExcelLib.PopulateInCollection(Base.ExcelPath, "LogIn");
            // Go to base Url
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Link"));

            LoginPage loginobj = new LoginPage();
            loginobj.LogInActions(driver);
        }
        [TearDown]
        public void TearDown()
        {
            //Take a screenshot
            string img = SaveScreenShotClass.SaveScreenshot(driver, "Screenshot");
            test.AddScreenCaptureFromPath(img);

            //Quit browser
            driver.Quit();
        }
       
    }
}