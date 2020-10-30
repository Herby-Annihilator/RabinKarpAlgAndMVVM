using System;
using System.Collections.Generic;
using System.Text;
using RabinKarpAlgorithm.Infrastructure.Commands.Base;
using System.Windows;

namespace RabinKarpAlgorithm.Infrastructure.Commands
{
	internal class CloseApplicationCommand : Command
	{
		public override bool CanExecute(object parameter)
		{
			return true;
		}

		public override void Execute(object parameter)
		{
			Application.Current.Shutdown();
		}
	}
}
