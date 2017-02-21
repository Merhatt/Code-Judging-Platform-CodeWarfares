using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeWarfares.Web.CustomControls
{
    public partial class FooterControl : System.Web.UI.UserControl
    {
        private string websiteNameValue;

        public string WebsiteNameValue
        {
            get
            {
                return this.websiteNameValue;
            }
            set
            {
                this.websiteNameValue = value;
                this.WebsiteName.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}