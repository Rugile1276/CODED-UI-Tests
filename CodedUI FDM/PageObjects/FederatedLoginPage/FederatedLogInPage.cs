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
using CodedUI_FDM.PageObjects;

namespace CodedUI_FDM.PageObjects
{
    class FederatedLogInPage
    {
        private BrowserWindow _bw;

        public FederatedLogInPage(BrowserWindow bw)
        {
            _bw = bw;
        }

        private HtmlControl GetFederatedLoginButton()
        {
            HtmlControl btnFed = new HtmlControl(_bw);
            btnFed.SearchProperties.Add(HtmlControl.PropertyNames.Id, "submitButton");
            btnFed.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, "Prisijungti");
            return btnFed;
        }


        public FDMPage FederatedLoginWithSendKeys(string userName, string passWord)
        {

            HtmlControl txtUserNameFederated = new HtmlControl(_bw);
            txtUserNameFederated.SearchProperties[HtmlControl.PropertyNames.Id] = "userNameInput";
            Keyboard.SendKeys(txtUserNameFederated, userName);

            HtmlEdit txtPassWord = new HtmlEdit(_bw);
            txtPassWord.SearchProperties.Add(HtmlEdit.PropertyNames.Type, "password");
            Keyboard.SendKeys(txtPassWord, passWord);

            var btn = GetFederatedLoginButton();
            Mouse.Click(btn);
            return new FDMPage(_bw);
        }


    }
}
