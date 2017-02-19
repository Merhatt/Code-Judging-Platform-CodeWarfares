using CodeWarfares.Web.Presenters.Contracts;
using CodeWarfares.Web.Views.Contracts.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;
using CodeWarfares.Web.EventArguments;
using System.IO;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Models.Enums;

namespace CodeWarfares.Web.Presenters.Admin
{
    public class ProblemUploadPresenter : Presenter<IProblemUploadView>, IProblemUploadPresenter
    {
        private IProblemService problemService;
        private IDictionary<string, DifficultyType> difficulties;

        public ProblemUploadPresenter(IProblemUploadView view, IProblemService problemService) : base(view)
        {
            if (problemService == null)
            {
                throw new NullReferenceException("ProblemService cannot be null");
            }

            this.problemService = problemService;

            this.difficulties = new Dictionary<string, DifficultyType>();
            this.difficulties.Add("Лесно", DifficultyType.Easy);
            this.difficulties.Add("Средно", DifficultyType.Medium);
            this.difficulties.Add("Трудно", DifficultyType.Hard);
            this.difficulties.Add("Много Трудно", DifficultyType.VeryHard);

            view.ProblemUploadEvent += ProblemUploadEvent;
            view.MyInit += Initialization;
        }

        private void Initialization(object sender, EventArgs e)
        {
            this.View.Model.Difficulties = this.difficulties.Select(x => x.Key).ToList();
        }

        private void ProblemUploadEvent(object sender, ProblemUploadClickEventArgs e)
        {
            bool fileOK = false;
            string path = "~/ProblemDescriptions/ProblemDescription";

            string fileExtension =
                Path.GetExtension(e.FileName).ToLower();
            string[] allowedExtensions = {".docx"};
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

                var problem = new Problem();
                problem.CoverImageUrl = e.ImgUrl;
                problem.MaxMemory = e.MaxMemory;
                problem.MaxTime = e.MaxTime;
                problem.Name = e.ProblemName;
                problem.Xp = e.Points;
                problem.TestsCount = e.TestsCount;
                problem.Difficulty = this.difficulties[e.Difficulty];

                foreach (var test in e.Tests)
                {
                    var testToAdd = new Test();
                    testToAdd.TestParameter = test.Item1;
                    testToAdd.CorrectAnswer = test.Item2;

                    problem.Tests.Add(testToAdd);
                }

                this.problemService.Create(problem);

                path = path + problem.Id + fileExtension;
                this.View.Model.FileUploadPath = path;
                this.View.Model.ShouldUploadFile = true;
            }
            else
            {
                this.View.Model.IsErrorActive = true;
                this.View.Model.ErrorText = "Изберете файл с формат .docx";
            }
        }
    }
}