using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RabinKarpAlgorithm.ViewModels.Base
{
	internal abstract class ViewModel : INotifyPropertyChanged, IDisposable
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private bool disposed = false;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		/// <summary>
		/// Данный метод обновляет значение свойства того поля, для которого это свойство определено.
		/// Нужен для того, чтобы взаимоизменяющие друг друга свойства не создавали цикл и не переполняли тем самым стек.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="field">ссылка на поле свойства</param>
		/// <param name="value">новое значение этого поля</param>
		/// <param name="propertyName">забей, это имя свойства</param>
		/// <returns></returns>
		protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			if (Equals(value, field))
			{
				return false;
			}
			field = value;
			OnPropertyChanged(propertyName);
			return true;
		}

		public void Dispose()
		{
			Dispose(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposing || disposed)
			{
				return;
			}
			disposed = true;
			// освобождай тут совои ресурсы
		}

		//~ViewModel()
		//{
		//	Dispose(false);
		//}
	}
}
