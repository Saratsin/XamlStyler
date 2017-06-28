using System;
namespace Xavalon.XamlStyler.XamarinStudio
{
	public class FormatAxmlBatchHandler : FormatBatchHandlerBase
	{
		protected override IConfig Config => new AndroidAxmlConfig();
	}
}
