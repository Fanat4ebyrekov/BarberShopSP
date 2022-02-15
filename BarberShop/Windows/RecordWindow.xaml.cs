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
using static BarberShop.ClassEntities;
using BarberShop.EF;

namespace BarberShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для RecordWindow.xaml
    /// </summary>
    public partial class RecordWindow : Window
    {
        public RecordWindow()
        {
            InitializeComponent();
            cmClient.ItemsSource = context.Client.ToList();
            cmClient.DisplayMemberPath = "FName";
            cmClient.SelectedIndex = 0;

            cmBarber.ItemsSource = context.Employee.ToList();
            cmBarber.DisplayMemberPath = "FName";
            cmBarber.SelectedIndex = 0;

            cmService.ItemsSource = context.Service.ToList();
            cmService.DisplayMemberPath = "Title";
            cmService.SelectedIndex = 0;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }

        private void btnRecord_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();

            order.IDClient = cmClient.SelectedIndex + 1;
            order.IDEmp = cmBarber.SelectedIndex + 1;
            order.IDService = cmService.SelectedIndex + 1;

            MessageBox.Show("Запись добавлен");
            ClassEntities.context.Order.Add(order);
            ClassEntities.context.SaveChanges();
        }
    }
}
