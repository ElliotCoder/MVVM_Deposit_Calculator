using System;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;

namespace MVVM_Sample
{
    class UserControl_And_Data_Interaction_ViewModel_: INotifyPropertyChanged
    {
        Data_Model_ model; //Данные
        ICommand calculateDepositCommand; //Команда
        //Отслеживание текущей формулы
        ExpressionWrapper selectedExpression = null;
        //Вывод
        String userOutput;

        public UserControl_And_Data_Interaction_ViewModel_()
        {
            model = new Data_Model_();
            calculateDepositCommand =
                new CalculateDepositCommandImplementation(this);
        }
        
        public bool ValidateFields()
        {
            bool isValid = true;
            if (model.Percentage == 0 || 
                model.Periods == 0 || model.StartingSum == 0 ||
                selectedExpression == null)
                    isValid = false;
            return isValid;
        }

        public Data_Model_ Model 
        {
            get { return model; }
            set { model = value; }
        }

        public String UserOutput
        {
            get { return userOutput; }
            set {
                userOutput = value;
                OnPropertyChanged("UserOutput");
            }
        }

        public ExpressionWrapper SelectedExpression
        {
            get { return selectedExpression; }
            set {
                selectedExpression = value;
                OnPropertyChanged("SelectedExpression");
            }
        }

        public ICommand CalculateDepositCommand
        {
            get { return calculateDepositCommand; }
        }

        private class CalculateDepositCommandImplementation : ICommand
        {
            readonly UserControl_And_Data_Interaction_ViewModel_ viewModel;
            public CalculateDepositCommandImplementation(UserControl_And_Data_Interaction_ViewModel_ viewModel)
            {
                this.viewModel = viewModel;
            }
            public bool CanExecute(object parameter)
            {
                return viewModel.ValidateFields();
            }
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
            public void Execute(object parameter)
            {
                Double result = Math.Round(
                    viewModel.SelectedExpression.DepositPercentExpression(
                        viewModel.Model.StartingSum, viewModel.Model.Percentage,
                        viewModel.Model.Periods), 2);
                String output = String.Format(
                    "Депозит на {0} от вклада в размере {1} единиц на {2} " +
                     "периодов под {3} процент(а/ов) составляет {4} единиц",
                     viewModel.SelectedExpression.Name, viewModel.Model.StartingSum,
                     viewModel.Model.Periods, viewModel.Model.Percentage, result);
                viewModel.UserOutput = output;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
