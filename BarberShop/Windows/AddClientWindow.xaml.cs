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
using BarberShop.EF;
using static BarberShop.ClassEntities;

namespace BarberShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
       

        public AddClientWindow()
        {
            InitializeComponent();
            cmbGenderID.ItemsSource = ClassEntities.context.Gender.ToList();
            cmbGenderID.DisplayMemberPath = "Name";
            cmbGenderID.SelectedIndex = 0;


        }

        private void LName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё' || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')).ToArray()
                    );
            }
        }

        private void FName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё' || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')).ToArray()
                    );
            }
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || ch == '@' || ch == '.' || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void Phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9') || ch >= ')' || ch >= '(').ToArray()
                    );
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            EF.Client client = new EF.Client();

            

            if(!string.IsNullOrWhiteSpace(FName.Text))
            {
                client.FName = FName.Text;
            }
            else 
            {
                MessageBox.Show("Вы не ввели имя");
                return;
            }

            if (!string.IsNullOrWhiteSpace(LName.Text))
            {
                client.LName = LName.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели фамилию");
                return;
            }

            if (!string.IsNullOrWhiteSpace(Phone.Text))
            {
                client.Phone = Phone.Text;

            }
            else
            {
                MessageBox.Show("Вы не ввели номер телфона");
                return;
            }

            if (!string.IsNullOrWhiteSpace(Email.Text))
            {
                client.Email = Email.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели почту");
                return;
            }

            client.IDGendr = cmbGenderID.SelectedIndex + 1;    

            MessageBox.Show("Пользователь добавлен");
            context.Client.Add(client);
            context.SaveChanges();

            this.Hide();
            ClientWindow clientWindow = new ClientWindow();
            clientWindow.ShowDialog();
            this.Close();

        }
    }
}
