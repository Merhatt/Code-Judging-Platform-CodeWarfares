using CodeWarfares.Web.Presenters.Admin;
using CodeWarfares.Web.Views.Contracts.Admin;
using CodeWarfares.Web.Views.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using CodeWarfares.Web.EventArguments;

namespace CodeWarfares.Web.Admin
{
    [PresenterBinding(typeof(ProblemUploadPresenter))]
    public partial class ProblemUpload : MvpPage<ProblemUploadModel>, IProblemUploadView
    {
        public event EventHandler<ProblemUploadClickEventArgs> ProblemUploadEvent;
        public event EventHandler MyInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.MyInit.Invoke(sender, e);

            if (IsPostBack == false)
            {
                this.DropdownDifficulty.DataSource = this.Model.Difficulties.ToList();

                DropdownDifficulty.DataBind();
            }

            int textBoxes = 0;

            int.TryParse(this.TestsCount.Text, out textBoxes);

            ShowTextBoxes(textBoxes);
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (DescriptionUpload.HasFile)
                {
                    List<Tuple<string, string>> allTests = new List<Tuple<string, string>>();

                    int testCount = 0;
                    int.TryParse(this.TestsCount.Text, out testCount);

                    if (testCount <= 0 || testCount > 5)
                    {
                        this.ErrorDisplay.Visible = true;
                        this.ErrorDisplay.ErrorTextValue = "Тестовете трябва да са между 1 и 5";
                        return;
                    }

                    if (testCount >= 1)
                    {
                        allTests.Add(new Tuple<string, string>(Vhod1.Text, Izhod1.Text));
                    }
                    if (testCount >= 2)
                    {
                        allTests.Add(new Tuple<string, string>(Vhod2.Text, Izhod2.Text));
                    }
                    if (testCount >= 3)
                    {
                        allTests.Add(new Tuple<string, string>(Vhod3.Text, Izhod3.Text));
                    }
                    if (testCount >= 4)
                    {
                        allTests.Add(new Tuple<string, string>(Vhod4.Text, Izhod4.Text));
                    }
                    if (testCount >= 5)
                    {
                        allTests.Add(new Tuple<string, string>(Vhod5.Text, Izhod5.Text));
                    }

                    long maxTime = 0;
                    long.TryParse(this.MaxTime.Text, out maxTime);

                    long maxMemory = 0;
                    long.TryParse(this.MaxMemory.Text, out maxMemory);

                    int points = 0;
                    int.TryParse(this.Points.Text, out points);

                    var args = new ProblemUploadClickEventArgs(DescriptionUpload.FileName, this.ProblemTitle.Text,
                        this.ImgUrl.Text, maxTime, maxMemory,
                        points, testCount, allTests, this.DropdownDifficulty.SelectedItem.Text);

                    this.ProblemUploadEvent?.Invoke(sender, args);
                }

                if (this.Model.ShouldUploadFile && this.Model.IsErrorActive == false)
                {
                    try
                    {
                        string path = Server.MapPath(this.Model.FileUploadPath);
                        DescriptionUpload.PostedFile.SaveAs(path);
                        this.Response.Redirect("/Codings/Competitions.aspx");
                    }
                    catch (Exception ex)
                    {
                        this.ErrorDisplay.Visible = true;
                        this.ErrorDisplay.ErrorTextValue = "Изберете файл с формати .docx";
                    }
                }
                else
                {
                    if (this.Model.IsErrorActive)
                    {
                        this.Model.IsErrorActive = false;
                        this.ErrorDisplay.Visible = true;
                        this.ErrorDisplay.ErrorTextValue = this.Model.ErrorText;
                    }
                    else
                    {
                        this.ErrorDisplay.Visible = true;
                        this.ErrorDisplay.ErrorTextValue = "Изберете файл с формат .docx";
                    }
                }
            }
        }

        protected void TestsCount_TextChanged(object sender, EventArgs e)
        {
            int textBoxes = 0;

            int.TryParse(this.TestsCount.Text, out textBoxes);

            ShowTextBoxes(textBoxes);
        }

        private void ShowTextBoxes(int count)
        {
            Vhod1.Visible = false;
            Vhod2.Visible = false;
            Vhod3.Visible = false;
            Vhod4.Visible = false;
            Vhod5.Visible = false;

            Izhod1.Visible = false;
            Izhod2.Visible = false;
            Izhod3.Visible = false;
            Izhod4.Visible = false;
            Izhod5.Visible = false;

            this.IzhodPanel.Visible = true;
            this.VhodPanel.Visible = true;

            if (count <= 0 || count > 5)
            {
                this.IzhodPanel.Visible = false;
                this.VhodPanel.Visible = false;
            }

            if ((count <= 0 || count > 5) && IsPostBack)
            {
                this.ErrorDisplay.Visible = true;
                this.ErrorDisplay.ErrorTextValue = "Тестовете трябва да са между 1 и 5";
                return;
            }

            if (count >= 1)
            {
                Vhod1.Visible = true;
                Izhod1.Visible = true;
            }

            if (count >= 2)
            {
                Vhod2.Visible = true;
                Izhod2.Visible = true;
            }

            if (count >= 3)
            {
                Vhod3.Visible = true;
                Izhod3.Visible = true;
            }

            if (count >= 4)
            {
                Vhod4.Visible = true;
                Izhod4.Visible = true;
            }

            if (count >= 5)
            {
                Vhod5.Visible = true;
                Izhod5.Visible = true;
            }
        }
    }
}