// © Xavalon. All rights reserved.

using System;
using Xavalon.XamlStyler.Extension.Ioc;

namespace Xavalon.XamlStyler.Extension
{
    public class ExtensionApp
    {
        private readonly IExtensionPlatformInitializer _extensionPlatformInitializer;

        public ExtensionApp(IExtensionPlatformInitializer extensionPlatformInitializer)
        {
            _extensionPlatformInitializer = extensionPlatformInitializer ?? throw new ArgumentNullException(nameof(extensionPlatformInitializer));
        }

        public static IContainer Container { get; private set; }

        public void Initialize()
        {
            var container = new Container();

            RegisterServices(container);
            _extensionPlatformInitializer.InitializePlatformDependencies(container);

            Container = container;
        }

        private void RegisterServices(IContainerRegister containerRegister)
        {
        }
    }
}