using Xavalon.XamlStyler.Core.Options;

namespace Xavalon.XamlStyler.XamarinStudio
{
	public interface IConfig
	{
		string PreferencesFilename { get; }

		string[] FileExtensions { get; }

		StylerTarget Target { get; }

		StylerOptions DefaultOptions { get; }
	}
}
