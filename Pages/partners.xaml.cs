using for_new_сriteria.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace for_new_сriteria.Pages
{
    /// <summary>
    /// Логика взаимодействия для работы с партнерами. Включает метод расчета индивидуальной скидки
    /// </summary>
    public partial class partners : Page
    {
        public new_criteriaEntities db = new new_criteriaEntities();


        /// <summary>
        /// Это специальный класс, который является урезанной версией представления.
        /// Нужен для быстрого вывода
        /// </summary>
        public class PartnerDisplayModel
        {
            public int ID { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string fio { get; set; }
            public int rating { get; set; }
            public string phone { get; set; }
            public int TotalProducts { get; set; }
            public int Discount { get; set; }
        }

        public partners()
        {
            InitializeComponent();
            ShowsNavigationUI = true;

            LoadPartnersData();
        }

        /// <summary>
        /// Функция для расчета размера скидки
        /// </summary>
        private int CalculateDiscount(int totalProducts)
        {
            if (totalProducts > 300000) return 15;
            if (totalProducts > 50000) return 10;
            if (totalProducts > 10000) return 5;
            return 0;
        }

        public void LoadPartnersData()
        {
            try
            {
                var partners = db.partnershow.ToList();
                var partnerData = partners.Select(p => new PartnerDisplayModel
                {
                    ID = p.ID,
                    name = p.name,
                    type = p.type,
                    fio = p.fio,
                    rating = p.rating,
                    phone = p.phone,
                    TotalProducts = db.eternalshow
                        .Where(e => e.partner_ID == p.ID)
                        .Sum(e => (int?)e.number) ?? 0,
                    Discount = CalculateDiscount(
                        db.eternalshow
                            .Where(e => e.partner_ID == p.ID)
                            .Sum(e => (int?)e.number) ?? 0)
                }).ToList();

                partnersList.ItemsSource = partnerData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void partnersList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                dynamic cur = partnersList.SelectedItem;
                if (cur != null)
                {
                    var dialog = new edit_add_partner(cur.ID);
                    if (dialog.ShowDialog() == true)
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
            edit_add_partner w = new edit_add_partner(0);
            w.ShowDialog();
            LoadPartnersData();
        }
    }
}
