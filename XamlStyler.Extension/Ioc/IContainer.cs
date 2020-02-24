// © Xavalon. All rights reserved.

namespace Xavalon.XamlStyler.Extension.Ioc
{
    public interface IContainer
    {
        IInstance Resolve<IInstance>();
    }
}