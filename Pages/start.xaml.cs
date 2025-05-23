using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace for_new_сriteria.Pages
{
    /// <summary>
    /// Логика взаимодействия для start.xaml
    /// </summary>
    public partial class start : Page
    {
        public start()
        {
            InitializeComponent();
        } 

        public bool ValidateData(string log, string pas)
        {
            if (string.IsNullOrEmpty(log))
            {
                MessageBox.Show("Поля не должны быть пустыми");
                MessageBox.Show("Пожалуйста, введите текстовое значение в поле <Логин>");
                return false; 
            }
            if (string.IsNullOrEmpty(pas))
            {
                MessageBox.Show("Поля не должны быть пустыми");
                MessageBox.Show("Пожалуйста, введите значение в поле <Пароль>. Оно может включать русские и английские буквы, цифры, символы");
                return false;
            }
            if (string.IsNullOrWhiteSpace(log))
            {
                MessageBox.Show("Поля не должны содержать пробел");
                MessageBox.Show("Пожалуйста, уберите пробелы в поле <Логин>");
                return false;
            }
            if (string.IsNullOrEmpty(pas))
            {
                MessageBox.Show("Поля не должны содержать пробел");
                MessageBox.Show("Пожалуйста, уберите пробелы в поле <Пароль>");
                return false;
            }
            else return true; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   

            try
            {
                string log = login.Text.Trim();
                string pas = password.Password.Trim();

                if (ValidateData(log, pas))
                {
                    /**/
                    NavigationWindow w = (NavigationWindow)Application.Current.MainWindow;
                    w.Navigate(new Uri("Pages/edit_add.xaml", UriKind.Relative));
                } 

            } 
            catch
            {
                MessageBox.Show("Возникла ошибка");
                MessageBox.Show("Пожалуйста, попробуйте позднее");
            }
            
        }
    }
}
