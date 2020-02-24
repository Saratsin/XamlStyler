// © Xavalon. All rights reserved.

using Xavalon.XamlStyler.Extension.Ioc;
using Xavalon.XamlStyler.Extension.Mac.Plugins.XamlFormattingOnSave;
using Xavalon.XamlStyler.Extension.Mac.Services.DocumentSavedEvent;
using Xavalon.XamlStyler.Extension.Mac.Services.XamlFiles;
using Xavalon.XamlStyler.Extension.Mac.Services.XamlFormatting;
using Xavalon.XamlStyler.Extension.Mac.Services.XamlStylerOptions;

namespace Xavalon.XamlStyler.Extension.Mac
{
    public class MacExtensionPlatformInitializer : IExtensionPlatformInitializer
    {
        public void InitializePlatformDependencies(IContainerRegister containerRegister)
        {
            RegisterServices(containerRegister);
            RegisterPlugins(containerRegister);
        }

        private void RegisterServices(IContainerRegister containerRegister)
        {
            containerRegister.LazyRegisterSingleton<IXamlFormattingService, XamlFormattingService>();
            containerRegister.LazyRegisterSingleton<IXamlStylerOptionsService, XamlStylerOptionsService>();
            containerRegister.LazyRegisterSingleton<IXamlFilesService, XamlFilesService>();
            containerRegister.LazyRegisterSingleton<IDocumentSavedEventService, DocumentSavedEventService>();
        }

        private void RegisterPlugins(IContainerRegister containerRegister)
        {
            containerRegister.LazyRegisterSingleton<IXamlFormattingOnSavePlugin, XamlFormattingOnSavePlugin>();
        }
    }
}