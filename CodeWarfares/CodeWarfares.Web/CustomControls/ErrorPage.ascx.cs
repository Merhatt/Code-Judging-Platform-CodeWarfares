using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeWarfares.Web.CustomControls
{
    public partial class ErrorPage : System.Web.UI.UserControl
    {
        private string errorCode;

        public string ErrorCode
        {
            get
            {
                return this.errorCode;
            }
            set
            {
                this.errorCode = value;
                this.ErrorCodeValue.Text = value;
            }
        }
    }
}