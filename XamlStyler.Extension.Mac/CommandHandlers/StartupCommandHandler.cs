// © Xavalon. All rights reserved.

using MonoDevelop.Components.Commands;
using Xavalon.XamlStyler.Extension.Mac.Plugins.XamlFormattingOnSave;
using Xavalon.XamlStyler.Extension.Mac.Services.DocumentSavedEvent;

namespace Xavalon.XamlStyler.Extension.Mac.CommandHandlers
{
    public class StartupCommandHandler : CommandHandler
    {
        protected override void Run()
        {
            var extensionPlatformInitializer = new MacExtensionPlatformInitializer();
            var extensionApp = new ExtensionApp(extensionPlatformInitializer);

            extensionApp.Initialize();

            InitializeDocumentSavedLogic();
        }

        private void InitializeDocumentSavedLogic()
        {
            var documentSavedEventService = ExtensionApp.Container.Resolve<IDocumentSavedEventService>();
            var xamlFormattingOnSavePlugin = ExtensionApp.Container.Resolve<IXamlFormattingOnSavePlugin>();

            documentSavedEventService.StartListening();
            xamlFormattingOnSavePlugin.Initialize();
        }
    }
}