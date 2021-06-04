﻿namespace FireTabs
{
	/// <summary>The type of theme being used to render the desktop.</summary>
	public enum FireDisplayType
	{
		/// <summary>Windows 2000-esque theme.</summary>
		Classic,

		/// <summary>Contemporary theme, but without Aero enabled.</summary>
		Basic,

		/// <summary>Full compositing enabled in the theme.</summary>
		Aero,

		Premium
	}
}