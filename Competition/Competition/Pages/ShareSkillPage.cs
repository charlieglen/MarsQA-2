using OpenQA.Selenium;
using System;
using System.Linq;
using static Competition.Global.GlobalDefinitions;
using Competition.Global;
using AutoItX3Lib;
using SeleniumExtras.PageObjects;

namespace Competition.Pages
{

    public class ShareSkillPage : Base
    {
        public void ShareSkill(IWebDriver driver)
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            shareSkillButton.Click();
            titleTextbox.SendKeys(ExcelLib.ReadData(Base.testRow, "Title"));
            descriptionTextbox.SendKeys(ExcelLib.ReadData(Base.testRow, "Description"));
            category.SendKeys(ExcelLib.ReadData(Base.testRow, "Category"));
            subCategory.SendKeys(ExcelLib.ReadData(Base.testRow, "Subcategory"));
            tagsTextbox.SendKeys(ExcelLib.ReadData(Base.testRow, "Tags"));
            tagsTextbox.SendKeys(Keys.Enter);

            //Service Type
            if (ExcelLib.ReadData(Base.testRow, "Service Type") == "Hourly basis service")
            {
                serviceTypeHourly.Click();
            }
            else
            {
                serviceTypeOneOff.Click();
            }
            //Location Type
            if (ExcelLib.ReadData(Base.testRow, "Location Type") == "On-site")
            {
                locationOnSite.Click();
            }
            else
            {
                locationOnline.Click();
            }
            //Start date and End Date
            startDate.SendKeys(ExcelLib.ReadData(Base.testRow, "Start Date"));
            endDate.SendKeys(ExcelLib.ReadData(Base.testRow, "End Date"));

            if (ExcelLib.ReadData(Base.testRow, "Start Day") == "Sun")
            {
                selectSunday.Click();
                startSunday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start Time"));
                endSunday.SendKeys(ExcelLib.ReadData(Base.testRow, "End Time"));
            }
            else if (ExcelLib.ReadData(Base.testRow, "Start Day") == "Mon")
            {
                selectMonday.Click();
                startMonday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start Time"));
                endMonday.SendKeys(ExcelLib.ReadData(Base.testRow, "End Time"));
            }
            else if (ExcelLib.ReadData(Base.testRow, "Start Day") == "Tue")
            {
                selectTuesday.Click();
                startTuesday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start Time"));
                endTuesday.SendKeys(ExcelLib.ReadData(Base.testRow, "End Time"));
            }
            else if (ExcelLib.ReadData(Base.testRow, "Start Day") == "Wed")
            {
                selectWednesday.Click();
                startWednesday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start Time"));
                endWednesday.SendKeys(ExcelLib.ReadData(Base.testRow, "End Time"));
            }
            else if (ExcelLib.ReadData(Base.testRow, "Start Day") == "Thu")
            {
                selectThursday.Click();
                startThursday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start Time"));
                endThursday.SendKeys(ExcelLib.ReadData(Base.testRow, "End Time"));
            }
            else if (ExcelLib.ReadData(Base.testRow, "Start Day") == "Fri")
            {
                selectFriday.Click();
                startFriday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start Time"));
                endFriday.SendKeys(ExcelLib.ReadData(Base.testRow, "End Time"));
            }
            else if (ExcelLib.ReadData(Base.testRow, "Start Day") == "Sat")
            {
                selectSaturday.Click();
                startSaturday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start Time"));
                endSaturday.SendKeys(ExcelLib.ReadData(Base.testRow, "End Time"));
            }
            //Skill Trade
            if (ExcelLib.ReadData(Base.testRow, "Skill Trade") == "Skill-exchange")
            {
                skillExchangeSelect.Click();
                skillExchange.SendKeys(ExcelLib.ReadData(Base.testRow, "Skill Exchange"));
                skillExchange.SendKeys(Keys.Enter);
            }
            else
            {
                creditSelect.Click();
                credit.SendKeys(ExcelLib.ReadData(Base.testRow, "Credit"));

            }
            //Work Samples with AutoIT
            workSampleUpload.Click();

            AutoItX3 autoIT = new AutoItX3();
            autoIT.WinActivate("Open");
            Task.Delay(1000).Wait();
            autoIT.Send(@"D:\Industry Connect\Internship\Tasks\MarsQA-2\Competition\Competition\AutoIT\WorkSamples\" + ExcelLib.ReadData(Base.testRow, "Work Sample"));
            autoIT.Send("{ENTER}");

            //Active - Hidden Status
            if (ExcelLib.ReadData(Base.testRow, "Active") == "Active")
            {
                isActiveStatus.Click();
            }
            else
            {
                isHiddenStatus.Click();
            }
            //Save
            saveButton.Click();
        }
        public string alertWindow(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return confirmationAlert.Text;
        }

    }
}
