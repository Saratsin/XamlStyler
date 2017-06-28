using System;
using Xavalon.XamlStyler.XamarinStudio.Extensions;

namespace Xavalon.XamlStyler.XamarinStudio
{
	public class FormatAxmlHandler : FormatHandlerBase
	{
		protected override IConfig Config => new AndroidAxmlConfig();

		protected override bool IsDocumentSupported(MonoDevelop.Ide.Gui.Document doc)
		{
			return doc.PathRelativeToProject.StartsWith("Resources", StringComparison.OrdinalIgnoreCase) && doc.Name.EndsWithAny(Config.FileExtensions, StringComparison.OrdinalIgnoreCase);
		}
	}
}
