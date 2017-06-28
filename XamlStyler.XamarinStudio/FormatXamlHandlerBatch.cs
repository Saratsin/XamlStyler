namespace Xavalon.XamlStyler.XamarinStudio
{
	public class FormatXamlBatchHandler : FormatBatchHandlerBase
	{
		protected override IConfig Config => new XamarinFormsConfig();
	}
}