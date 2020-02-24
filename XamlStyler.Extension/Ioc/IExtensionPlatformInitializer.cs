// © Xavalon. All rights reserved.

namespace Xavalon.XamlStyler.Extension.Ioc
{
    public interface IExtensionPlatformInitializer
    {
        void InitializePlatformDependencies(IContainerRegister containerRegister);
    }
}