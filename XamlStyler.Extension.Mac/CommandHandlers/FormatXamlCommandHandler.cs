// © Xavalon. All rights reserved.

using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using Xavalon.XamlStyler.Extension.Mac.Services.XamlFormatting;
using Xavalon.XamlStyler.Extension.Mac.Services.XamlStylerOptions;

namespace Xavalon.XamlStyler.Extension.Mac.CommandHandlers
{
    public class FormatXamlCommandHandler : CommandHandler
    {
        private IXamlFormattingService XamlFormattingService => ExtensionApp.Container.Resolve<IXamlFormattingService>();
        private IXamlStylerOptionsService XamlStylerOptionsService => ExtensionApp.Container.Resolve<IXamlStylerOptionsService>();

        protected override void Run()
        {
            var document = IdeApp.Workbench.ActiveDocument;
            var stylerOptions = XamlStylerOptionsService.GetDocumentOptions(document);
            XamlFormattingService.TryFormatXamlDocument(document, stylerOptions);
        }

        protected override void Update(CommandInfo info)
        {
            var document = IdeApp.Workbench.ActiveDocument;
            var isDocumentFormattable = XamlFormattingService.IsDocumentFormattable(document);
            info.Enabled = isDocumentFormattable;
            info.Visible = isDocumentFormattable;
        }
    }
}