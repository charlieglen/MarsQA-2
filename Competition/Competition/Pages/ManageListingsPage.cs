using AutoItX3Lib;
using Competition.Global;
using OpenQA.Selenium;
using static Competition.Global.GlobalDefinitions;

namespace Competition.Pages
{
    public class ManageListingsPage : Base
    {
        public ManageListingsPage()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
        }

        IWebElement shareSkillButton => driver.FindElement(By.CssSelector("[href=\"/Home/ServiceListing\"]"));
        IWebElement titleTextbox => driver.FindElement(By.Name("title"));
        IWebElement descriptionTextbox => driver.FindElement(By.Name("description"));
        IWebElement category => driver.FindElement(By.Name("categoryId"));
        IWebElement subCategory => driver.FindElement(By.Name("subcategoryId"));
        IWebElement tagsTextbox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
        IWebElement tagsListed => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/span[last()]/a"));
        IWebElement serviceTypeHourly => driver.FindElement(By.XPath("//*[@name=\"serviceType\" and @value=\"0\"]"));
        IWebElement tagListedSkillEx => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/span/a"));
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
        //Manage listings element
        IWebElement goToManageListings => driver.FindElement(By.CssSelector("[href=\"/Home/ListingManagement\"]"));
        IWebElement viewListingsIcon => driver.FindElement(By.XPath("//*[@class=\"ui striped table\"]/tbody/tr[1]/td[8]/div/button[1]"));
        IWebElement editListingsIcon => driver.FindElement(By.XPath("//*[@class=\"ui striped table\"]/tbody/tr[1]/td[8]/div/button[2]"));
        IWebElement deleteListingsIcon => driver.FindElement(By.XPath("//*[@class=\"ui striped table\"]/tbody/tr[1]/td[8]/div/button[3]"));
        IWebElement deleteConfirm => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
        IWebElement lastListing => driver.FindElement(By.XPath("//*[@class=\"ui striped table\"]/tbody/tr[1]/td[3]"));
        List<IWebElement> daysList => new List<IWebElement>(driver.FindElements(By.XPath("//input[@name=\"Available\" and @type=\"checkbox\"]")));
        List<IWebElement> startTimeList => new List<IWebElement>(driver.FindElements(By.XPath("//input[@name=\"StartTime\" and @type=\"time\"]")));
        List<IWebElement> endTimeList => new List<IWebElement>(driver.FindElements(By.XPath("//input[@name=\"EndTime\" and @type=\"time\"]")));


        public void ManageListing()
        {
            goToManageListings.Click();
        }

        public void ViewListings()
        {
            viewListingsIcon.Click();
        }

        public void EditListing()
        {
            editListingsIcon.Click();
        }

        public void EditTitle()
        {
            titleTextbox.Clear();
            titleTextbox.SendKeys(ExcelLib.ReadData(testRow, "Title"));
        }

        public void EditDescription()
        {
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys(ExcelLib.ReadData(testRow, "Description"));
        }

        public void EditCategory()
        {
            category.SendKeys(ExcelLib.ReadData(testRow, "Category"));
        }

        public void EditSubCategory()
        {
            subCategory.SendKeys(ExcelLib.ReadData(testRow, "Subcategory"));
        }

        public void EditTags()
        {
            tagsListed.Click();
            tagsTextbox.Clear();
            tagsTextbox.SendKeys(ExcelLib.ReadData(testRow, "Tags"));
            tagsTextbox.SendKeys(Keys.Enter);
        }

        public void EditServiceType()
        {
            if (ExcelLib.ReadData(testRow, "Service Type") == "Hourly basis service")
            {
                serviceTypeHourly.Click();
            }
            else
            {
                serviceTypeOneOff.Click();
            }
        }

        public void EditLocationType()
        {
            if (ExcelLib.ReadData(testRow, "Location Type") == "On-site")
            {
                locationOnSite.Click();
            }
            else
            {
                locationOnline.Click();
            }
        }

