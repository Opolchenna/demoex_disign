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
using System.Windows.Shapes;

namespace demoex_disign
{
    /// <summary>
    /// Логика взаимодействия для addpage.xaml
    /// </summary>
    public partial class addpage : Window
    {
        public addpage()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void back_click(object sender, RoutedEventArgs e)
        {
            allagent all = new allagent();
            all.Show();
            Close();
        }
    }
}
