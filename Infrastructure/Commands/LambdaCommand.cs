﻿using System;
using System.Collections.Generic;
using System.Text;
using RabinKarpAlgorithm.Infrastructure.Commands.Base;

namespace RabinKarpAlgorithm.Infrastructure.Commands
{
	internal class LambdaCommand : Command
	{
		private Action<object> execute;
		private Func<object, bool> canExecute;

		public LambdaCommand(Action<object> execute, Func<object, bool> canExecute = null)
		{
			this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
			this.canExecute = canExecute;
		}

		public override bool CanExecute(object parameter)
		{
			return canExecute?.Invoke(parameter) ?? true;
		}

		public override void Execute(object parameter)
		{
			execute.Invoke(parameter);
		}
	}
}
