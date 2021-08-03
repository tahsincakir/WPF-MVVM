using CalculatorLib.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CalculatorLib.Util.FileOperation fileOpr = new CalculatorLib.Util.FileOperation();
        CalculatorLib.Enums.EnumMediaSource enumMediaSource;

        CalculationViewModel ViewModel;

        public MainWindow()
        {
            InitializeComponent();
            initScreenValues();
        }


        private void initScreenValues() {

            enumMediaSource = CalculatorLib.Enums.EnumMediaSource.FILE;

            string expressionTxt = "";

            txtInputFilePath.Text = "expression.txt";
            txtOutputFilePath.Text = "value.txt";

            string outputFilePath = txtOutputFilePath.Text;


            if (enumMediaSource == CalculatorLib.Enums.EnumMediaSource.FILE)
            {
                string expressionFilePath = txtInputFilePath.Text;
                expressionTxt = fileOpr.ReadDataFromFile(expressionFilePath);
            }
            else if (enumMediaSource == CalculatorLib.Enums.EnumMediaSource.DATABASE)
            {
                /// <summary>
                /// reading from database can be implemented here
                /// </summary>
            }

            ViewModel = new CalculationViewModel(expressionTxt, outputFilePath);
            this.DataContext = ViewModel;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
