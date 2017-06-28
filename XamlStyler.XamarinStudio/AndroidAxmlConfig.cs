using Xavalon.XamlStyler.Core.Options;

namespace Xavalon.XamlStyler.XamarinStudio
{
	public class AndroidAxmlConfig : IConfig
	{
		public string PreferencesFilename => "axmlstyler.config";

		public string[] FileExtensions => new[] { ".axml" };

		public StylerTarget Target => StylerTarget.AndroidAxml;

		public StylerOptions DefaultOptions
		{
			get
			{
				var options = new StylerOptions()
				{
					IndentSize = 4,
					AttributeOrderingRuleGroups = new string[]
					{
						"xmlns:*",
                        "android:id",
						"style",
						"android:layout_width, android:layout_height, android:layout_weight, android:layout_gravity",
						"android:layout_margin, android:layout_marginLeft, android:layout_marginTop, android:layout_marginRight, android:layout_marginBottom, android:layout_marginStart, android:layout_marginEnd",
						"android:padding, android:paddingLeft, android:paddingTop, android:paddingRight, android:paddingBottom, android:paddingStart, android:paddingEnd",

					},
					NoNewLineElements = "include"
				};

				return options;
			}
		}
	}
}
