using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;

namespace CoreBlimey.ScopeToThis
{
    public class ShowFullTreeCommand : Command
    {
        private const string SitecoreNode = "{11111111-1111-1111-1111-111111111111}";

        public override CommandState QueryState(CommandContext context)
        {
            Assert.IsNotNull(context, "context is null");
            return !string.IsNullOrEmpty(ScopeToThisHelper.ScopedItem) ? CommandState.Enabled : CommandState.Hidden;
        }

        public override void Execute(CommandContext context)
        {
            if(context.Items[0] == null)
                return;

            ScopeToThisHelper.ScopedItem = string.Empty;

            var topNode = context.Items[0].Database.GetItem(SitecoreNode);
            var url = ScopeToThisHelper.GetUrl(topNode);
            SheerResponse.SetLocation(url);
        }
    }
}
