using OpenQA.Selenium;
using System;
using System.Linq;
using static Competition.Global.GlobalDefinitions;
using Competition.Global;
using AutoItX3Lib;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.DevTools.V85.SystemInfo;
using System.Collections.Generic;

namespace Competition.Pages
{
    public class ManageListingsPage : Base
    {
        public void ViewListings(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            goToManageListings.Click();
            viewListingsIcon.Click();
        }
        public void EditListing(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

            goToManageListings.Click();
            editListingsIcon.Click();
            titleTextbox.Clear();
            titleTextbox.SendKeys(ExcelLib.ReadData(Base.testRow, "Title"));
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys(ExcelLib.ReadData(Base.testRow, "Description"));
            category.SendKeys(ExcelLib.ReadData(Base.testRow, "Category"));
            subCategory.SendKeys(ExcelLib.ReadData(Base.testRow, "Subcategory"));
            tagsListed.Click();
            tagsTextbox.Clear();
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
            // Start date and End date
            startDate.SendKeys(ExcelLib.ReadData(Base.testRow, "Start date"));
            endDate.SendKeys(ExcelLib.ReadData(Base.testRow, "End Date"));
            // Clear Start and End Date and time
            bool daySelected = true;
            int countDays = daysList.Count();
            for (int i = 0; i < countDays; i++)
            {
                daySelected = daysList[i].Selected;
                if (daySelected)
                {
                    daysList[i].Click();
                }
            }
            // Clear Start time
            foreach (IWebElement startTimeValue in startTimeList)
            {
                startTimeValue.SendKeys(Keys.Control + "a");
                startTimeValue.SendKeys(Keys.Delete);
            }
            // Clear End time
            foreach (IWebElement endTimeValues in endTimeList)
            {
                endTimeValues.SendKeys(Keys.Control + "a");
                endTimeValues.SendKeys(Keys.Delete);
            }
            // Select new Start and End date and time
            if (ExcelLib.ReadData(Base.testRow, "Start day") == "Sun")
            {
                selectSunday.Click();
                startSunday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start time"));
                endSunday.SendKeys(ExcelLib.ReadData(Base.testRow, "End time"));
            }
            else if (ExcelLib.ReadData(Base.testRow, "Start day") == "Mon")
            {
                selectMonday.Click();
                startMonday.SendKeys(ExcelLib.ReadData(2, "Start time"));
                endMonday.SendKeys(ExcelLib.ReadData(2, "End time"));
            }
            else if (ExcelLib.ReadData(Base.testRow, "Start day") == "Tue")
            {
                selectTuesday.Click();
                startTuesday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start time"));
                endTuesday.SendKeys(ExcelLib.ReadData(Base.testRow, "End time"));
            }
            else if (ExcelLib.ReadData(Base.testRow, "Start day") == "Wed")
            {
                selectWednesday.Click();
                startWednesday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start time"));
                endWednesday.SendKeys(ExcelLib.ReadData(Base.testRow, "End time"));
            }
            else if (ExcelLib.ReadData(Base.testRow, "Start day") == "Thu")
            {
                selectThursday.Click();
                startThursday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start time"));
                endThursday.SendKeys(ExcelLib.ReadData(Base.testRow, "End time"));
            }
            else if (ExcelLib.ReadData(Base.testRow, "Start day") == "Fri")
            {
                selectFriday.Click();
                startFriday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start time"));
                endFriday.SendKeys(ExcelLib.ReadData(Base.testRow, "End time"));
            }
            else if (ExcelLib.ReadData(Base.testRow, "Start day") == "Sat")
            {
                selectSaturday.Click();
                startSaturday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start time"));
                endSaturday.SendKeys(ExcelLib.ReadData(Base.testRow, "End time"));
            }
            // Skill Trade
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
            // Work Samples with AutoIT
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
            // Save
            saveButton.Click();
        }

        public void DeleteListing(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            goToManageListings.Click();
            deleteListingsIcon.Click();
            deleteConfirm.Click();
        }

        public string GetLastListing(IWebDriver driver)
        {
            return lastListing.Text;
        }

        public string alertWindow(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return confirmationAlert.Text;
        }
    }
}