        public void EditStartAndEndDate()
        {
            startDate.SendKeys(ExcelLib.ReadData(testRow, "Start Date"));
            endDate.SendKeys(ExcelLib.ReadData(testRow, "End Date"));
            //Clear Start and End Date and time
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
        }

        public void EditDayAndTime()
        {
            foreach (IWebElement startTimeValue in startTimeList)
            {
                startTimeValue.SendKeys(Keys.Control + "a");
                startTimeValue.SendKeys(Keys.Delete);
            }
            //Clear End time
            foreach (IWebElement endTimeValues in endTimeList)
            {
                endTimeValues.SendKeys(Keys.Control + "a");
                endTimeValues.SendKeys(Keys.Delete);
            }
            //Select new Start and End date and time
            switch (ExcelLib.ReadData(testRow, "Start Day"))
            {
                case "Sun":
                    selectSunday.Click();
                    startSunday.SendKeys(ExcelLib.ReadData(testRow, "Start Time"));
                    endSunday.SendKeys(ExcelLib.ReadData(testRow, "End Time"));
                    break;
                case "Mon":
                    selectMonday.Click();
                    startMonday.SendKeys(ExcelLib.ReadData(testRow, "Start Time"));
                    endMonday.SendKeys(ExcelLib.ReadData(testRow, "End Time"));
                    break;
                case "Tue":
                    selectTuesday.Click();
                    startTuesday.SendKeys(ExcelLib.ReadData(testRow, "Start Time"));
                    endTuesday.SendKeys(ExcelLib.ReadData(testRow, "End Time"));
                    break;
                case "Wed":
                    selectWednesday.Click();
                    startWednesday.SendKeys(ExcelLib.ReadData(testRow, "Start Time"));
                    endWednesday.SendKeys(ExcelLib.ReadData(testRow, "End Time"));
                    break;
                case "Thu":
                    selectThursday.Click();
                    startThursday.SendKeys(ExcelLib.ReadData(testRow, "Start Time"));
                    endThursday.SendKeys(ExcelLib.ReadData(testRow, "End Time"));
                    break;
                case "Fri":
                    selectFriday.Click();
                    startFriday.SendKeys(ExcelLib.ReadData(testRow, "Start Time"));
                    endFriday.SendKeys(ExcelLib.ReadData(testRow, "End Time"));
                    break;
                case "Sat":
                    selectSaturday.Click();
                    startSaturday.SendKeys(ExcelLib.ReadData(testRow, "Start Time"));
                    endSaturday.SendKeys(ExcelLib.ReadData(testRow, "End Time"));
                    break;
            }
        }

        public void EditSkillTrade()
        {
            if (ExcelLib.ReadData(testRow, "Skill Trade") == "Skill-exchange")
            {
                skillExchangeSelect.Click();
                tagListedSkillEx.Click();
                skillExchange.SendKeys(ExcelLib.ReadData(testRow, "Skill Exchange"));
                skillExchange.SendKeys(Keys.Enter);
            }
            else
            {
                creditSelect.Click();
                credit.SendKeys(ExcelLib.ReadData(testRow, "Credit"));
            }
        }

        public void EditWorkSample()
        {
            workSampleUpload.Click();
            AutoItX3 autoIT = new AutoItX3();
            autoIT.WinActivate("Open");
            Task.Delay(1000).Wait();
            autoIT.Send(@"D:\Industry Connect\Internship\Tasks\MarsQA-2\Competition\Competition\AutoIT\WorkSamples\" + ExcelLib.ReadData(testRow, "Work Sample"));
            autoIT.Send("{ENTER}");
        }

        public void EditVisibility()
        {
            if (ExcelLib.ReadData(testRow, "Active") == "Active")
            {
                isActiveStatus.Click();
            }
            else
            {
                isHiddenStatus.Click();
            }
        }
        public void SaveSkill()
        {
            //Save
            saveButton.Click();
        }

        public void DeleteListing()
        {
            goToManageListings.Click();
            deleteListingsIcon.Click();
            deleteConfirm.Click();
        }

        public string GetLastListing()
        {

            return lastListing.Text;
        }

        public string AlertWindow()
        {

            return confirmationAlert.Text;
        }
    }
}
