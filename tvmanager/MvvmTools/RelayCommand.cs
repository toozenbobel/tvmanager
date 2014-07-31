using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;

namespace MvvmTools
{
	public class RelayCommand : RelayCommand<object>
	{
		public RelayCommand(Action execute) : base(x => execute())
		{ }
	}

	public class RelayCommand<TParam> : ICommand where TParam : class
	{
		#region Fields

		readonly Action<TParam> _execute;
		readonly Predicate<TParam> _canExecute;

		#endregion // Fields

		#region Constructors

		public RelayCommand(Action<TParam> execute)
			: this(execute, null)
		{
		}

		public RelayCommand(Action<TParam> execute, Predicate<TParam> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("execute", "Argument execute can't be null");

			_execute = execute;
			_canExecute = canExecute;
		}
		#endregion // Constructors

		#region ICommand Members

		[DebuggerStepThrough]
		public bool CanExecute(object parameter)
		{
			return _canExecute == null || _canExecute(parameter as TParam);
		}

		/// <summary>
		/// Occurs when changes occur that affect whether the command should execute.
		/// </summary>
		public event EventHandler CanExecuteChanged;

		/// <summary>
		/// Raises the <see cref="CanExecuteChanged" /> event.
		/// </summary>
		[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate",
			Justification = "This cannot be an event")]
		public void RaiseCanExecuteChanged()
		{
			var handler = CanExecuteChanged;
			if (handler != null)
			{
				handler(this, EventArgs.Empty);
			}
		}

		public void Execute(object parameter)
		{
			_execute(parameter as TParam);
		}

		#endregion // ICommand Members
	}
}