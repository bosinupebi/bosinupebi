using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace UnitTestProject1
{

    [TestFixture]
    public class Announcements: TestFixtureBase
    {
        string URL = "https://condocontrolcentral.com:500/login";

        [Test]
        public void AdminCanSendEmailPushAnnouncementToGroups()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            //Actions actions = new Actions(driver);
            
            driver.Navigate().GoToUrl(URL);

            //login to website
            DoLoginAdminOneWorkspace(driver);

            //Open announcements
            driver.FindElement(By.Id("menuitem-nav_menu_announcements")).Click();
            driver.FindElement(By.XPath("//a[@href='javascript:void(0)']")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[@href='/announcement/create']")));
            
            //create new announcement
            driver.FindElement(By.XPath("//span[@href='/announcement/create']")).Click();
            driver.FindElement(By.Name("Title")).SendKeys("New Announcement");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ck-blurred ck ck-content ck-editor__editable ck-rounded-corners ck-editor__editable_inline']")));
            driver.FindElement((By.XPath("//div[@class='ck-blurred ck ck-content ck-editor__editable ck-rounded-corners ck-editor__editable_inline']"))).SendKeys("New Announcement body for the check");
            driver.FindElement(By.Id("ExpirationDate")).SendKeys(DateTime.Now.ToString("MM/dd/yyyy"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='chosen-container chosen-container-multi']")));
            driver.FindElement((By.XPath("//div[@class='chosen-container chosen-container-multi']"))).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='chosen-drop']")));
            driver.FindElement((By.XPath("//div[@class='chosen-drop']"))).Click();
            driver.FindElement((By.Id("TermsAndConditionsAccepted"))).Click();
            driver.FindElement((By.Id("btnPostAnnouncement"))).Click();

            //Assert announcement is posted
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='alert alert-success']")));
            Assert.IsTrue(element.Displayed);
            driver.Quit();

        }
        [Test]
        public void AdminCanPostEmailPushTemplateAnnouncement()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            Actions actions = new Actions(driver);

            driver.Navigate().GoToUrl(URL);

            //login to website
            DoLoginAdminOneWorkspace(driver);

            //Open announcement templates
            driver.FindElement(By.Id("menuitem-nav_menu_announcements")).Click();
            driver.FindElement(By.XPath("//a[@href='javascript:void(0)']")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[@href='/announcement/template-landing']")));
            driver.FindElement(By.XPath("//span[@href='/announcement/template-landing']")).Click();

            //select announcement template
            driver.FindElement(By.Id("AnnouncementTemplate-35")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@href='/announcement/create?announcementTemplateID=35']")));
            driver.FindElement(By.XPath("//a[@href='/announcement/create?announcementTemplateID=35']")).Click();

            //Create the announcement
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("ExpirationDate")));
            driver.FindElement(By.Id("ExpirationDate")).SendKeys(DateTime.Now.ToString("MM / dd / yyyy"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='chosen-container chosen-container-multi']")));
            driver.FindElement((By.XPath("//div[@class='chosen-container chosen-container-multi']"))).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='chosen-drop']")));
            driver.FindElement((By.XPath("//div[@class='chosen-drop']"))).Click();
            driver.FindElement((By.Id("TermsAndConditionsAccepted"))).Click();
            driver.FindElement((By.Id("btnPostAnnouncement"))).Click();

            //Assert announcement is posted
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='alert alert-success']")));
            Assert.IsTrue(element.Displayed);
            driver.Quit();
        }
        [Test]
        public void AdminCanPostEmailpushAnnouncementUnits()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            Actions actions = new Actions(driver);

            driver.Navigate().GoToUrl(URL);

            //login to website
            DoLoginAdminOneWorkspace(driver);

            //create new announcement
            driver.FindElement(By.XPath("//span[@href='/announcement/create']")).Click();
            driver.FindElement(By.Name("Title")).SendKeys("New Announcement");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ck-blurred ck ck-content ck-editor__editable ck-rounded-corners ck-editor__editable_inline']")));
            driver.FindElement((By.XPath("//div[@class='ck-blurred ck ck-content ck-editor__editable ck-rounded-corners ck-editor__editable_inline']"))).SendKeys("New Announcement body for the check");
            driver.FindElement(By.Id("ExpirationDate")).SendKeys(DateTime.Now.ToString("MM/dd/yyyy"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='chosen-container chosen-container-multi']")));
            driver.FindElement((By.XPath("//div[@class='chosen-container chosen-container-multi']"))).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='chosen-drop']")));
            driver.FindElement((By.XPath("//div[@class='chosen-drop']"))).Click();
            driver.FindElement((By.Id("TermsAndConditionsAccepted"))).Click();
            driver.FindElement((By.Id("btnPostAnnouncement"))).Click();
        }
        [Test]
        public void AdminCanPostLobbyDisplayAnnouncement()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            Actions actions = new Actions(driver);

            driver.Navigate().GoToUrl(URL);

            //login to website
            DoLoginAdminOneWorkspace(driver);
        }
        [Test]
        public void AdminCanViewListPage()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            Actions actions = new Actions(driver);

            driver.Navigate().GoToUrl(URL);

            //login to website
            DoLoginAdminOneWorkspace(driver);

            //Open announcements list page
            driver.FindElement(By.Id("menuitem-nav_menu_announcements")).Click();
            Assert.AreEqual(driver.Url, "https://condocontrolcentral.com:500/announcement/show-list/");
        }
        public void ResidentCanViewListPage()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            Actions actions = new Actions(driver);

            driver.Navigate().GoToUrl(URL);

            //login to website
            DoLoginResident(driver);

            //Open announcements list page
            driver.FindElement(By.Id("menuitem-nav_menu_announcements")).Click();
            Assert.AreEqual(driver.Url, "https://condocontrolcentral.com:500/announcement/show-list/");
        }
        public void AdminCanEditAnnouncement()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            Actions actions = new Actions(driver);

            driver.Navigate().GoToUrl(URL);

            //login to website
            DoLoginResident(driver);

            //Open announcements list page
            driver.FindElement(By.Id("menuitem-nav_menu_announcements")).Click();
           // Assert.AreEqual(driver.Url, "https://condocontrolcentral.com:500/announcement/show-list/");
        }

        public void UserCanViewAnnouncementDetails()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            Actions actions = new Actions(driver);

            driver.Navigate().GoToUrl(URL);

            //login to website
            DoLoginResident(driver);

            //Open announcements list page
            driver.FindElement(By.Id("menuitem-nav_menu_announcements")).Click();
            // Assert.AreEqual(driver.Url, "https://condocontrolcentral.com:500/announcement/show-list/");
        }

    }
}
