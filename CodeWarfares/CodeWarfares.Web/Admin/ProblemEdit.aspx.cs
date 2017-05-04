using CodeWarfares.Web.Presenters.Admin;
using CodeWarfares.Web.Views.Contracts.Admin;
using CodeWarfares.Web.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using CodeWarfares.Web.EventArguments;
using CodeWarfares.Data.Models;

namespace CodeWarfares.Web.Admin
{
    [PresenterBinding(typeof(ProblemEditPresenter))]
    public partial class ProblemEdit : MvpPage<ProblemEditModel>, IProblemEditView
    {
        public event EventHandler<ProblemEditInitEventArgs> InitProblem;
        public event EventHandler<ProblemUploadClickEventArgs> EditProblem;
        public event EventHandler<ProblemEditInitEventArgs> DeleteProblem;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = 0;
            bool canParse = int.TryParse(this.Request.QueryString["Id"], out id);

            if (canParse == false)
            {
                this.Response.Redirect("/Errors/404");
                return;
            }

            ProblemEditInitEventArgs args = new ProblemEditInitEventArgs(id);

            this.InitProblem?.Invoke(this, args);

            if (this.Model.NotFoundPage)
            {
                this.Response.Redirect("/Errors/404");
                return;
            }

            if (!IsPostBack)
            {
                this.ProblemTitle.Text = this.Model.ProblemNow.Name;
                this.ImgUrl.Text = this.Model.ProblemNow.CoverImageUrl;
                this.MaxTime.Text = this.Model.ProblemNow.MaxTime.ToString();
                this.MaxMemory.Text = this.Model.ProblemNow.MaxMemory.ToString();
                this.Points.Text = this.Model.ProblemNow.Xp.ToString();

                this.DropdownDifficulty.DataSource = this.Model.Difficulties.ToList();
                this.DropdownDifficulty.DataBind();
                this.DropdownDifficulty.SelectedIndex = this.Model.SelectedDificultyIndex;
                int testsCount = this.Model.ProblemNow.Tests.Count;

                this.TestsCount.Text = testsCount.ToString();
                ShowTextBoxes(testsCount, this.Model.ProblemNow.Tests.ToList());
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

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            bool canParse = int.TryParse(this.Request.QueryString["Id"], out id);

            if (canParse == false)
            {
                this.Response.Redirect("/Errors/404");
                return;
            }

            ProblemEditInitEventArgs args = new ProblemEditInitEventArgs(id);

            this.DeleteProblem?.Invoke(this, args);

            this.Response.Redirect("/Codings/Competitions");
        }

        protected void UploadButton_Click(object sender, EventArgs e)
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

                this.EditProblem?.Invoke(sender, args);
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

        private void ShowTextBoxes(int count, IList<Test> tests)
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
                Vhod1.Text = tests[0].TestParameter;
                Izhod1.Text = tests[0].CorrectAnswer;
            }

            if (count >= 2)
            {
                Vhod2.Visible = true;
                Izhod2.Visible = true;
                Vhod2.Text = tests[1].TestParameter;
                Izhod2.Text = tests[1].CorrectAnswer;
            }

            if (count >= 3)
            {
                Vhod3.Visible = true;
                Izhod3.Visible = true;
                Vhod3.Text = tests[2].TestParameter;
                Izhod3.Text = tests[2].CorrectAnswer;
            }

            if (count >= 4)
            {
                Vhod4.Visible = true;
                Izhod4.Visible = true;
                Vhod4.Text = tests[3].TestParameter;
                Izhod4.Text = tests[3].CorrectAnswer;
            }

            if (count >= 5)
            {
                Vhod5.Visible = true;
                Izhod5.Visible = true;
                Vhod5.Text = tests[4].TestParameter;
                Izhod5.Text = tests[4].CorrectAnswer;
            }
        }
    }
}