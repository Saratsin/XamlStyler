using MonoDevelop.Ide.Gui.Dialogs;

namespace Xavalon.XamlStyler.XamarinStudio.Gui
{
	public class MainOptionsPanel : OptionsPanel
	{
		public override MonoDevelop.Components.Control CreatePanelWidget()
		{
			return new MainWidget();
		}

		public override void ApplyChanges()
		{
		}
	}
}
