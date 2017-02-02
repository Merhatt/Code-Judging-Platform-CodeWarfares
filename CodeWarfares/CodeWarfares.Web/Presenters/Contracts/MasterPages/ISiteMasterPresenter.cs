using CodeWarfares.Web.EventArguments;
using CodeWarfares.Web.Presenters.MasterPages;
using System;

namespace CodeWarfares.Web.Presenters.Contracts.MasterPages
{
    public interface ISiteMasterPresenter
    {
        void Initialize(object sender, MasterPageInitEventArgs e);

        void ValidateTokens(object sender, MasterPageValidateTokenEventArgs e);
    }
}