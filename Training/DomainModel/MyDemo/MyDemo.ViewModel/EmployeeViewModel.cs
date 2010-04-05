using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mavis.MVVM;
using MyDemo.Core;
using MyDemo.Core.DataInterfaces;

namespace MyDemo.ViewModel
{
    public class EmployeeViewModel: ViewModelBase
    {
        private DelegateCommand _addCommand;
        private DelegateCommand _editCommand;
        private DelegateCommand _saveCommand;

        public EmployeeViewModel(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;

            ViewMode = ViewMode.ViewOnlyMode;

            _addCommand = new DelegateCommand
                              {
                                  CanExecuteDelegate = x => CanExecuteAddCommand(),
                                  ExecuteDelegate = x => ExecuteAddCommand()
                              };
            _editCommand = new DelegateCommand
                               {
                                   CanExecuteDelegate = x => CanExecuteEditCommand(),
                                   ExecuteDelegate = x => ExecuteEditCommand()
                               };
            _saveCommand = new DelegateCommand
                               {
                                   CanExecuteDelegate = x => CanExecuteSaveCommand(),
                                   ExecuteDelegate = x => ExecuteSaveCommand()
                               };
        }

        private void ExecuteAddCommand()
        {
            ViewMode = ViewMode.AddMode;
            CurrentEmployee = new Employee();
        }

        private void ExecuteEditCommand()
        {
            ViewMode = ViewMode.EditMode;
        }

        private void ExecuteSaveCommand()
        {
            ViewMode = ViewMode.ViewOnlyMode;
            CurrentEmployee = EmployeeRepository.SaveOrUpdate(CurrentEmployee);
        }

        private bool CanExecuteAddCommand()
        {
            return true;
        }

        private bool CanExecuteEditCommand()
        {
            return true;
        }

        private bool CanExecuteSaveCommand()
        {
            return true;
        }

        public ViewMode ViewMode { get; set; }

        public DelegateCommand AddCommand
        {
            get {
                return _addCommand;
            }
        }

        public DelegateCommand EditCommand
        {
            get {
                return _editCommand;
            }
        }

        public DelegateCommand SaveCommand
        {
            get { return _saveCommand; }
        }

        private Employee _currentEmployee;
        public Employee CurrentEmployee
        {
            get { return _currentEmployee; }
            set
            {
                _currentEmployee = value;
                NotifyPropertyChanged("CurrentEmployee");
            }
        }

        public IEmployeeRepository EmployeeRepository { get; set; }
    }
}
