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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
           
        }



        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {       
            Employee employee = new Employee();
            
            if (!string.IsNullOrWhiteSpace(FName.Text))
            {
                employee.FName = FName.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели имя");
                return;
            }
            if (!string.IsNullOrWhiteSpace(LName.Text))
            {
                employee.LName = LName.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели фамилию");
                return;
            }
            if (!string.IsNullOrWhiteSpace(TPhone.Text))
            {
                employee.Phone = TPhone.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели номер");
                return;
            }

            if (!string.IsNullOrWhiteSpace(MName.Text))
            {
                employee.MName = TPhone.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели отчество");
                return;
            }

            if (!string.IsNullOrWhiteSpace(TPhone.Text))
            {
                employee.Phone = TPhone.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели номер");
                return;
            }

            MessageBox.Show("Пользователь добавлен");
            context.Employee.Add(employee);
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Hide();
            PersonalWindow personalWindow = new PersonalWindow();
            personalWindow.ShowDialog();
            this.Close();


        }
        
        private void TPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => ch >= '+' || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void LName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch =>(ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё' || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')).ToArray()
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



        private void MName_TextChanged(object sender, TextChangedEventArgs e)
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
                         textBox.Text.Where(ch => (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || ch == '@' || ch == '.').ToArray()
                    );
            }
        }

        private void Series_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => ch >= '1' && ch <= '9').ToArray()
                    );
            }
        }

        private void NumberPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '1' && ch <= '9')).ToArray()
                    );
            }
        }

        private void TPhone_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9') || ch >= ')' || ch >= '(').ToArray()
                    );
            }
        }

        private void txbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')).ToArray()
                    );
            }
        }

        private void txbPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }
    }
}
