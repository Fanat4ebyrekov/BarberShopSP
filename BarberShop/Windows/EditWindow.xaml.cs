using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using static BarberShop.ClassEntities;
using BarberShop.Windows;
using System.Text.RegularExpressions;

namespace BarberShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        EF.Employee editEmployee = new EF.Employee();
        bool isEdit = true;
        private string pathPhoto = null;
        private Regex regex = new Regex(@"\d{3}-\d{3}-\d{4}");

        public EditWindow()
        {
            InitializeComponent();
            isEdit = false; 
        }

        public EditWindow(EF.Employee employee)
        {
            InitializeComponent();
            tbFName.Text = employee.FName;
            tbLName.Text = employee.LName;
            tbPhone.Text = employee.Phone;
            tbLogin.Text = employee.Login;
            tbPassword.Password = employee.Password;

            // вывод изображения из БД в Image
            if (employee.Photo != null)
            {
                using (MemoryStream stream = new MemoryStream(employee.Photo))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    photoUser.Source = bitmapImage;
                }

            }

            editEmployee = employee;
            isEdit = true;
        }

        

        private void btnPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                photoUser.Source = new BitmapImage(new Uri(openFile.FileName));
                pathPhoto = openFile.FileName;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var userPhone = ClassEntities.context.Employee.Where(i => i.Phone == tbPhone.Text).FirstOrDefault();

            var checkPhone = tbPhone.Text;

            if (userPhone != null)
            {
                MessageBox.Show("Этот номер существует", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            else if (!regex.IsMatch(checkPhone))
            {
                MessageBox.Show("Неправильно", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var resClick = MessageBox.Show("Вы уверены?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (resClick == MessageBoxResult.Yes)
            {
                editEmployee.FName = tbFName.Text;
                editEmployee.LName = tbLName.Text;

                editEmployee.Phone = tbPhone.Text;
                editEmployee.Login = tbLogin.Text;
                editEmployee.Password = tbPassword.Password;
                if (pathPhoto != null)
                {
                    editEmployee.Photo = File.ReadAllBytes(pathPhoto);
                }


                ClassEntities.context.SaveChanges();

                MessageBox.Show("Пользователь успещно изменен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }
    }
}
