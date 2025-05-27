using for_new_сriteria.Model;
using System.Windows.Controls;

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
