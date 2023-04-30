using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Competition.Config;
using Competition.Pages;
using Competition.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Competition.Global.GlobalDefinitions;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;


namespace Competition.Global
{
    public class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static string ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        //public static string FileUploadPath = MarsResource.FileUploadPath;
        public static int testRow = Int32.Parse(MarsResource.testRow);

        #endregion

        #region Report and Tests for ExtentReports  

        public static ExtentReports extent;
        public static ExtentTest test;

        #endregion

        #region setup and tear down

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
            //driver.Navigate().GoToUrl("http://localhost:5000/");
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
        #endregion
    }
}