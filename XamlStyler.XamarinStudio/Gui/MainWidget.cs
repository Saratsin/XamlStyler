using System;
namespace Xavalon.XamlStyler.XamarinStudio.Gui
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class MainWidget : Gtk.Bin
	{
		public MainWidget()
		{
			this.Build();

			description.Text = "This is a little label explaining what all this is about.";
		}
	}
}
