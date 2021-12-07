using demoex_disign;
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
        Agent myagent { get; set; }
        public addpage(Agent agent)
        {
            InitializeComponent();
            myagent = agent;
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

        private void add_load(object sender, RoutedEventArgs e)
        {
            AgentTypeID.ItemsSource = DBagent.db.AgentType.ToList();

            if (myagent.ID != 0)
            {
                AgentTypeID.SelectedItem = myagent.AgentType;
                //AgentTypeID.Text = myagent.AgentTypeID.ToString();   
                Title.Text = myagent.Title.ToString();
                Adress.Text = myagent.Address.ToString();
                INN.Text = myagent.INN.ToString();//INN.Text.ToString();
                KPP.Text = myagent.KPP.ToString();
                DirectorName.Text = myagent.DirectorName.ToString();   
                Phone.Text = myagent.Phone.ToString();
                Email.Text = myagent.Email.ToString();
                Priority.Text = myagent.Priority.ToString();
                sale.Text = myagent.sale.ToString();
            }
        }

        private void save_click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(Title.Text) & !String.IsNullOrEmpty(AgentTypeID.Text) & !String.IsNullOrEmpty(INN.Text) & !String.IsNullOrEmpty(Phone.Text) & !String.IsNullOrEmpty(Priority.Text))
            {
                myagent.AgentType = AgentTypeID.SelectedItem as AgentType;
                myagent.Title = Title.Text; 
                myagent.Address = Adress.Text;
                myagent.INN = INN.Text;
                myagent.KPP = KPP.Text;
                myagent.DirectorName = DirectorName.Text;
                myagent.Phone = Phone.Text;
                myagent.Email = Email.Text;
                myagent.Priority = Int32.Parse(Priority.Text);
                myagent.sale = Int32.Parse(sale.Text);
                DBagent.db.Agent.Add(myagent);
                DBagent.db.SaveChanges();

                if (myagent.ID == 0)
                {
                    DBagent.db.Agent.Add(myagent);
                }
                DBagent.db.SaveChanges();
                MessageBox.Show("Запись успешно добавлена");
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void inn_input(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void kpp_input(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void priority_input(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void sale_input(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
