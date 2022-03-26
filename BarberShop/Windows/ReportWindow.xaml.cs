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

namespace BarberShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        List<EF.Employee> listEmployee = new List<EF.Employee>();
        public ReportWindow()
        {
            InitializeComponent();
            AllPersonalTwo.ItemsSource = context.Employee.ToList();
            Filter();
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

        private void Filter()
        {
            listEmployee = ClassEntities.context.Employee.ToList();
            listEmployee = listEmployee.Where(e => e.LName.Contains(tbSearch.Text) || e.FName.Contains(tbSearch.Text) || e.Phone.Contains(tbSearch.Text)).ToList();

           

            if (listEmployee.Count == 0)
            {
                MessageBox.Show("Записей нет");
            }
            AllPersonalTwo.ItemsSource = listEmployee;
        }



        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void Res_Click(object sender, RoutedEventArgs e)
        {
            var User = (AllPersonalTwo.SelectedItem as EF.Employee);

            var listServices = context.Order.ToList().Where(i => i.IDEmp == User.IDEmp).Select(i => i.IDService).ToList();

            double summ = 0;

            foreach (var item in listServices)
            {
                summ = summ + Convert.ToDouble(context.Service.ToList().Where(i => i.ID == item).FirstOrDefault().Cost);

            }

            var res = summ * 0.3 * 0.87;

            Result.Text = res.ToString();
        }
    }
}
