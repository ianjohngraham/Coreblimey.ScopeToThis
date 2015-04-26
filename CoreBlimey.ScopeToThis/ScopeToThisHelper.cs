using Sitecore.Data.Items;
using Sitecore.Text;
using Sitecore.Web;
using Sitecore.Web.UI.HtmlControls;

namespace CoreBlimey.ScopeToThis
{
    public static class ScopeToThisHelper
    {
        public static string ScopedItem
        {
            get
            {
                return Registry.GetString("/Current_User/UserOptions.View.ScopedItem");
            }
            set
            {
                Registry.SetString("/Current_User/UserOptions.View.ScopedItem", value);
            }
        }

        public static string GetUrl(Item item)
        {
            UrlString urlString = new UrlString(WebUtil.GetRawUrl());
            item.Uri.AddToUrlString(urlString);
            urlString["ro"] = item.ID.ToString();
            return urlString.ToString();
        }
    }
}