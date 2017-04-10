using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using CodedUI_FDM.PageObjects;
using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
using MouseButtons = System.Windows.Forms.MouseButtons;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;


namespace CodedUI_FDM
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class Tests
    {

        public Tests()
        {
           
        }

        [TestMethod]
        public void LogInTest()
        {

            var browserWindow = BrowserWindow.Launch(new Uri("https://qa-projectforms-eus.cloudapp.net/#/d347a315-54ca-46d3-bce7-9d78d3fe4cea"));  
            LogInPage logInPage = new LogInPage(browserWindow);
            Assert.IsTrue(logInPage.LoginWithSendKeys("Rugile.Petrukauskaite@bentley.com")
                .FederatedLoginWithSendKeys("Rugile.Petrukauskaite@bentley.com", "Rugilyte2017")
                .IsCurrentPageValid()
                , "Failed to login");
        }

        [TestMethod]
        public void ExportToExcellThroughtActionsButtonTest()
        {

            var browserWindow = BrowserWindow.Launch(new Uri("https://qa-projectforms-eus.cloudapp.net/#/d347a315-54ca-46d3-bce7-9d78d3fe4cea"));
            FDMPage fdmPage = new FDMPage(browserWindow);

            fdmPage.CloseGetStartedNotification()
                .ExpandActionsButton()
                .ClickExportToExcellOnActionsButton();

            this.UIMap.SaveXLSX();
            this.UIMap.CheckIfXLSXIsDownloaded();

        }

        [TestMethod]
        public void AssignUserThroughActionsButtonTest()
        {

            var browserWindow = BrowserWindow.Launch(new Uri("https://qa-projectforms-eus.cloudapp.net/#/d347a315-54ca-46d3-bce7-9d78d3fe4cea"));
            FDMPage fdmPage = new FDMPage(browserWindow);

            Assert.IsTrue(fdmPage.CloseGetStartedNotification()
                .ClickOnTheFormInGrid()
                .ExpandActionsButton()
                .ClickToAssignUserOnActionsButton()
                .EnterUserName()
                .ClickUpdareFormsToAssignUser()
                .IsUserAssigned()
                , "Failed to assign user through Actions button");

        }

        [TestMethod]
        public void ExportToPDFThroughtActionsButtonTest()
        {

            var browserWindow = BrowserWindow.Launch(new Uri("https://qa-projectforms-eus.cloudapp.net/#/d347a315-54ca-46d3-bce7-9d78d3fe4cea"));
            FDMPage fdmPage = new FDMPage(browserWindow);

            Assert.IsTrue(fdmPage.CloseGetStartedNotification()
                .ClickOnTheFormInGrid()
                .ExpandActionsButton()
                .ClickExportToPDFOnActionsButton()
                .IsPDFDialogAppeared()
                , "Failed to export form to PDF");
        }

        [TestMethod]
        public void SetToOpenThroughtActionsButtonTest()
        {

            var browserWindow = BrowserWindow.Launch(new Uri("https://qa-projectforms-eus.cloudapp.net/#/d347a315-54ca-46d3-bce7-9d78d3fe4cea"));
            FDMPage fdmPage = new FDMPage(browserWindow);

            Assert.IsTrue(fdmPage.CloseGetStartedNotification()
                .ClickOnClosedPill()
                .ClickOnTheFormInGrid()
                .GetClosedPillValue()
                .ExpandActionsButton()
                .ClickSetToOpenOnActionsButton()
                .GetClosedPillValue()
                .IsPillNumberCorrectAfterOpening()
                , "Failed to set form to Open");
        }

        [TestMethod]
        public void SetToCloseThroughtActionsButtonTest()
        {
            var browserWindow = BrowserWindow.Launch(new Uri("https://qa-projectforms-eus.cloudapp.net/#/d347a315-54ca-46d3-bce7-9d78d3fe4cea"));
            FDMPage fdmPage = new FDMPage(browserWindow);
            Assert.IsTrue(fdmPage.CloseGetStartedNotification()
                .ClickOnTheFormInGrid()
                .GetOpenPillValue()
                .ExpandActionsButton()
                .ClickSetToCloseOnActionsButton()
                .GetOpenPillValue()
                .IsPillNumberCorrectAfterClosing()
                , "Failed to set form to Close");
        }

        [TestMethod]
        public void CreateMeetingMinutesFormThroughActionsButtonTest()
        {
            var browserWindow = BrowserWindow.Launch(new Uri("https://qa-projectforms-eus.cloudapp.net/#/d347a315-54ca-46d3-bce7-9d78d3fe4cea"));
            FDMPage fdmPage = new FDMPage(browserWindow);
            Assert.IsTrue(fdmPage.CloseGetStartedNotification()
                .ExpandActionsButton()
                .ClickToCreateMeetingMinutesFormOnActionsButton()
                .ExpandFormsList()
                .SelectMeetingMinutesFormFromTheList()
                .ClickToCreateForm()
                .FillMeetingMinuteForm()
                .ClickToSaveChanges()
                .IsFormValuesCorrect(), "Form has wrong fields values");
        }

        #region Additional test attributes
        [TestInitialize()]
        public void MyTestInitialize()
        {        
            //var browserWindow = BrowserWindow.Launch(new Uri("https://qa-projectforms-eus.cloudapp.net/#/d347a315-54ca-46d3-bce7-9d78d3fe4cea"));
            //FDMPage fdmPage = new FDMPage(browserWindow);
        }

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
