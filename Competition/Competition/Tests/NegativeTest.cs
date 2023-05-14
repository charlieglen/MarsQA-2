using AventStack.ExtentReports;
using Competition.Global;
using Competition.Pages;
using NUnit.Framework;
using System.Reflection;

namespace Competition.Tests
{
    [TestFixture]
    public class NegativeTest : Base
    {

        [Test, Order(2)]
        public void EmptyTitleTest()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            try
            {
                ShareSkillPage shareSkillPageObj = new ShareSkillPage();

                testRow = 3;
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

                string titleMissing = shareSkillPageObj.TitleIsRequired();
                Assert.That(titleMissing, Is.Not.Null.Or.Empty);
                test.Log(Status.Pass, "Passed. Empty Title detected.");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Failed, No Title detection failed.");
                test.Log(Status.Info, ex.Message);
            }
        }

        [Test, Order(3)]
        public void EmptyDescriptionTest()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            try
            {
                ShareSkillPage shareSkillPageObj = new ShareSkillPage();


                testRow = 4;
                shareSkillPageObj.ShareSkill();
                shareSkillPageObj.AddTitle();
                shareSkillPageObj.AddDescription();
                shareSkillPageObj.AddCategory();
                shareSkillPageObj.AddTags();
                shareSkillPageObj.AddServiceType();
                shareSkillPageObj.AddLocationType();
                shareSkillPageObj.AddStartAndEndTime();
                shareSkillPageObj.AddDayAndTime();
                shareSkillPageObj.AddSkillTrade();
                shareSkillPageObj.AddWorkSample();
                shareSkillPageObj.AddVisibility();
                shareSkillPageObj.SaveSkill();

                string descriptionMissing = shareSkillPageObj.DescriptionIsRequired();
                Assert.That(descriptionMissing, Is.Not.Null.Or.Empty);
                test.Log(Status.Pass, "Passed, Empty Description detected.");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Failed, No Description detection did not work.");
                test.Log(Status.Info, ex.Message);
            }
        }

        [Test, Order(4)]
        public void EmptyCategoryTest()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            try
            {
                ShareSkillPage shareSkillPageObj = new ShareSkillPage();

                testRow = 5;
                shareSkillPageObj.ShareSkill();
                shareSkillPageObj.AddTitle();
                shareSkillPageObj.AddDescription();
                shareSkillPageObj.AddTags();
                shareSkillPageObj.AddServiceType();
                shareSkillPageObj.AddLocationType();
                shareSkillPageObj.AddStartAndEndTime();
                shareSkillPageObj.AddDayAndTime();
                shareSkillPageObj.AddSkillTrade();
                shareSkillPageObj.AddWorkSample();
                shareSkillPageObj.AddVisibility();
                shareSkillPageObj.SaveSkill();

                string categoryMissing = shareSkillPageObj.CategoryIsRequired();
                Assert.That(categoryMissing, Is.Not.Null.Or.Empty);
                test.Log(Status.Pass, "Passed, Empty Category detected");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Failed, No Category detection did not work.");
                test.Log(Status.Info, ex.Message);
            }
        }

        [Test, Order(5)]
        public void EmptySubCategoryTest()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            try
            {
                ShareSkillPage shareSkillPageObj = new ShareSkillPage();

                testRow = 6;
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

                string subCategoryMissing = shareSkillPageObj.SubCategoryIsRequired();
                Assert.That(subCategoryMissing, Is.Not.Null.Or.Empty);
                test.Log(Status.Pass, "Passed, Empty Subcategory detected.");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Failed, No Subcategory detection did not work.");
                test.Log(Status.Info, ex.Message);
            }
        }

        [Test, Order(6)]
        public void EmptyTagsTest()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            try
            {
                ShareSkillPage shareSkillPageObj = new ShareSkillPage();

                testRow = 7;
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

                string tagsMissing = shareSkillPageObj.TagsAreRequired();
                Assert.That(tagsMissing, Is.Not.Null.Or.Empty);
                test.Log(Status.Pass, "Passed, Empty Tags detected");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Failed, No Tags detection did not work.");
                test.Log(Status.Info, ex.Message);
            }
        }

        [Test, Order(7)]
        public void SpecialCharTest()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            try
            {
                ShareSkillPage shareSkillPageObj = new ShareSkillPage();

                testRow = 8;
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

                string charTest = shareSkillPageObj.SpecialChars();
                Assert.That(charTest, Is.Not.Null.Or.Empty);
                test.Log(Status.Pass, "Passed, Special characters detected.");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Failed, Special characters detection did not work.");
                test.Log(Status.Info, ex.Message);
            }
        }

        [Test, Order(8)]
        public void CharLimits()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            try
            {
                ShareSkillPage shareSkillPageObj = new ShareSkillPage();

                testRow = 9;
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

                int charlimitTest = shareSkillPageObj.TitleCharLimit();
                Assert.That(charlimitTest < 101, "Number of characters exceeded");
                test.Log(Status.Pass, "Passed, Number of character is less than or equal the max allowed characters of 100.");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Failed, No.of characters exceeds 100.");
                test.Log(Status.Info, ex.Message);
            }
        }

        [Test, Order(9)]
        public void InvalidFileFormat()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            try
            {
                ShareSkillPage shareSkillPageObj = new ShareSkillPage();

                testRow = 10;
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

                string invalidFileNotice = shareSkillPageObj.WrongFileFormat();
                Assert.That(invalidFileNotice == "Max file size is 2 MB and supported file types are gif / jpeg / png / jpg / doc(x) / pdf / txt / xls(x)", "Invalid File Format.");
                test.Log(Status.Pass, "Passed, Invalid file format detected.");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Failed, Invalid file format detection did not work.");
                test.Log(Status.Info, ex.Message);
            }
        }
    }
}
