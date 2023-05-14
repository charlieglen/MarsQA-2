using AventStack.ExtentReports;
using Competition.Global;
using Competition.Pages;
using NUnit.Framework;
using System.Reflection;

namespace Competition.Tests
{
    [TestFixture]
    public class ManageListingsTest : Base
    {
         
        [Test, Order(1)]
        public void ViewListing()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            try
            {
                ManageListingsPage manageListingsPageObj = new ManageListingsPage();

                manageListingsPageObj.ManageListing();
                manageListingsPageObj.ViewListings();
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
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            try
            {
                ManageListingsPage manageListingsPageObj = new ManageListingsPage();

                testRow = 3;
                manageListingsPageObj.ManageListing();
                manageListingsPageObj.EditListing();
                manageListingsPageObj.EditTitle();
                manageListingsPageObj.EditDescription();
                manageListingsPageObj.EditCategory();
                manageListingsPageObj.EditSubCategory();
                manageListingsPageObj.EditTags();
                manageListingsPageObj.EditServiceType();
                manageListingsPageObj.EditLocationType();
                manageListingsPageObj.EditStartAndEndDate();
                manageListingsPageObj.EditDayAndTime();
                manageListingsPageObj.EditSkillTrade();
                manageListingsPageObj.EditWorkSample();
                manageListingsPageObj.EditVisibility();
                manageListingsPageObj.SaveSkill();

                string editedSkill = manageListingsPageObj.AlertWindow();
                Assert.That(editedSkill == "Service Listing Updated successfully", "Error while updating the record.");
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
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            try
            {
                ManageListingsPage manageListingsPageObj = new ManageListingsPage();

                manageListingsPageObj.ManageListing();
                manageListingsPageObj.DeleteListing();
                string deletedSkillAlert = manageListingsPageObj.AlertWindow();
                string deletetedSkill = manageListingsPageObj.GetLastListing();
                Assert.That(deletedSkillAlert == deletetedSkill + " has been deleted", "Error while deleting a record.");
                test.Log(Status.Pass, "Passed, action successfull.");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Failed, action unsuccessfull or Error while executing the test.");
                test.Log(Status.Info, ex.Message);
            }

        }
    }
}
