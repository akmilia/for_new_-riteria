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
    /// Логика взаимодействия для работы с партнерами. Включает метод расчета индивидуальной скидки
    /// </summary>
    public partial class partners : Page
    {
        public new_criteriaEntities db = new new_criteriaEntities();

        public class PartnerDisplayModel
        {
            public int ID { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string fio { get; set; }
            public int rating { get; set; }
            public string phone { get; set; }
            public int Discount { get; set; }
        }
         
        public partners()
        {
            InitializeComponent();
            ShowsNavigationUI = true; 

            LoadPartnersData();
        }

        private int CalculateDiscount(int totalProducts)
        {
            if (totalProducts > 300000) return 15;
            if (totalProducts > 50000) return 10;
            if (totalProducts > 10000) return 5;
            return 0;
        }

        public void LoadPartnersData()
        {
            var partners = db.partnershow.ToList();
            var partnerData = partners.Select(p => new
            {   
                p.ID,
                p.name,
                p.type,
                p.fio,
                p.rating,
                p.phone,
                TotalProducts = db.eternalshow
                    .Where(e => e.partner_ID == p.ID)
                    .Sum(e => e.number),
                Discount = CalculateDiscount(
                    db.eternalshow
                        .Where(e => e.partner_ID == p.ID)
                        .Sum(e => e.number))
            }).ToList();

            partnersList.ItemsSource = partnerData;
        }

        private void partnersList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                dynamic cur = partnersList.SelectedItem;

                if (cur != null)
                {
                    edit_add_partner w = new edit_add_partner(cur.ID);
                    w.ShowDialog();

                    LoadPartnersData();
                }
                else
                {
                    MessageBox.Show("Возникла ошибка");
                    edit_add_partner w = new edit_add_partner(0);
                    w.ShowDialog(); 
                    LoadPartnersData();
                }

            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
                MessageBox.Show("Пожалуйста, попробуйте позднее");
            }
        }

        private void add_partner_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
