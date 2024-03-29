﻿using System.Collections.Generic;
using System.Windows.Forms;

namespace FireTabs
{
	/// <summary>
	/// Application context to use when starting a <see cref="FireTitle" /> application via <see cref="Application.Run(ApplicationContext)" />.  Used to
	/// track open windows so that the entire application doesn't quit when the first-opened window is closed.
	/// </summary>
	public class FireTitleApplicationContext : ApplicationContext
	{
		/// <summary>List of all opened windows.</summary>
		protected List<FireTitle> _FireopenWindows = new List<FireTitle>();

		/// <summary>List of all opened windows.</summary>
		public List<FireTitle> OpenWindows
		{
			get
			{
				return _FireopenWindows;
			}
		}

		/// <summary>Constructor; takes the initial window to display and, if it's not closing, opens it and shows it.</summary>
		/// <param name="initialFormInstance">Initial window to display.</param>
		public void Start(FireTitle initialFormInstance)
		{
			if (initialFormInstance.IsClosing)
			{
				ExitThread();
			}

			else
			{
				OpenWindow(initialFormInstance);
				initialFormInstance.Show();
			}
		}

		/// <summary>
		/// Adds <paramref name="window" /> to <see cref="_openWindows" /> and attaches event handlers to its <see cref="Form.FormClosed" /> event to keep track
		/// of it.
		/// </summary>
		/// <param name="window">Window that we're opening.</param>
		public void OpenWindow(FireTitle window)
		{
			if (!_FireopenWindows.Contains(window))
			{
				window.ApplicationContext = this;

				_FireopenWindows.Add(window);
				window.FormClosed += window_FormClosed;
			}
		}

		/// <summary>
		/// Handler method that's called when an item in <see cref="_openWindows" /> has its <see cref="Form.FormClosed" /> event invoked.  Removes the window
		/// from <see cref="_openWindows" /> and, if there are no more windows open, calls <see cref="ApplicationContext.ExitThread" />.
		/// </summary>
		/// <param name="sender">Object from which this event originated.</param>
		/// <param name="e">Arguments associated with the event.</param>
		protected void window_FormClosed(object sender, FormClosedEventArgs e)
		{
			_FireopenWindows.Remove((FireTitle) sender);

			if (_FireopenWindows.Count == 0)
			{
				ExitThread();
			}
		}
	}
}