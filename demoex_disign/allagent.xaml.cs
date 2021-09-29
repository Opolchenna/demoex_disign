using demoex_disign.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для allagent.xaml
    /// </summary>
    public partial class allagent : Window
    {
        public allagent()
        {
            InitializeComponent();
        }

        private void dgAgents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void allagent_load(object sender, RoutedEventArgs e)
        {
            DBagent.db.AgentType.Load();
            DBagent.db.Agent.Load();
            dgAgents.ItemsSource = DBagent.db.Agent.ToList();      
        }

        private void sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttonexit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonadd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
