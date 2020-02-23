using Microsoft.VisualStudio.Shell;
using Xavalon.XamlStyler.Options;

namespace Xavalon.XamlStyler.Extension.Windows
{
    public class PackageOptions : DialogPage
    {
        private readonly IStylerOptions _options;

        public PackageOptions()
        {
            _options = new StylerOptions();
        }

        public override object AutomationObject
        {
            get { return _options; }
        }
    }
}