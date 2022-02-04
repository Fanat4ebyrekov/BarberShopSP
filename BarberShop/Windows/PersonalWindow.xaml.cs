using System;
using System.Collections.Generic;
using System.Data;
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
using static BarberShop.ClassEntities;

namespace BarberShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для PersonalWindow.xaml
    /// </summary>
    public partial class PersonalWindow : Window
    {
        public PersonalWindow()
        {
            InitializeComponent();
            AllPersonal.ItemsSource = context.Employee.ToList();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
            this.Close();

        }

        private void AllPersonal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
