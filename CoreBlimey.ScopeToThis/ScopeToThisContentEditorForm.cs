using System;
using System.Web;
using Sitecore;
using Sitecore.Data;
using Sitecore.Shell.Applications.ContentManager;

namespace CoreBlimey.ScopeToThis
{
    public class ScopeToThisContentEditorForm : ContentEditorForm
    {
        protected override void OnLoad(EventArgs e)
        {
            if (!string.IsNullOrEmpty(ScopeToThisCommand.ScopedItem) && HttpContext.Current.Request.QueryString["redirect"] == null)
            {
                var scopeItem = Context.Database.GetItem(ID.Parse(ScopeToThisCommand.ScopedItem));

                var url =ScopeToThisHelper.GetUrl(scopeItem);
                HttpContext.Current.Response.Redirect(url + "&redirect=true");
            }
            else
            {
                base.OnLoad(e);
            }    
        }
    }
}