using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace for_new_сriteria
{
    /// <summary>
    /// Данный код создает основу для постраничной навигации в приложении, и задает NavigationWindow.
    /// Для изменения стартового окна поменяйте Uri адрес.
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationWindow w = new NavigationWindow
            {
                Source = new Uri ("Pages/start.xaml", UriKind.Relative), 
                WindowStartupLocation = WindowStartupLocation.CenterScreen, 
                WindowState = WindowState.Maximized,
                MinHeight = 1000, 
                MinWidth = 1200,
                ShowsNavigationUI = false
            };


            w.Navigated += (sender, args) =>
            {
                if (args.Content is start && args.Content != w.Content)
                {
                    w.RemoveBackEntry();
                }
            };

            w.Show();  

        }
    }
}
