namespace CodedUI_FDM.PageObjects.MeetingMinutesFormPage.MeetingMinutesPageClasses
{
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
    using System.Reflection;
    using CodedUI_FDM;
    

    
    
    public partial class MeetingMinutesPage
    {
            private BrowserWindow _bw;
        

        public MeetingMinutesPage(BrowserWindow bw)
        {
            _bw = bw;
            //var a = UIDateEdit;
        }

        public MeetingMinutesPage FillMeetingMinuteForm()
        {

            HtmlControl datePicker = new HtmlControl(_bw);
            datePicker.SearchProperties.Add(HtmlControl.PropertyNames.Id, "Datepicker1Input_1");
            datePicker.DrawHighlight();
            
            Keyboard.SendKeys(datePicker, DateTime.Now.ToString("M/dd/yyyy"));
             
            HtmlControl number = new HtmlControl(_bw);
            number.SearchProperties.Add(HtmlControl.PropertyNames.Id, "TextBox2Input_1");
            number.DrawHighlight();
            Keyboard.SendKeys(number, DateTime.Now.ToString("M/dd/yyyy"));
      

            HtmlControl subject = new HtmlControl(_bw);
            subject.SearchProperties.Add(HtmlControl.PropertyNames.Id, "TextBox1Input_1");
            subject.DrawHighlight();
            Keyboard.SendKeys(subject, DateTime.Now.ToString("M/dd/yyyy"));


            HtmlControl location = new HtmlControl(_bw);
            location.SearchProperties.Add(HtmlControl.PropertyNames.Id, "TextBox3Input_1");
            location.DrawHighlight();
            Keyboard.SendKeys(location, DateTime.Now.ToString("M/dd/yyyy"));

            HtmlControl assignUser = new HtmlControl(_bw);
            assignUser.SearchProperties.Add(HtmlControl.PropertyNames.Class, "k-input kendo-form-control ng-pristine ng-untouched ng-valid");
            assignUser.DrawHighlight();
            Keyboard.SendKeys(assignUser, "Rugile Petrukauskaite");
            return this;

        }

        public MeetingMinutesPage ClickToSaveChanges()
        {
            HtmlControl btn = new HtmlControl(_bw);
            btn.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, "Save Changes");
            btn.DrawHighlight();
            Mouse.Click(btn);
            return this;
        }

        public bool IsFormValuesCorrect()
        {
            HtmlControl datePicker = this.UIFormDetailsInternetEWindow.UIFormDetailsDocument.UIDateEdit;
            string datePickerValue = this.UIFormDetailsInternetEWindow.UIFormDetailsDocument.UIDateEdit.Text;
            datePicker.WaitForControlExist();
            datePicker.DrawHighlight();
            if (datePickerValue != DateTime.Now.ToString("M/dd/yyyy"))
                return false;

            HtmlControl number = this.UIFormDetailsInternetEWindow.UIFormDetailsDocument.UINumberEdit;
            string numberValue = this.UIFormDetailsInternetEWindow.UIFormDetailsDocument.UINumberEdit.Text;
            number.DrawHighlight();
            if (numberValue != DateTime.Now.ToString("M/dd/yyyy"))
                return false;

            HtmlControl subject = this.UIFormDetailsInternetEWindow.UIFormDetailsDocument.UISubjectEdit;
            string subjectValue = this.UIFormDetailsInternetEWindow.UIFormDetailsDocument.UISubjectEdit.Text;
            subject.DrawHighlight();
            if (subjectValue != DateTime.Now.ToString("M/dd/yyyy"))
                return false;

            HtmlControl location = this.UIFormDetailsInternetEWindow.UIFormDetailsDocument.UILocationEdit;
            string locationValue = this.UIFormDetailsInternetEWindow.UIFormDetailsDocument.UILocationEdit.Text;
            location.DrawHighlight();
            if (locationValue != DateTime.Now.ToString("M/dd/yyyy"))
                return false;

            HtmlControl assignUser = this.UIFormDetailsInternetEWindow.UIFormDetailsDocument.UIUserList1_1Custom.UIItemEdit;
            string assignUserValue = this.UIFormDetailsInternetEWindow.UIFormDetailsDocument.UIUserList1_1Custom.UIItemEdit.Text;
            assignUser.DrawHighlight();
            if (assignUserValue != "Rugile Petrukauskaite")
                return false;

            return true;

        }
    }
}
