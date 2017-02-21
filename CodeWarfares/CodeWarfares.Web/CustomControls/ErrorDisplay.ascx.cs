using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeWarfares.Web.CustomControls
{
    public partial class ErrorDisplay : System.Web.UI.UserControl
    {
        private string errorTextValue;

        public string ErrorTextValue
        {
            get
            {
                return this.errorTextValue;
            }

            set
            {
                this.errorTextValue = value;
                this.ErrorText.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}