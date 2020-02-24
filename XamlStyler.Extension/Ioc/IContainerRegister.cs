// © Xavalon. All rights reserved.

namespace Xavalon.XamlStyler.Extension.Ioc
{
    public interface IContainerRegister
    {
        void LazyRegisterSingleton<IInstance, TInstance>() where TInstance : class, IInstance;
    }
}