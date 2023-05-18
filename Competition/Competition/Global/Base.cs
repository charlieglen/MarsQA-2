using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Competition.Config;
using Competition.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using static Competition.Global.GlobalDefinitions;


namespace Competition.Global
{
    public class Base
    {
        //Initialize resource paths
        public static string ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        public static string ReportXMLPath = MarsResource.ReportXMLPath;
        public static int testRow = 1;

        //Initialize extent reports
        public static ExtentTest test;
        public static ExtentReports extent = new ExtentReports();

        [SetUp]
        public void Initialize()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "LogIn");

            var htmlReporter = new ExtentHtmlReporter(ReportPath);
            htmlReporter.LoadConfig(ReportXMLPath);
            extent.AttachReporter(htmlReporter);

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Link"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            LoginPage loginobj = new LoginPage();
            loginobj.LogInActions();

            Task.Delay(1500).Wait();
            string currentURL = driver.Url;
            if (currentURL != "http://localhost:5000/Account/Profile")
            {
                SignupPage signupobj = new SignupPage();
                signupobj.SignUp();
                test.Log(Status.Fail, "Invalid Credentials, Please try again. No account? Please sign up.");
            }
        }

        [TearDown]
        public void TearDown()
        {
            string img = SaveScreenShotClass.SaveScreenshot(driver, "Screenshot");
            test.AddScreenCaptureFromPath(img);
            extent.Flush();
            driver.Quit();
        }
    }
}