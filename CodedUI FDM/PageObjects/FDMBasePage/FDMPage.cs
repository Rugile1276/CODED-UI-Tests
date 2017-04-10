using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;
using System.CodeDom.Compiler;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
using MouseButtons = System.Windows.Forms.MouseButtons;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using CodedUI_FDM.PageObjects.MeetingMinutesFormPage.MeetingMinutesPageClasses;


namespace CodedUI_FDM.PageObjects
{
    class FDMPage
    {
        private BrowserWindow _bw;
        public string OpenPillBefore = null;
        public string OpenPillAfter = null;

        public string ClosedPillBefore = null;
        public string ClosedPillAfter = null;
        
        public FDMPage(BrowserWindow bw)
        {
            _bw = bw;
        }

        #region Check if tests should pass

        public bool IsCurrentPageValid()
        {
            FDMPage fdmPage = new FDMPage(_bw);
            string fdmTitle = fdmPage.GetFDMTitle().InnerText;
            if (fdmPage.GetFDMTitle().InnerText == "All Form Data")
                return true;
            else
                return false;
        }

        public bool IsUserAssigned()
        {
            HtmlControl btn = new HtmlControl(_bw);
            btn.SearchProperties.Add(HtmlControl.PropertyNames.Class, "k-virtual-scrollable-wrap");
            btn.DrawHighlight();

            HtmlTable table = new HtmlTable(btn);
            HtmlControl cell;
            cell = table.GetCell(0, 3);
            cell.DrawHighlight();

            if (cell.InnerText == "BSI TEST")
                return true;
            else
                return false;
        }

        public bool IsPDFDialogAppeared()
        {

            HtmlControl dialog = new HtmlControl(_bw);
            dialog.SearchProperties.Add(HtmlControl.PropertyNames.Id, "dialogModalLabel");
            dialog.DrawHighlight();

            if (dialog.InnerText == "PDF Export")
                return true;
            else
                return false;
        }

        public bool IsPillNumberCorrectAfterClosing()
        {
            FDMPage fdmPage = new FDMPage(_bw);
            string fdmTitle = fdmPage.GetFDMTitle().InnerText;
            if (Int32.Parse(OpenPillBefore) == Int32.Parse(OpenPillAfter) + 1)
                return true;
            else
                return false;
        }
        public bool IsPillNumberCorrectAfterOpening()
        {
            FDMPage fdmPage = new FDMPage(_bw);
            string fdmTitle = fdmPage.GetFDMTitle().InnerText;
            if (Int32.Parse(ClosedPillBefore) + 1 == Int32.Parse(ClosedPillAfter))
                return true;
            else
                return false;
        }
        #endregion

        #region Clicks In Base FDM page

        public HtmlControl GetFDMTitle()
        {
            HtmlControl fdmTitle = new HtmlControl(_bw);
            fdmTitle.SearchProperties.Add(HtmlDiv.PropertyNames.InnerText, "All Form Data");

            return fdmTitle;
        }

        public FDMPage ExpandActionsButton()
        {
            HtmlControl btn = new HtmlControl(_bw);
            btn.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, "Actions");
            Mouse.Click(btn);
            return this;
        }
 
