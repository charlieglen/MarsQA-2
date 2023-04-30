using OpenQA.Selenium;
using System;
using System.Linq;
using static Competition.Global.GlobalDefinitions;
using Competition.Global;
using AutoItX3Lib;
using SeleniumExtras.PageObjects;

namespace Competition.Pages
{

    public class ShareSkillPage
    {
        public ShareSkillPage()
        {
            PageFactory.InitElements(driver, this);
        }
        IWebElement shareSkillButton => driver.FindElement(By.CssSelector("[href=\"/Home/ServiceListing\"]"));
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

        public void ShareSkill()
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

            startDate.SendKeys(ExcelLib.ReadData(Base.testRow, "Start date"));
            endDate.SendKeys(ExcelLib.ReadData(Base.testRow, "End Date"));

            //Start Date
            if (ExcelLib.ReadData(2, "Start day") == "Sun")
            {
                selectSunday.Click();
                startSunday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start time"));
                endSunday.SendKeys(ExcelLib.ReadData(Base.testRow, "End time"));
            }
            else if (ExcelLib.ReadData(2, "Start day") == "Mon")
            {
                selectMonday.Click();
                startMonday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start time"));
                endMonday.SendKeys(ExcelLib.ReadData(Base.testRow, "End time"));
            }
            else if (ExcelLib.ReadData(2, "Start day") == "Tue")
            {
                selectTuesday.Click();
                startTuesday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start time"));
                endTuesday.SendKeys(ExcelLib.ReadData(Base.testRow, "End time"));
            }
            else if (ExcelLib.ReadData(2, "Start day") == "Wed")
            {
                selectWednesday.Click();
                startWednesday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start time"));
                endWednesday.SendKeys(ExcelLib.ReadData(Base.testRow, "End time"));
            }
            else if (ExcelLib.ReadData(2, "Start day") == "Thu")
            {
                selectThursday.Click();
                startThursday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start time"));
                endThursday.SendKeys(ExcelLib.ReadData(Base.testRow, "End time"));
            }
            else if (ExcelLib.ReadData(2, "Start day") == "Fri")
            {
                selectFriday.Click();
                startFriday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start time"));
                endFriday.SendKeys(ExcelLib.ReadData(Base.testRow, "End time"));
            }
            else if (ExcelLib.ReadData(2, "Start day") == "Sat")
            {
                selectSaturday.Click();
                startSaturday.SendKeys(ExcelLib.ReadData(Base.testRow, "Start time"));
                endSaturday.SendKeys(ExcelLib.ReadData(Base.testRow, "End time"));
            }
            //Skill Trade
            if (ExcelLib.ReadData(2, "Skill Trade") == "Skill-exchange")
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
            Thread.Sleep(1000);
            autoIT.Send(@"D:\Industry Connect\Internship\Tasks\MarsQA-2\Competition\Competition\AutoIT\WorkSamples\wink.png");
            Thread.Sleep(1000);
            autoIT.Send("{ENTER}");

            //Active / Hidden Status
            Thread.Sleep(1000);
            if (ExcelLib.ReadData(2, "Active") == "Active")
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

            IWebElement confirmationAlert = driver.FindElement(By.CssSelector("[class=\"ns-box ns-growl ns-effect-jelly ns-type-success ns-show\"]"));
            return confirmationAlert.Text;
        }

    }
}
