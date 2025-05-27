using for_new_сriteria.Model;
using System;
using System.Linq;
using System.Windows;

namespace for_new_сriteria.Pages
{
    /// <summary>
    /// Это отдельное окно для добавления или редактирования информации о партнерах. 
    /// Включает в себя цикл ветвления для вызова йункций редактирования или добавления, в зависимости от задания
    /// </summary>
    public partial class edit_add_partner : Window
    {
        private readonly partnershow curUser;
        private readonly int _partnerId;
        public new_criteriaEntities db = new new_criteriaEntities();

        public edit_add_partner(int partnerId)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            _partnerId = partnerId;
            curUser = db.partnershow.FirstOrDefault(u => u.ID == partnerId);
            LoadPartnerData();
        }

        /// <summary>
        /// Функция, которая определяет, сейчас идет редактирование существующего партнера или добавление нового 
        /// В зависимости от задания, форма заполняется данными
        /// </summary>

        private void LoadPartnerData()
        {
            if (_partnerId > 0)
            {

                if (curUser != null)
                {
                    txtName.Text = curUser.name;
                    txtType.Text = curUser.type;
                    txtadress.Text = curUser.adress;
                    txtrating.Text = curUser.rating.ToString();
                    txtINN.Text = curUser.INN;
                    txtFio.Text = curUser.fio;
                    txtemail.Text = curUser.email;
                    txtpas.Text = curUser.password;
                    txtphone.Text = curUser.phone;

                }
                else
                {
                    MessageBox.Show("Возникла ошибка. Такой партнер не найден");
                    MessageBox.Show("Пожалуйста, попробуйте позднее");
                }
            }
        }


        public void EditPartner()
        {

            try
            {
                //var partner = db.partners.First(p => p.ID == _partnerId);
                //var user = db.users.First(u => u.ID == curUser.director_ID);

                var partner = db.partners.FirstOrDefault(p => p.ID == _partnerId);
                if (partner == null)
                {
                    MessageBox.Show("Партнер не найден.");
                    return;
                }

                var user = db.users.FirstOrDefault(u => u.ID == curUser.director_ID);
                if (user == null)
                {
                    MessageBox.Show("Директор не найден.");
                    return;
                }

                partner.name = txtName.Text;
                partner.type = txtType.Text;
                partner.adress = txtadress.Text;
                partner.rating = Convert.ToInt32(txtrating.Text);
                partner.INN = txtINN.Text;

                user.fio = txtFio.Text;

                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
                MessageBox.Show("Пожалуйста, попробуйте позднее");
            }

        }

        public void AddPartner()
        {
            try
            {
                Model.partners newPartner = new Model.partners
                {
                    name = txtName.Text,
                    type = txtType.Text,
                    adress = txtadress.Text,
                    rating = Convert.ToInt32(txtrating.Text),
                    INN = txtINN.Text
                };
                db.partners.Add(newPartner);

                var director = db.users.FirstOrDefault(u => u.email == txtemail.Text);
                if (director == null)
                {
                    director = new users
                    {
                        fio = txtFio.Text,
                        email = txtemail.Text,
                        password = txtpas.Text,
                        phone = txtphone.Text,
                        role = "директор"
                    };
                    db.users.Add(director);
                }
                else
                {
                    MessageBox.Show("Такой пользователь уже существует");
                    MessageBox.Show("Пожалуйста, введите правильные значения email");
                }
                db.SaveChanges();
                newPartner.users.Add(director);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
                MessageBox.Show("Пожалуйста, попробуйте позднее");
            }
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_partnerId > 0)
                {
                    EditPartner();
                }
                else
                {
                    AddPartner();
                }
                this.DialogResult = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
                MessageBox.Show("Пожалуйста, попробуйте позднее");
            }
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
