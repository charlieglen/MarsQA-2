using AventStack.ExtentReports;
using Competition.Config;
using Competition.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Reflection;
using static Competition.Global.GlobalDefinitions;
using Competition.Global;
using AventStack.ExtentReports.Reporter;
using SeleniumExtras.PageObjects;
using AventStack.ExtentReports.Gherkin.Model;

namespace Competition.Tests
{
    [TestFixture]
    public class ShareSkillTest : Base
    {
        [OneTimeSetUp]
        public void StartExtentReports()
        {
            // Initialize ExtentReports
            var htmlReporter = new ExtentHtmlReporter(ReportPath);
            extent = new ExtentReports();
            htmlReporter.LoadConfig(@"D:\Industry Connect\Internship\Tasks\MarsQA-2\Competition\Competition\Config\XMLFile.xml");
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("User", Environment.UserName);
            extent.AddSystemInfo("Machine Name", Environment.MachineName);
        }
        [Test]
        public void AddSkill()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod().Name);
            try
            {
                ShareSkillPage shareSkillPageObj = new ShareSkillPage();
                shareSkillPageObj.ShareSkill(driver);

                string newSkill = shareSkillPageObj.alertWindow(driver);
                Assert.That(newSkill == "Service Listing Added successfully", "Error while adding a record.");
                test.Log(Status.Pass, "Passed, action successfull.");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Failed, action unsuccessfull or Error while executing the test.");
                test.Log(Status.Info, ex.Message);
            }
        }

        [OneTimeTearDown]
        public void SaveExtentReports()
        {
            // Save Extentreport html file
            extent.Flush();
        }

    }
}
