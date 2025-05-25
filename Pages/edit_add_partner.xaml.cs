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
    /// Включает в себя цикл ветвления для вызова йункций редактирования или добавления, в зависимости от задания
    /// </summary>
    public partial class edit_add_partner : Window
    {
        public string Title { get; set; }
        private readonly int _partnerId;
        public new_criteriaEntities db = new new_criteriaEntities();

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
                var partner = db.partnershow.FirstOrDefault(p => p.ID == _partnerId);
                if (partner != null)
                {
                    txtName.Text = partner.name;
                    txtType.Text = partner.type;
                    txtadress.Text = partner.adress;
                    txtrating.Text = partner.rating.ToString();
                    txtINN.Text = partner.INN;
                    txtFio.Text = partner.fio;

                    Title = "Редактирование партнера";
                    this.DataContext = this;
                }
                else
                {
                    MessageBox.Show("Возникла ошибка. Такой партнер не найден");
                    MessageBox.Show("Пожалуйста, попробуйте позднее");
                }
            }
            Title = "Добавление нового партнера";
            this.DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_partnerId > 0)
                {
                    var partner = db.partners.First(p => p.ID == _partnerId);
                    var user = db.users.First(u => u.ID == partner.ID);

                    partner.name = txtName.Text;
                    partner.type = txtType.Text;
                    partner.adress = txtadress.Text;
                    partner.rating = Convert.ToInt32(txtrating.Text);
                    partner.INN = txtINN.Text;

                    user.fio = txtFio.Text;
                }
                else
                {
                    var newUser = new users
                    {
                        fio = txtFio.Text,
                        email = txtemail.Text, 
                        password = txtpas.Text, 
                        phone = txtphone.Text,
                        role = "директор"
                    };

                    var newPartner = new Model.partners
                    {
                        name = txtName.Text,
                        type = txtType.Text,
                        adress = txtadress.Text,
                        rating = Convert.ToInt32(txtrating.Text),
                        INN = txtINN.Text,
                        users = newUser
                    };

                    db.partners.Add(newPartner);
                }

                db.SaveChanges();
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
