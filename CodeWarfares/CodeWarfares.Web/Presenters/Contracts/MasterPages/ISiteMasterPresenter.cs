using CodeWarfares.Web.Presenters.MasterPages;
using System;

namespace CodeWarfares.Web.Presenters.Contracts.MasterPages
{
    public interface ISiteMasterPresenter
    {
        event EventHandler SetResponseCookieEvent;

        void Initialize();

        void ValidateTokens();
    }
}