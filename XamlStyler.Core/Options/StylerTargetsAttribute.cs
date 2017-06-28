using System;
namespace Xavalon.XamlStyler.Core.Options
{
	public class StylerTargetsAttribute : Attribute
	{
		public StylerTargetsAttribute(params StylerTarget[] targets)
		{
			Targets = targets;
		}

		public StylerTarget[] Targets { get; private set; }
	}
}
