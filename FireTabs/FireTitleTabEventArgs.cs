using System;
using System.Windows.Forms;

namespace FireTabs
{
	/// <summary>Event arguments class for an event that occurs on a collection of collection of <see cref="FireTitleTab" />s.</summary>
	public class FireTitleTabEventArgs : EventArgs
	{
		/// <summary>Action that is being performed.</summary>
		public TabControlAction? Action
		{
			get;
			set;
		}

		/// <summary>The tab that the <see cref="Action" /> is being performed on.</summary>
		public FireTitleTab Tab
		{
			get;
			set;
		}

		/// <summary>Index of the tab within the collection.</summary>
		public int TabIndex
		{
			get;
			set;
		}

		/// <summary>Flag indicating if the user was dragging the tab when the event occurred.</summary>
		public bool WasDragging
		{
			get;
			set;
		}
	}
}