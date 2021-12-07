using demoex_disign;
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
            //gridAgent.ItemsSource = Entities1.GetContext().Agent.ToList();

            //var allagent = Entities1.GetContext().AgentType.ToList();
            //allagent.Insert(0, new AgentType
            //{
            //    Title = "all type agents"
            //});
            //filter.ItemsSource = allagent;

            //filter.SelectedIndex = 0;

            //var currentAgent = Entities1.GetContext().Agent.ToList();
            //gridAgent.ItemsSource = currentAgent;

            sort.Items.Add("Сортировка");
            sort.Items.Add("От А до Я");
            sort.Items.Add("От Я до А");

            filter();
            fil.SelectedIndex = 0;
            sort.SelectedIndex = 0;
            searchу();

        }

        private void UpdateAgent()
        {
            //var currentAgent = Entities1.GetContext().Agent.ToList();

            //if (filter.SelectedIndex > 0)
            //  currentAgent = currentAgent.Where(p => p.Agents.Contains(filter.SelectedItem as Agent)).ToList();
            ////gridAgent.ItemsSource = currentAgent;
            //gridAgent.ItemsSource = currentAgent.OrderBy(p => p.Title).ToList();

        }
        private void searchу()
        {
            List<Agent> agent = DBagent.db.Agent.Where(stroka => stroka.Title.StartsWith(search.Text)).ToList();

            if (fil.SelectedIndex > 0)
            {
                agent = agent.Where(stroka => stroka.AgentType.Title == fil.SelectedItem.ToString()).ToList();
            }

            switch (sort.SelectedIndex)
            {
                case 0:; break;
                case 1: agent = agent.OrderBy(stroka => stroka.Title).ToList(); break;
                case 2: agent = agent.OrderByDescending(stroka => stroka.Title).ToList(); break;
            }

            gridAgent.ItemsSource = agent;


        }
        private void filter()
        {
            fil.Items.Add("Фильтрация");
            List<AgentType> agentTypes = DBagent.db.AgentType.ToList();
            for ( int i=0; i< agentTypes.Count(); i++)
            {
                fil.Items.Add(agentTypes[i].Title);
            }

        }
       
        private void sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            searchу();
        }

        private void buttonexit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            // List<Agent> agent = DBagent.db.Agent.Where(stroka => stroka.Title.StartsWith(search.Text)).ToList();
            Agent agent = gridAgent.SelectedItem as Agent;
            demoex_disign.DBagent.db.Agent.Remove(agent);
            demoex_disign.DBagent.db.SaveChanges();
            allagent_load(sender, e);
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            Agent agent = gridAgent.SelectedItem as Agent;
            addpage add = new addpage(agent);
            add.Show();
            Close();
        }

        private void buttonadd_Click(object sender, RoutedEventArgs e)
        {
            addpage add = new addpage( new Agent());
            add.Show();
            Close();
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchу();
        }

        private void filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            searchу();
        }

        private void allagent_load(object sender, RoutedEventArgs e)
        {
            demoex_disign.DBagent.db.Agent.Load();
            demoex_disign.DBagent.db.Agent.Load();
            //griduser.ItemsSource = library_kino.db_kino.db.film.ToList();
            gridAgent.ItemsSource = demoex_disign.DBagent.db.Agent.ToList();
        }
    }
}
