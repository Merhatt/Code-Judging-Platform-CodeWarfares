using System;
using CodeWarfares.Web.EventArguments;
using CodeWarfares.Web.Presenters.Contracts.Admin;
using CodeWarfares.Web.Views.Contracts.Admin;
using WebFormsMvp;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using System.Collections.Generic;
using CodeWarfares.Data.Models.Enums;
using System.Linq;
using System.IO;

namespace CodeWarfares.Web.Presenters.Admin
{
    public class ProblemEditPresenter : Presenter<IProblemEditView>, IProblemEditPresenter
    {
        private IProblemService problemService;
        private IDictionary<string, DifficultyType> difficulties;

        public ProblemEditPresenter(IProblemEditView view, IProblemService problemService) : base(view)
        {
            if (problemService == null)
            {
                throw new NullReferenceException("problemService cannot be null");
            }

            this.problemService = problemService;

            this.difficulties = new Dictionary<string, DifficultyType>();
            this.difficulties.Add("Лесно", DifficultyType.Easy);
            this.difficulties.Add("Средно", DifficultyType.Medium);
            this.difficulties.Add("Трудно", DifficultyType.Hard);
            this.difficulties.Add("Много Трудно", DifficultyType.VeryHard);

            view.InitProblem += InitProblem;
            view.EditProblem += EditProblem;
            view.DeleteProblem += DeleteProblem;
        }

        private void DeleteProblem(object sender, ProblemEditInitEventArgs e)
        {
            this.problemService.DeleteProblem(e.Id);
        }

        private void EditProblem(object sender, ProblemUploadClickEventArgs e)
        {
            bool fileOK = false;
            string path = "~/ProblemDescriptions/ProblemDescription";

            string fileExtension =
                Path.GetExtension(e.FileName).ToLower();
            string[] allowedExtensions = { ".docx" };

            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    fileOK = true;
                    break;
                }
            }

            if (fileOK)
            {
                if (string.IsNullOrEmpty(e.ProblemName))
                {
                    this.View.Model.IsErrorActive = true;
                    this.View.Model.ErrorText = "Дължината на името на задачата трябва да е по голям от 0";
                    return;
                }
                else if (string.IsNullOrEmpty(e.ImgUrl))
                {
                    this.View.Model.IsErrorActive = true;
                    this.View.Model.ErrorText = "Дължината на линка на снимката трябва да е по голям от 0";
                    return;
                }
                else if (e.MaxMemory <= 0)
                {
                    this.View.Model.IsErrorActive = true;
                    this.View.Model.ErrorText = "Максималната памет трябва да е над 0";
                    return;
                }
                else if (e.MaxTime <= 0)
                {
                    this.View.Model.IsErrorActive = true;
                    this.View.Model.ErrorText = "Максималното време трябва да е над 0";
                    return;
                }
                else if (e.Points <= 0)
                {
                    this.View.Model.IsErrorActive = true;
                    this.View.Model.ErrorText = "Tочките трябва да са над 0";
                    return;
                }
                else if (e.TestsCount <= 0)
                {
                    this.View.Model.IsErrorActive = true;
                    this.View.Model.ErrorText = "Тестовете трябва да са повече от 0";
                    return;
                }
                else
                {
                    foreach (var test in e.Tests)
                    {
                        if (string.IsNullOrEmpty(test.Item1) || string.IsNullOrEmpty(test.Item2))
                        {
                            this.View.Model.IsErrorActive = true;
                            this.View.Model.ErrorText = "Дъжлината на тестовете трябва да са повече от 0";
                            return;
                        }
                    }
                }

                ICollection<Test> newTests = new List<Test>();

                foreach (var test in e.Tests)
                {
                    var testToAdd = new Test();
                    testToAdd.TestParameter = test.Item1;
                    testToAdd.CorrectAnswer = test.Item2;

                    newTests.Add(testToAdd);
                }

                this.problemService.EditProblem(this.View.Model.ProblemNow.Id, e.ProblemName,
                    e.ImgUrl, e.MaxMemory, e.MaxTime, e.Points, e.TestsCount,
                    this.difficulties[e.Difficulty], newTests);

                path = path + this.View.Model.ProblemNow.Id + fileExtension;
                this.View.Model.FileUploadPath = path;
                this.View.Model.ShouldUploadFile = true;
            }
            else
            {
                this.View.Model.IsErrorActive = true;
                this.View.Model.ErrorText = "Изберете файл с формат .docx";
            }
        }

        private void InitProblem(object sender, ProblemEditInitEventArgs e)
        {
            Problem problem = this.problemService.GetById(e.Id);


            if (problem == null)
            {
                this.View.Model.NotFoundPage = true;

                return;
            }

            this.View.Model.ProblemNow = problem;
            this.View.Model.Difficulties = this.difficulties.Select(x => x.Key)
                .ToList();

            this.View.Model.SelectedDificultyIndex = this.View.Model.Difficulties
                .IndexOf(this.difficulties.FirstOrDefault(x => x.Value == problem.Difficulty)
                .Key);
        }
    }
}