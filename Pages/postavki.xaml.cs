using for_new_сriteria.Model;
using System.Windows.Controls;

namespace for_new_сriteria.Pages
{
    /// <summary>
    /// Логика взаимодействия для postavki.xaml
    /// </summary>
    public partial class postavki : Page
    {

        public new_criteriaEntities db = new new_criteriaEntities();
        public postavki()
        {
            InitializeComponent();
            ShowsNavigationUI = true;
        }
    }
}
