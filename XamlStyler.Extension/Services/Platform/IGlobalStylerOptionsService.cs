using Xavalon.XamlStyler.Options;

namespace Xavalon.XamlStyler.Extension.Services.Platform
{
    public interface IGlobalStylerOptionsService
    {
        IStylerOptions GetGlobalOptions();

        void SaveGlobalOptions(IStylerOptions options);

        void ResetGlobalOptions();
    }
}