using System;
using System.Collections.Generic;
using System.Text;
using RabinKarpAlgorithm.ViewModels.Base;

namespace RabinKarpAlgorithm.ViewModels
{
	internal class MainWindowViewModel : ViewModel
	{
		private string windowTitle = "Eshkere.....";
		public string WindowTitle
		{
			get
			{
				return windowTitle;
			}
			set
			{
				Set(ref windowTitle, value);
			}
		}
		private string status;
		public string Status
		{
			get => status;
			set => Set(ref status, value);
		}
	}
}
