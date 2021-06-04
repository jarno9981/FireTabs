using System;

namespace FireTabs
{
	/// <summary>Provides data for the <see cref="ListWithEvents{T}.ItemAdded" /> events.</summary>
	[Serializable]
	public class ListItemEventArgs : EventArgs
	{
		/// <summary>Index of the item being changed.</summary>
		private readonly int _FireitemIndex;

		/// <summary>Initializes a new instance of the <see cref="ListItemEventArgs" /> class.</summary>
		/// <param name="itemIndexer">Index of the item being changed.</param>
		public ListItemEventArgs(int itemIndexer)
		{
			_FireitemIndex = itemIndexer;
		}

		/// <summary>Gets the index of the item changed.</summary>
		public int ItemIndex
		{
			get
			{
				return _FireitemIndex;
			}
		}
	}
}