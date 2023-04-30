using NUnit.Framework;
using System;
using System.Reflection;
using System.Linq;
using Competition.Pages;
using Competition.Global;
using static Competition.Global.GlobalDefinitions;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

namespace Competition.Tests
{
    [TestFixture]
    public class ManageListingsTest : Base
    {
        
        [OneTimeSetUp]
        public void StartExtentReports()
        {
            // Initialize ExtentReports
            var htmlReporter = new ExtentHtmlReporter(ReportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("User", Environment.UserName);
            extent.AddSystemInfo("Machine Name", Environment.MachineName);
        }
        
        [Test, Order(1)]

        public void ViewListing()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod().Name);
            try
            {
                ManageListingsPage manageListingsPageObj = new ManageListingsPage();
                manageListingsPageObj.ViewListings(driver);
                test.Log(Status.Pass, "Passed, action successfull.");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Failed, action unsuccessfull or Error while executing the test.");
                test.Log(Status.Info, ex.Message);
            }
        }
        [Test, Order(2)]
        public void EditListing()
        {
            
            test = extent.CreateTest(MethodBase.GetCurrentMethod().Name);
            try
            {
                ManageListingsPage manageListingsPageObj = new ManageListingsPage();
                manageListingsPageObj.EditListing(driver);
                string editedSkill = manageListingsPageObj.alertWindow(driver);
                Assert.That(editedSkill == "Service Listing Updated successfully");
                test.Log(Status.Pass, "Passed, action successfull.");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Failed, action unsuccessfull or Error while executing the test.");
                test.Log(Status.Info, ex.Message);
            }
        }
        [Test, Order(3)]
        public void DeleteListing()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod().Name);
            try
            {
                ManageListingsPage manageListingsPageObj = new ManageListingsPage();
                manageListingsPageObj.DeleteListing(driver);
                string deletedSkillAlert = manageListingsPageObj.alertWindow(driver);
                string deletetedSkill = manageListingsPageObj.GetLastListing(driver);
                Assert.That(deletedSkillAlert == deletetedSkill + " has been deleted", "Error while deleting a record.");
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
