using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeWarfares.Web.CustomControls
{
    public partial class ErrorDisplayer : UserControl
    {
        private string errorText;

        [Category("Bahavior")]
        [Description("This is error text")]
        public string ErrorText
        {
            get
            {
                return this.errorText;
            }
            set
            {
                this.ErrorTextValue.Text = value;
                this.errorText = value;
            }
        }

        bool isLoaded = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            isLoaded = true;
        }
    }
}