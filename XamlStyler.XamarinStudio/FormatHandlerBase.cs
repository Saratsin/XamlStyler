using MonoDevelop.Components.Commands;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using Xavalon.XamlStyler.Core;
using Xavalon.XamlStyler.XamarinStudio.Extensions;

namespace Xavalon.XamlStyler.XamarinStudio
{
	public abstract class FormatHandlerBase : CommandHandler
	{
		protected abstract IConfig Config { get; }

		protected override void Run()
		{
			var options = StylerOptionsConfiguration.ReadFromUserProfile(Config);
			var styler = new StylerService(options);

			var doc = IdeApp.Workbench.ActiveDocument;
			var edit = doc.Editor;

			if (edit != null)
			{
				var output = styler.StyleDocument(edit.Text);

				using (edit.OpenUndoGroup())
				{
					edit.RemoveText(0, edit.Text.Length);
					edit.InsertText(0, output);
				}
				doc.IsDirty = true;
			}
		}

		protected override void Update(CommandInfo info)
		{
			var doc = IdeApp.Workbench.ActiveDocument;

			if (doc == null)
			{
				return;
			}

			if (doc != null && IsDocumentSupported(doc))
			{
				LoggingService.LogInfo($"XamlStyler: Filename is {doc.FileName}, extension is ENABLED");
				info.Enabled = info.Visible = true;
			}
			else
			{
				LoggingService.LogInfo($"XamlStyler: Filename is {doc.FileName}, extension is DISABLED");
				info.Visible = false;
			}
		}

		protected virtual bool IsDocumentSupported(Document doc)
		{
			return doc.FileName.Extension.EndsWithAny(Config.FileExtensions, System.StringComparison.OrdinalIgnoreCase);
		}
	}
}