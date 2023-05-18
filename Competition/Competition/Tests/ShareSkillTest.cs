using AventStack.ExtentReports;
using Competition.Global;
using Competition.Pages;
using NUnit.Framework;
using System.Reflection;

namespace Competition.Tests
{
    [TestFixture]
    public class ShareSkillTest : Base
    {

        [Test, Order(1)]
        public void AddSkill()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            try
            {
                ShareSkillPage shareSkillPageObj = new ShareSkillPage();

                testRow = 2;
                shareSkillPageObj.ShareSkill();
                shareSkillPageObj.AddTitle();
                shareSkillPageObj.AddDescription();
                shareSkillPageObj.AddCategory();
                shareSkillPageObj.AddSubCategory();
                shareSkillPageObj.AddTags();
                shareSkillPageObj.AddServiceType();
                shareSkillPageObj.AddLocationType();
                shareSkillPageObj.AddStartAndEndTime();
                shareSkillPageObj.AddDayAndTime();
                shareSkillPageObj.AddSkillTrade();
                shareSkillPageObj.AddWorkSample();
                shareSkillPageObj.AddVisibility();
                shareSkillPageObj.SaveSkill();

                string notificationPopup = shareSkillPageObj.AlertWindow();
                Assert.That(notificationPopup == "Service Listing Added successfully");
                test.Log(Status.Pass, "Passed, action successfull.");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Failed, action unsuccessfull. Error while executing the test or some fields missing");
                test.Log(Status.Info, ex.Message);
            }
        }
    }
}
