using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Task_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ClicButton_Click(object sender, RoutedEventArgs e)
        {
            int resalt = await Task<int>.Run(() => { return Addition(2, 3); }).ConfigureAwait(false);

            Dispatcher.Invoke(new Action(() =>
            {
                ResBox.Text = Convert.ToString(resalt);

            }));


        }

        public int Addition(int oper1, int oper2)
        {
            return oper1 + oper2;
        }


    }
}
