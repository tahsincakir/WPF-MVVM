using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib.MVVM.Model
{

    public class Calculation : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Calculation(){}

        public Calculation(string expressionTxt, string txtOutputFilePath)
        {
            this.expressionTxt = expressionTxt;
            this.txtOutputFilePath = txtOutputFilePath;            
        }


        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private string expressionTxt;

        public string ExpressionTxt
        {
            get { return expressionTxt; }
            set { expressionTxt = value; OnPropertyChanged("ExpressionTxt"); }
        }



        private string txtOutputFilePath;

        public string TxtOutputFilePath
        {
            get { return txtOutputFilePath; }
            set { txtOutputFilePath = value; OnPropertyChanged("TxtOutputFilePath"); }
        }




        private string txtInputFilePath;

        public string TxtInputFilePath
        {
            get { return txtInputFilePath; }
            set { txtInputFilePath = value; OnPropertyChanged("TxtInputFilePath"); }
        }



        private double outputValue;

        public double OutputValue
        {
            get { return outputValue; }
            set { outputValue = value; OnPropertyChanged("OutputValue"); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }


    }

}
