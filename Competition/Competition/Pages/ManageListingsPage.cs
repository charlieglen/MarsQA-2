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
    public class ManageListingsPage
    {

        public ManageListingsPage()
        {
            PageFactory.InitElements(driver, this);
        }

        IWebElement goToManageListings => driver.FindElement(By.CssSelector("[href=\"/Home/ListingManagement\"]"));
        IWebElement viewListingsIcon => driver.FindElement(By.XPath("//*[@class=\"ui striped table\"]/tbody/tr[1]/td[8]/div/button[1]"));
        IWebElement editListingsIcon => driver.FindElement(By.XPath("//*[@class=\"ui striped table\"]/tbody/tr[1]/td[8]/div/button[2]"));
        IWebElement deleteListingsIcon => driver.FindElement(By.XPath("//*[@class=\"ui striped table\"]/tbody/tr[1]/td[8]/div/button[3]"));
        IWebElement deleteConfirm => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
        IWebElement lastListing => driver.FindElement(By.XPath("//*[@class=\"ui striped table\"]/tbody/tr[1]/td[3]"));
        
        IWebElement titleTextbox => driver.FindElement(By.Name("title"));
        IWebElement descriptionTextbox => driver.FindElement(By.Name("description"));
        IWebElement category => driver.FindElement(By.Name("categoryId"));
        IWebElement subCategory => driver.FindElement(By.Name("subcategoryId"));
        IWebElement tagsTextbox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
        IWebElement serviceTypeHourly => driver.FindElement(By.XPath("//*[@name=\"serviceType\" and @value=\"0\"]"));
        IWebElement serviceTypeOneOff => driver.FindElement(By.XPath("//*[@name=\"serviceType\" and @value=\"1\"]"));
        IWebElement locationOnSite => driver.FindElement(By.XPath("//*[@name=\"locationType\" and @value=\"0\"]"));
        IWebElement locationOnline => driver.FindElement(By.XPath("//*[@name=\"locationType\" and @value=\"1\"]"));

        // Date and Time table start
        IWebElement startDate => driver.FindElement(By.Name("startDate"));
        IWebElement endDate => driver.FindElement(By.Name("endDate"));
        IWebElement selectSunday => driver.FindElement(By.XPath("//*[@name=\"Available\" and @index=\"0\"]"));
        IWebElement selectMonday => driver.FindElement(By.XPath("//*[@name=\"Available\" and @index=\"1\"]"));
        IWebElement selectTuesday => driver.FindElement(By.XPath("//*[@name=\"Available\" and @index=\"2\"]"));
        IWebElement selectWednesday => driver.FindElement(By.XPath("//*[@name=\"Available\" and @index=\"3\"]"));
        IWebElement selectThursday => driver.FindElement(By.XPath("//*[@name=\"Available\" and @index=\"4\"]"));
        IWebElement selectFriday => driver.FindElement(By.XPath("//*[@name=\"Available\" and @index=\"5\"]"));
        IWebElement selectSaturday => driver.FindElement(By.XPath("//*[@name=\"Available\" and @index=\"6\"]"));

        IWebElement startSunday => driver.FindElement(By.XPath("//*[@name=\"StartTime\" and @index=\"0\"]"));
        IWebElement startMonday => driver.FindElement(By.XPath("//*[@name=\"StartTime\" and @index=\"1\"]"));
        IWebElement startTuesday => driver.FindElement(By.XPath("//*[@name=\"StartTime\" and @index=\"2\"]"));
        IWebElement startWednesday => driver.FindElement(By.XPath("//*[@name=\"StartTime\" and @index=\"3\"]"));
        IWebElement startThursday => driver.FindElement(By.XPath("//*[@name=\"StartTime\" and @index=\"4\"]"));
        IWebElement startFriday => driver.FindElement(By.XPath("//*[@name=\"StartTime\" and @index=\"5\"]"));
        IWebElement startSaturday => driver.FindElement(By.XPath("//*[@name=\"StartTime\" and @index=\"6\"]"));

        IWebElement endSunday => driver.FindElement(By.XPath("//*[@name=\"EndTime\" and @index=\"0\"]"));
        IWebElement endMonday => driver.FindElement(By.XPath("//*[@name=\"EndTime\" and @index=\"1\"]"));
        IWebElement endTuesday => driver.FindElement(By.XPath("//*[@name=\"EndTime\" and @index=\"2\"]"));
        IWebElement endWednesday => driver.FindElement(By.XPath("//*[@name=\"EndTime\" and @index=\"3\"]"));
        IWebElement endThursday => driver.FindElement(By.XPath("//*[@name=\"EndTime\" and @index=\"4\"]"));
        IWebElement endFriday => driver.FindElement(By.XPath("//*[@name=\"EndTime\" and @index=\"5\"]"));
        IWebElement endSaturday => driver.FindElement(By.XPath("//*[@name=\"EndTime\" and @index=\"6\"]"));
        //end

        IWebElement skillExchangeSelect => driver.FindElement(By.XPath("//*[@name=\"skillTrades\" and @value=\"true\"]"));
        IWebElement skillExchange => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
        IWebElement creditSelect => driver.FindElement(By.XPath("//*[@name=\"skillTrades\" and @value=\"false\"]"));
        IWebElement credit => driver.FindElement(By.Name("charge"));
        IWebElement workSampleUpload => driver.FindElement(By.CssSelector("[class='huge plus circle icon padding-25']"));
        IWebElement isActiveStatus => driver.FindElement(By.XPath("//*[@name=\"isActive\" and @value=\"true\"]"));
        IWebElement isHiddenStatus => driver.FindElement(By.XPath("//*[@name=\"isActive\" and @value=\"false\"]"));
        IWebElement saveButton => driver.FindElement(By.XPath("//*[@value='Save']"));
        IWebElement confirmationAlert => driver.FindElement(By.CssSelector("[class=\"ns-box ns-growl ns-effect-jelly ns-type-success ns-show\"]"));

        // Initializing Start and End dates
        List<IWebElement> daysList => new List<IWebElement>(driver.FindElements(By.XPath("//input[@name=\"Available\" and @type=\"checkbox\"]")));
        List<IWebElement> startTimeList => new List<IWebElement>(driver.FindElements(By.XPath("//input[@name=\"StartTime\" and @type=\"time\"]")));
        List<IWebElement> endTimeList => new List<IWebElement>(driver.FindElements(By.XPath("//input[@name=\"EndTime\" and @type=\"time\"]")));



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
            titleTextbox.SendKeys(ExcelLib.ReadData(2, "Title"));
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys(ExcelLib.ReadData(2, "Description"));
            category.SendKeys(ExcelLib.ReadData(2, "Category"));
            subCategory.SendKeys(ExcelLib.ReadData(2, "Subcategory"));
            tagsTextbox.Clear();
            tagsTextbox.SendKeys(ExcelLib.ReadData(2, "Tags"));
            tagsTextbox.SendKeys(Keys.Enter);

            //Service Type
            if (ExcelLib.ReadData(2, "Service Type") == "Hourly basis service")
            {
                serviceTypeHourly.Click();
            }
            else
            {
                serviceTypeOneOff.Click();
            }
            //Location Type
            if (ExcelLib.ReadData(2, "Location Type") == "On-site")
            {
                locationOnSite.Click();
            }
            else
            {
                locationOnline.Click();
            }
            // Start date and End date
            startDate.SendKeys(ExcelLib.ReadData(2, "Start date"));
            endDate.SendKeys(ExcelLib.ReadData(2, "End Date"));
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
            if (ExcelLib.ReadData(2, "Start day") == "Sun")
            {
                selectSunday.Click();
                startSunday.SendKeys(ExcelLib.ReadData(2, "Start time"));
                endSunday.SendKeys(ExcelLib.ReadData(2, "End time"));
            }
            else if (ExcelLib.ReadData(2, "Start day") == "Mon")
            {
                selectMonday.Click();
                startMonday.SendKeys(ExcelLib.ReadData(2, "Start time"));
                endMonday.SendKeys(ExcelLib.ReadData(2, "End time"));
            }
            else if (ExcelLib.ReadData(2, "Start day") == "Tue")
            {
                selectTuesday.Click();
                startTuesday.SendKeys(ExcelLib.ReadData(2, "Start time"));
                endTuesday.SendKeys(ExcelLib.ReadData(2, "End time"));
            }
            else if (ExcelLib.ReadData(2, "Start day") == "Wed")
            {
                selectWednesday.Click();
                startWednesday.SendKeys(ExcelLib.ReadData(2, "Start time"));
                endWednesday.SendKeys(ExcelLib.ReadData(2, "End time"));
            }
            else if (ExcelLib.ReadData(2, "Start day") == "Thu")
            {
                selectThursday.Click();
                startThursday.SendKeys(ExcelLib.ReadData(2, "Start time"));
                endThursday.SendKeys(ExcelLib.ReadData(2, "End time"));
            }
            else if (ExcelLib.ReadData(2, "Start day") == "Fri")
            {
                selectFriday.Click();
                startFriday.SendKeys(ExcelLib.ReadData(2, "Start time"));
                endFriday.SendKeys(ExcelLib.ReadData(2, "End time"));
            }
            else if (ExcelLib.ReadData(2, "Start day") == "Sat")
            {
                selectSaturday.Click();
                startSaturday.SendKeys(ExcelLib.ReadData(2, "Start time"));
                endSaturday.SendKeys(ExcelLib.ReadData(2, "End time"));
            }
            // Skill Trade
            if (ExcelLib.ReadData(2, "Skill Trade") == "Skill-exchange")
            {
                skillExchangeSelect.Click();

                skillExchange.SendKeys(ExcelLib.ReadData(2, "Skill Exchange"));
                skillExchange.SendKeys(Keys.Enter);
            }
            else
            {
                creditSelect.Click();
                credit.SendKeys(ExcelLib.ReadData(2, "Credit"));
            }
            // Work Samples with AutoIT
            workSampleUpload.Click();

            AutoItX3 autoIT = new AutoItX3();
            autoIT.WinActivate("Open");
            Thread.Sleep(1000);
            autoIT.Send(@"D:\Industry Connect\Internship\Tasks\MarsQA-2\Competition\Competition\AutoIT\WorkSamples\wink.png");
            Thread.Sleep(1000);
            autoIT.Send("{ENTER}");

            //Active - Hidden Status
            if (ExcelLib.ReadData(2, "Active") == "Active")
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
