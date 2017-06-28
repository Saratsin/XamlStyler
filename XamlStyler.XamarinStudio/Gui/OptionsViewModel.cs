using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xavalon.XamlStyler.Core.Options;

namespace Xavalon.XamlStyler.XamarinStudio.Gui
{
	public class OptionsViewModel
	{
		private IConfig _config;

		public OptionsViewModel(IConfig config)
		{
			_config = config;
		}

		public IList<IGrouping<string, Option>> GroupedOptions { get; private set; }

		public StylerOptions Options { get; private set; }

		public bool IsDirty { get; set; }

		public void Init()
		{
			Options = ReadOptions();

			var optionsList = new List<Option>();
			foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(Options))
			{
				var targetAttr = property.Attributes[typeof(StylerTargetsAttribute)] as StylerTargetsAttribute;

				if (targetAttr != null)
				{
					// check this target supports the property
					if (!targetAttr.Targets.Contains(_config.Target))
					{
						// don't show this option
						continue;
					}
				}

				optionsList.Add(new Option(property));
			}

			GroupedOptions = optionsList.Where(o => o.IsConfigurable).GroupBy(o => o.Category).ToList();
		}

		public StylerOptions ReadOptions()
		{
			return StylerOptionsConfiguration.ReadFromUserProfile(_config);
		}

		public void SaveOptions()
		{
			if (IsDirty)
			{
				StylerOptionsConfiguration.WriteToUserProfile(Options, _config);
			}
		}

		public void ResetToDefaults()
		{
			StylerOptionsConfiguration.Reset(_config);
			IsDirty = false;
		}
	}
}

