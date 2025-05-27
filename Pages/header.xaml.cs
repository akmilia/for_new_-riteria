using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace for_new_сriteria.Pages
{
    /// <summary>
    /// Это собственный пользовательский элемент, который был создан под нужды данного приложения.
    /// Этот компонент используется для быстрой и удобной навигации между страницами.
    /// </summary>
    public partial class header : UserControl
    {
        public header()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Данная функция опрелеляет текущее окно программы и закрывает его.
        /// </summary>
        public void CloseWindow()
        {
            try
            {

                Window window = Window.GetWindow(this);
                if (window != null)
                {
                    window.Close();
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при переходе на выбранную страницу.");
            }
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationWindow w = (NavigationWindow)Application.Current.MainWindow;
                w.Navigate(new Uri("Pages/partners.xaml", UriKind.Relative));
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при переходе на выбранную страницу.");
                MessageBox.Show("Пожалуйста, попробуйте закрыть все дополнительные ОКНА. Попробуйте перейти еще раз.");
            }
        }


        private void postavki_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationWindow w = (NavigationWindow)Application.Current.MainWindow;
                w.Navigate(new Uri("Pages/postavki.xaml", UriKind.Relative));
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при переходе на выбранную страницу.");
                MessageBox.Show("Пожалуйста, попробуйте закрыть все дополнительные ОКНА. Попробуйте перейти еще раз.");
            }
        }

        private void prosucts_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationWindow w = (NavigationWindow)Application.Current.MainWindow;
                w.Navigate(new Uri("Pages/products.xaml", UriKind.Relative));
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при переходе на выбранную страницу.");
                MessageBox.Show("Пожалуйста, попробуйте закрыть все дополнительные ОКНА. Попробуйте перейти еще раз.");
            }
        }


        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.CloseWindow();
        }
    }
}
