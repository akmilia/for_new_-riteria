using for_new_сriteria.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace for_new_сriteria.Pages
{
    /// <summary>
    /// Логика взаимодействия для работы с продуктами. Включает метод 
    /// </summary>
    public partial class products : Page
    {
        public new_criteriaEntities db = new new_criteriaEntities();
        public products()
        {
            InitializeComponent();
            ShowsNavigationUI = true;
        }

        public void DiscountCalculate()
        {

        }
    }
}
