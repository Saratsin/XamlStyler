using MonoDevelop.Ide.Gui.Dialogs;

namespace Xavalon.XamlStyler.XamarinStudio.Gui
{
	public class AndroidStylerOptionsPanel : OptionsPanel
	{
		private OptionsViewModel _optionsViewModel = new OptionsViewModel(new AndroidAxmlConfig());

		public override MonoDevelop.Components.Control CreatePanelWidget()
		{
			return new OptionsWidget(_optionsViewModel);
		}

		public override void ApplyChanges()
		{
			_optionsViewModel.SaveOptions();
		}
	}
}