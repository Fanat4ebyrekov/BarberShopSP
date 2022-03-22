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
using Microsoft.Win32;
using System.IO;

namespace BarberShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private string pathPhoto = null;
        public AddWindow()
        {
            InitializeComponent();
            cmbSpecID.ItemsSource = ClassEntities.context.Specialization.ToList();
            cmbSpecID.DisplayMemberPath = "NameSpec";
            cmbSpecID.SelectedIndex = 0;
        }

        public AddWindow(EF.Employee userEdit)
        {
            InitializeComponent();
            cmbSpecID.ItemsSource = ClassEntities.context.Specialization.ToList();
            cmbSpecID.DisplayMemberPath = "NameSpec";
            cmbSpecID.SelectedIndex = 0;
        }



        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {       
            EF.Employee employee = new EF.Employee();

            employee.SpecID = cmbSpecID.SelectedIndex + 1;

            if (pathPhoto != null)
            {
                employee.Photo = File.ReadAllBytes(pathPhoto);
            }

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
            

            if (!string.IsNullOrWhiteSpace(MName.Text))
            {
                employee.MName = MName.Text;
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
            if (!string.IsNullOrWhiteSpace(Email.Text))
            {
                employee.Email = Email.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели почту");
                return;
            }
            if (!string.IsNullOrWhiteSpace(Series.Text))
            {
                employee.PassSeries = Series.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели серию");
                return;
            }
            if (!string.IsNullOrWhiteSpace(NumberPass.Text))
            {
                employee.PassNum = NumberPass.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели номер паспорта");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txbLogin.Text))
            {
                employee.Login = txbLogin.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели логин");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txbPass.Text))
            {
                employee.Password = txbPass.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели пароль");
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
                         textBox.Text.Where(ch => (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || ch == '@' || ch == '.' || (ch >= '0' && ch <= '9')).ToArray()
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


        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                photoUser.Source = new BitmapImage(new Uri(openFile.FileName));
                pathPhoto = openFile.FileName;
            }
        }
    }
}
