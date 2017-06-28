using System;
using System.IO;
using MonoDevelop.Core;
using Newtonsoft.Json;
using Xavalon.XamlStyler.Core.Options;

namespace Xavalon.XamlStyler.XamarinStudio
{
	public static class StylerOptionsConfiguration
	{
		public static StylerOptions ReadFromUserProfile(IConfig config)
		{
			var filePath = GetOptionsFilePath(config).ToString();

			try
			{
				var text = File.ReadAllText(filePath);
				return JsonConvert.DeserializeObject<StylerOptions>(text);
			}
			catch (FileNotFoundException)
			{
			}
			catch (Exception ex)
			{
				LoggingService.LogError("Exception when saving user XamlStyler options", ex);

				// delete file on any other exception (malformed etc.)
				File.Delete(filePath);
			}

			return config.DefaultOptions;
		}

		public static void WriteToUserProfile(StylerOptions options, IConfig config)
		{
			try
			{
				var text = JsonConvert.SerializeObject(options);
				File.WriteAllText(GetOptionsFilePath(config).ToString(), text);
			}
			catch (Exception ex)
			{
				LoggingService.LogError("Exception when saving user XamlStyler options", ex);
			}
		}

		public static void Reset(IConfig config)
		{
			File.Delete(GetOptionsFilePath(config).ToString());
		}

		private static FilePath GetOptionsFilePath(IConfig config)
		{
			return UserProfile.Current.ConfigDir.Combine(config.PreferencesFilename);
		}
	}
}

