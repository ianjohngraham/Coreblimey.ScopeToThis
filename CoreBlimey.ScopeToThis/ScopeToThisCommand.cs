using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Text;
using Sitecore.Web;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Sheer;

namespace CoreBlimey.ScopeToThis
{
    public class ScopeToThisCommand : Command
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

        public override CommandState QueryState(CommandContext context)
        {
            Assert.IsNotNull(context, "context is null");
            return string.IsNullOrEmpty(ScopedItem) ? CommandState.Enabled : CommandState.Hidden;
        }

        public override void Execute(CommandContext context)
        {
            if (context.Items[0] == null)
                return;

            if (string.IsNullOrEmpty(ScopedItem))
            {
                ScopedItem = context.Items[0].ID.ToString();
            }

            var url = ScopeToThisHelper.GetUrl(context.Items[0]);
            SheerResponse.SetLocation(url);
        }
    }
}