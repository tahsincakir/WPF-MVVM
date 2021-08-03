using CalculatorLib.MVVM.Commands;
using CalculatorLib.MVVM.Model;
using CalculatorLib.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib.MVVM.ViewModel
{
  
        public class CalculationViewModel : INotifyPropertyChanged
        {
            #region InotifyPropertyChanged_Implemantation

            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)

                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }

            #endregion

            CalculationService ObjCalculationService;
            FileOperation fileOperation;

            public CalculationViewModel(string expressionTxt, string outputFilePath)
            {
                ObjCalculationService = new CalculationService();       
                currentCalculation = new Calculation(expressionTxt,  outputFilePath);
                calculateCommand = new RelayCommand(Calculate);               
            }

 
            private Calculation currentCalculation;

            public Calculation CurrentCalculation
            {
                get { return currentCalculation; }
                set { currentCalculation = value; OnPropertyChanged("CurrentCalculation"); }
            }

            private string message;

            public string Message
            {
                get { return message; }
                set { message = value; OnPropertyChanged("Message"); }
            }


            #region CalculationOperation

            private RelayCommand calculateCommand;

            public RelayCommand CalculateCommand
            {
                get { return calculateCommand; }
            }

            public void Calculate()
            {
                try
                {
                    var isCalculated = ObjCalculationService.Calculate(CurrentCalculation);
                    if (isCalculated)
                    {
                        Message = "Calculation done";

                        fileOperation = new FileOperation();
                        fileOperation.WriteDataToFile(currentCalculation.TxtOutputFilePath, currentCalculation.OutputValue.ToString());
                        
                    }
                    else
                    {
                        Message = "Calculation Operation Failed";
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }

            #endregion
  
    }

}
