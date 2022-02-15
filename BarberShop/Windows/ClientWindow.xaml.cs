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
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {

        List<EF.Client> clients = new List<EF.Client>();


        List<string> listForSort = new List<string>()
        {
            "По умолчанию",
            "По имени",
            "По фамилии",
            "По телефону"
        };
        public ClientWindow()
        {
            InitializeComponent();
            AllPersonal.ItemsSource = context.Client.ToList();
            cbSort.ItemsSource = listForSort;
            cbSort.SelectedIndex = 0;
            Filter();

        }

        private void Filter()
        {
            clients = ClassEntities.context.Client.ToList();
            clients = clients.Where(e => e.LName.Contains(tbSearch.Text) || e.FName.Contains(tbSearch.Text) || e.Phone.Contains(tbSearch.Text)).ToList();

            switch (cbSort.SelectedIndex)
            {
                case 0:
                    clients = clients.OrderBy(e => e.IDClient).ToList();
                    break;
                case 1:
                    clients = clients.OrderBy(e => e.FName).ToList();
                    break;
                case 2:
                    clients = clients.OrderBy(e => e.LName).ToList();
                    break;
                case 3:
                    clients = clients.OrderBy(e => e.Phone).ToList();
                    break;
              
                default:
                    clients = clients.OrderBy(e => e.IDClient).ToList();
                    break;
            }

            if (clients.Count == 0)
            {
                MessageBox.Show("Записей нет");
            }
            AllPersonal.ItemsSource = clients;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.ShowDialog();
            this.Close();
        }

        private void AllPersonal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void AllPersonal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                var resClick = MessageBox.Show($"Удалить пользователя {(AllPersonal.SelectedItem as EF.Client).LName}", "Подтвержение", MessageBoxButton.YesNo, MessageBoxImage.Information);


                if (resClick == MessageBoxResult.Yes)
                {
                    EF.Client client = new EF.Client();
                    if (!(AllPersonal.SelectedItem is EF.Client))
                    {
                        MessageBox.Show("Запись не выбраны");
                        return;
                    }
                    client = AllPersonal.SelectedItem as EF.Client;

                    ClassEntities.context.Client.Remove(client);
                    ClassEntities.context.SaveChanges();
                }
            }
            Filter();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (AllPersonal.SelectedItem is Client client)
            {
                var resMAss = MessageBox.Show($"Вы хотите изменить пользователя {client.LName}  {client.FName}", "Предупреждение", MessageBoxButton.YesNo);
                if (resMAss == MessageBoxResult.Yes)
                {
                    this.Hide();
                    AddClientWindow clientWindow = new AddClientWindow();
                    ClassPD.IDClient = client.IDClient;
                    clientWindow.ShowDialog();
                    this.Close();

                    
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show($"Вы не выбрали пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
