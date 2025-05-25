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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace for_new_сriteria.Pages
{
    /// <summary>
    /// Это отдельное окно для добавления или редактирования информации о партнерах. 
    /// </summary>
    public partial class edit_add_partner : Window
    {

        private readonly int _partnerId;
        private readonly new_criteriaEntities _db = new new_criteriaEntities();

        public edit_add_partner(int partnerId)
        {
            InitializeComponent();
            _partnerId = partnerId;
            LoadPartnerData();
        }

        private void LoadPartnerData()
        {
            if (_partnerId > 0)
            {
                var partner = _db.partnershow.FirstOrDefault(p => p.ID == _partnerId);
                if (partner != null)
                {
                    // Заполняем поля формы данными партнера
                    txtName.Text = partner.name;
                    txtType.Text = partner.type;
                    txtFio.Text = partner.fio;
                    txtPhone.Text = partner.phone;
                    // ... остальные поля
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_partnerId > 0)
                {
                  
                    var partner = _db.partnershow.First(p => p.ID == _partnerId);
                    partner.name = txtName.Text;
                    partner.type = txtType.Text;
                
                }
                else
                {  

                    _db.partnershow.Add(new partnershow
                    {
                        name = txtName.Text,
                        type = txtType.Text,
                     
                    });
                }

                _db.SaveChanges();
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите закрыть окно?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        } 
    }
}
