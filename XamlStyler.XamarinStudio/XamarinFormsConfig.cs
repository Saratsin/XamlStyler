using System;
using MonoDevelop.Core;
using Xavalon.XamlStyler.Core.Options;

namespace Xavalon.XamlStyler.XamarinStudio
{
	public class XamarinFormsConfig : IConfig
	{
		public string PreferencesFilename => "xamlstyler.config";

		public string[] FileExtensions => new[] { ".xaml" };

		public StylerTarget Target => StylerTarget.XamarinFormsXaml;

		public StylerOptions DefaultOptions
		{
			get
			{
				var options = new StylerOptions()
				{
					IndentSize = 4,
				};

				try
				{
					// update attribute ordering to include Forms attrs
					options.AttributeOrderingRuleGroups[6] += ", WidthRequest, HeightRequest";
					options.AttributeOrderingRuleGroups[7] += ", HorizontalOptions, VerticalOptions, XAlign, VAlign";
				}
				catch (Exception ex)
				{
					LoggingService.LogError("Exception when updating default options to include Xamarin Forms attributes", ex);
				}

				return options;
			}
		}
	}
}
