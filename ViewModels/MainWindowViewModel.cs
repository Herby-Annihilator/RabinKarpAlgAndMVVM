using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using RabinKarpAlgorithm.ViewModels.Base;
using RabinKarpAlgorithm.Infrastructure.Commands;
using System.Windows;
using System.IO;
using MyLibrary.SpecialAlgorithms.RabinKarpAlgorithm;

namespace RabinKarpAlgorithm.ViewModels
{
	internal class MainWindowViewModel : ViewModel
	{
		public MainWindowViewModel()
		{
			SaveSourceTextToFileCommand = new LambdaCommand(OnSaveSourceTextToFileCommandExecuted,
				CanSaveSourceTextToFileCommandExecute);
			RestoreSourceTextFromFileCommand = new LambdaCommand(OnRestoreSourceTextFromFileCommandExecuted,
				CanRestoreSourceTextFromFileCommandExecute);
			RabinKarpAlgorithmCommand = new LambdaCommand(OnRabinKarpAlgorithmCommandExecuted,
				CanRabinKarpAlgorithmCommandExecute);


			countOfRepetitions = -1;
		}
		private int countOfRepetitions;

		#region Properties
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
		private string status = "Salam aleykum";
		public string Status
		{
			get => status;
			set => Set(ref status, value);
		}

		private string sourceText;
		public string SourceText
		{
			get => sourceText;
			set
			{
				Status = "Редактирование текста";
				Set(ref sourceText, value);
			}
		}

		private string stringToFind;
		public string StringToFind { get => stringToFind; set { Set(ref stringToFind, value);  
				Status = "Ввод строки для поиска"; } }

		private string numberOfRepetitions;
		public string NumberOfRepetitions 
		{ 
			get => numberOfRepetitions;
			set
			{
				if (Int32.TryParse(value, out countOfRepetitions))
				{
					TextBoxNumberOfRepetitionsStatus = "";
				}
				else
				{
					TextBoxNumberOfRepetitionsStatus = "Invalid format!";
					countOfRepetitions = -1;
				}
				Status = "Ввод числа повторений подстроки";
				Set(ref numberOfRepetitions, value);
			}
		}

		private string textBoxNumberOfRepetitionsStatus;
		public string TextBoxNumberOfRepetitionsStatus { get => textBoxNumberOfRepetitionsStatus; 
			set => Set(ref textBoxNumberOfRepetitionsStatus, value); }


		private string result = "";
		public string Result { get => result; set => Set(ref result, value); }
		#endregion


		#region Commands
		public ICommand SaveSourceTextToFileCommand { get; }
		private void OnSaveSourceTextToFileCommandExecuted(object param)
		{
			StreamWriter writer = new StreamWriter("input.dat");
			writer.Write(SourceText);
			writer.Close();
			Status = "Изменения успешно сохранены";
		}
		private bool CanSaveSourceTextToFileCommandExecute(object param)
		{
			if (string.IsNullOrWhiteSpace(sourceText))
			{
				return false;
			}
			else
			{
				return true;
			}
		}


		public ICommand RestoreSourceTextFromFileCommand { get; }
		private void OnRestoreSourceTextFromFileCommandExecuted(object param)
		{
			StreamReader reader = new StreamReader("input.dat");
			SourceText = reader.ReadToEnd();
			reader.Close();
			Status = "Текст восстановлен";
		}
		private bool CanRestoreSourceTextFromFileCommandExecute(object param)
		{
			return File.Exists("input.dat");
		}


		public ICommand RabinKarpAlgorithmCommand { get; }
		private void OnRabinKarpAlgorithmCommandExecuted(object param)
		{
			try
			{
				Result = "";
				Status = "Выполнение....";
				int[] occurrences = SourceText.FindSubstringOccurrences(StringToFind);
				if (occurrences.Length == 0)
				{
					Result = "Вхождений не найдено";
				}
				else
				{
					for (int i = 0; i < occurrences.Length; i++)
					{
						Result += "Совпадение найдено: индекс вхождения " + occurrences[i] + "\r\n";
					}
				}
				Status = "Выполнено!";
			}
			catch(Exception e)
			{
				Status = "Не выполнено, причина: " + e.Message;
			}
		}
		private bool CanRabinKarpAlgorithmCommandExecute(object param)
		{
			if (string.IsNullOrWhiteSpace(SourceText) || string.IsNullOrWhiteSpace(StringToFind) || countOfRepetitions == -1)
				return false;
			return true;
		}
		#endregion
	}
}
