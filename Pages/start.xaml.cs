using for_new_сriteria.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace for_new_сriteria.Pages
{
    /// <summary>
    /// Логика взаимодействия для авторизации в системе
    /// </summary>
    public partial class start : Page
    {
        public new_criteriaEntities db = new new_criteriaEntities();
        public start()
        {
            InitializeComponent();
            ShowsNavigationUI = false;
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
                    var user = db.users.FirstOrDefault(u => u.email == log && u.password == pas);
                    if (user != null)
                    {
                        MessageBox.Show("Данные правильные!");
                        NavigationWindow w = (NavigationWindow)Application.Current.MainWindow;
                        w.Navigate(new Uri("Pages/partners.xaml", UriKind.Relative));
                    }
                    else
                    {
                        MessageBox.Show("Такой пользователь не существует");
                        MessageBox.Show("Пожалуйста, введите правильные значения");

                    }

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
