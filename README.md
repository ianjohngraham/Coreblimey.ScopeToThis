# Coreblimey.ScopeToThis

Allows "scope to this" functionality a la Visual Studio, on the Sitecore Content Editor tree.

To install, install the package under the /packages folder.

To get the module to remember your settings after content editor refreshes you need to replace the code beside setting in this file.

\Sitecore\shell\Applications\Content Manager\Default.aspx

Replace the code beside control with the following:

<sc:CodeBeside runat="server" Type="CoreBlimey.ScopeToThis.ScopeToThisContentEditorForm, CoreBlimey.ScopeToThis" />