        public FDMPage CloseGetStartedNotification()
        {
            HtmlControl btn = new HtmlControl(_bw);
            btn.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, "Close");
            btn.DrawHighlight();
            Mouse.Click(btn);
            return this;
        }
        public FDMPage ClickOnTheFormInGrid()
        {
            HtmlControl btn = new HtmlControl(_bw);
            btn.SearchProperties.Add(HtmlControl.PropertyNames.Class, "gridcheckbox");
            UITestControlCollection collection = btn.FindMatchingControls();
            collection[0].DrawHighlight();

            Mouse.Click(collection[0]);
            return this;
        }

        #endregion

        #region Clicks in Actions button

        public FDMPage ClickExportToExcellOnActionsButton()
        {
            HtmlControl btn = new HtmlControl(_bw);
            btn.SearchProperties.Add(HtmlControl.PropertyNames.Class, "ng-scope openleft");
            UITestControlCollection collection = btn.FindMatchingControls();
            collection[0].DrawHighlight();

            Point location = collection[0].BoundingRectangle.Location;
            location.Offset(collection[0].BoundingRectangle.Width / 2,
                            collection[0].BoundingRectangle.Height / 2);

            Mouse.Click(location);
            return this;

        }

        public FDMPage ClickToAssignUserOnActionsButton()
        {
            HtmlControl btn = new HtmlControl(_bw);
            btn.SearchProperties.Add(HtmlControl.PropertyNames.Class, "ng-scope openleft");
            UITestControlCollection collection = btn.FindMatchingControls();
            collection[1].DrawHighlight();

            Point location = collection[1].BoundingRectangle.Location;
            location.Offset(collection[1].BoundingRectangle.Width / 2,
                            collection[1].BoundingRectangle.Height / 2);

            Mouse.Click(location);
            return this;
        }

        public FDMPage ClickExportToPDFOnActionsButton()
        {
            HtmlControl btn = new HtmlControl(_bw);
            btn.SearchProperties.Add(HtmlControl.PropertyNames.Class, "ng-scope openleft");
            UITestControlCollection collection = btn.FindMatchingControls();
            collection[2].DrawHighlight();

            Point location = collection[2].BoundingRectangle.Location;
            location.Offset(collection[2].BoundingRectangle.Width / 2,
                            collection[2].BoundingRectangle.Height / 2);

            Mouse.Click(location);
            return this;
        }

        public FDMPage ClickSetToCloseOnActionsButton()
        {

            HtmlControl btn = new HtmlControl(_bw);
            btn.SearchProperties.Add(HtmlControl.PropertyNames.Class, "ng-scope openleft");
            UITestControlCollection collection = btn.FindMatchingControls();
            collection[4].DrawHighlight();

            Point location = collection[4].BoundingRectangle.Location;
            location.Offset(collection[4].BoundingRectangle.Width / 2,
                            collection[4].BoundingRectangle.Height / 2);

            Mouse.Click(location);

            return this;
        }

        public FDMPage ClickSetToOpenOnActionsButton()
        {

            HtmlControl btn = new HtmlControl(_bw);
            btn.SearchProperties.Add(HtmlControl.PropertyNames.Class, "ng-scope openleft");
            UITestControlCollection collection = btn.FindMatchingControls();
            collection[3].DrawHighlight();

            Point location = collection[3].BoundingRectangle.Location;
            location.Offset(collection[3].BoundingRectangle.Width / 2,
                            collection[3].BoundingRectangle.Height / 2);

            Mouse.Click(location);

            return this;
        }

        public FDMPage ClickToCreateMeetingMinutesFormOnActionsButton()
        {

            HtmlControl btn = new HtmlControl(_bw);
            btn.SearchProperties.Add(HtmlControl.PropertyNames.Class, "ng-scope openleft");
            UITestControlCollection collection = btn.FindMatchingControls();
            collection[5].DrawHighlight();

            Point location = collection[5].BoundingRectangle.Location;
            location.Offset(collection[5].BoundingRectangle.Width / 2,
                            collection[5].BoundingRectangle.Height / 2);

            Mouse.Click(location);

            return this;
        }

        #endregion

        #region Pills

        public FDMPage GetOpenPillValue()
        {
            HtmlControl controls = new HtmlControl(_bw);
            controls.SearchProperties.Add(HtmlControl.PropertyNames.Class, "btn btn-primary ng-pristine ng-untouched ng-valid active");
            HtmlControl control = new HtmlControl(controls);

            control.SearchProperties.Add(HtmlControl.PropertyNames.Class, "issue-count-number ng-binding");
            control.DrawHighlight();
            if (OpenPillBefore == null)
                OpenPillBefore = control.InnerText;
            else
                OpenPillAfter = control.InnerText;

            return this;
        }

        public FDMPage GetClosedPillValue()
        {
            HtmlControl controls = new HtmlControl(_bw);
            controls.SearchProperties.Add(HtmlControl.PropertyNames.Class, "btn btn-primary ng-pristine ng-untouched ng-valid");
            HtmlControl control = new HtmlControl(controls);

            control.SearchProperties.Add(HtmlControl.PropertyNames.Class, "issue-count-number ng-binding");
            control.DrawHighlight();
            if (ClosedPillBefore == null)
                ClosedPillBefore = control.InnerText;
            else
                ClosedPillAfter = control.InnerText;

            return this;
        }

        public FDMPage ClickOnClosedPill()
        {

            HtmlControl pill = new HtmlControl(_bw);
            pill.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, "Closed");
            Mouse.Click(pill);

            return this;
        }

        #endregion

        #region Assign User Dialog

        public FDMPage EnterUserName()
        {
            HtmlControl btn = new HtmlControl(_bw);
            btn.SearchProperties.Add(HtmlControl.PropertyNames.Class, "k-input kendo-form-control ng-pristine ng-untouched ng-valid");
            btn.DrawHighlight();
            Keyboard.SendKeys(btn, "BSI TEST");
            return this;

        }

        public FDMPage ClickUpdareFormsToAssignUser()
        {
            HtmlControl btn = new HtmlControl(_bw);
            btn.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, "Update Forms");
            btn.DrawHighlight();
            Mouse.Click(btn);
            return this;

        }

        #endregion

        #region Create New Form Dialog
        public FDMPage ExpandFormsList()
        {
            HtmlControl btn = new HtmlControl(_bw);
            btn.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, "Choose a Form Definition from the List Below");


            UITestControlCollection collection = btn.FindMatchingControls();
            collection[0].DrawHighlight();

            Point location = collection[0].BoundingRectangle.Location;
            location.Offset(collection[0].BoundingRectangle.Width / 2,
                            collection[0].BoundingRectangle.Height / 2);
            Mouse.Click(location);
            return this;
        }

        public FDMPage SelectMeetingMinutesFormFromTheList()
        {
            HtmlControl mMForm = new HtmlControl(_bw);
            mMForm.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, "Meeting Minutes");
            mMForm.SearchProperties.Add(HtmlControl.PropertyNames.Class, "ng-binding ng-scope");
            mMForm.SearchProperties.Add(HtmlControl.PropertyNames.ValueAttribute, "e08d4769-6c86-43bb-a6f4-8e687915d5ec");
            UITestControlCollection collection = mMForm.FindMatchingControls();
            collection[0].DrawHighlight();

            Point location = collection[0].BoundingRectangle.Location;
            location.Offset(collection[0].BoundingRectangle.Width / 2,
                            collection[0].BoundingRectangle.Height + 5);
            Mouse.Click(location);
            return this;
        }

        public MeetingMinutesPage ClickToCreateForm()
        {

            HtmlControl btn = new HtmlControl(_bw);
            btn.SearchProperties.Add(HtmlControl.PropertyNames.Class, "btn btn-primary confirm ng-binding ng-scope");
            Mouse.Click(btn);

            return new MeetingMinutesPage(_bw);
        }
        #endregion
        
    }
}
