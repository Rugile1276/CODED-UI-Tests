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

namespace CodedUI_FDM.PageObjects
{
    class LogInPage
    {

        BrowserWindow _bw;

        public LogInPage(BrowserWindow bw)
        {
            _bw = bw;
        }

        private HtmlInputButton GetLoginButton()
        {
            HtmlInputButton btn = new HtmlInputButton(_bw);
            btn.SearchProperties.Add(HtmlButton.PropertyNames.Id, "submitLogon");
            btn.SearchProperties.Add(HtmlButton.PropertyNames.ValueAttribute, "Sign In");
            return btn;
        }

        public FederatedLogInPage LoginWithSendKeys(string userName)
        {
            HtmlEdit txtUserName = new HtmlEdit(_bw);
            txtUserName.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "EmailAddress");
            txtUserName.WaitForControlExist();
            Keyboard.SendKeys(txtUserName, userName);

            
            var btn = GetLoginButton();
            Mouse.Click(btn);
            return new FederatedLogInPage(_bw);
        }
    }
}
