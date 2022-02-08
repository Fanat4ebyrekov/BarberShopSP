﻿using System;
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

        List<EF.Employee> listEmployee = new List<EF.Employee>();

        List<string> listForSort = new List<string>()
        {
            "По умолчанию",
            "По фамилии",
            "По имени",
            "По телефону",
            "По специализации"
            
        };
        public PersonalWindow()
        {
            InitializeComponent();
            AllPersonal.ItemsSource = context.Employee.ToList();
            cbSort.ItemsSource = listForSort;
            cbSort.SelectedIndex = 0;
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

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
            this.Close();

        }

        private void Filter()
        { 
             listEmployee = ClassEntities.context.Employee.ToList();
             listEmployee = listEmployee.Where(e => e.LName.Contains(tbSearch.Text)|| e.FName.Contains(tbSearch.Text)||e.Phone.Contains(tbSearch.Text)).ToList();
             
            switch (cbSort.SelectedIndex)
            {
                case 0:
                    listEmployee = listEmployee.OrderBy(e => e.ID).ToList();
                    break;
                case 1:
                    listEmployee = listEmployee.OrderBy(e => e.LName).ToList();
                    break;
                case 2:
                    listEmployee = listEmployee.OrderBy(e => e.FName).ToList();
                    break;
                case 3:
                    listEmployee = listEmployee.OrderBy(e => e.Phone).ToList();
                    break;
                case 4:
                    listEmployee = listEmployee.OrderBy(e => e.SpecID).ToList();
                    break;
                    default:
                    listEmployee = listEmployee.OrderBy(e => e.ID).ToList();
                    break;
            }

            if (listEmployee.Count == 0)
            {
                MessageBox.Show("Записей нет"); 
            }
            AllPersonal.ItemsSource = listEmployee; 
        }

        private void AllPersonal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
