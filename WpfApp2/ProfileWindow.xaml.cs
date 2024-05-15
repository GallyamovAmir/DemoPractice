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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        private User users;
        public ProfileWindow()
        {
            InitializeComponent();

            using (lastprakEntities1 db = new lastprakEntities1())
            {
                users = db.User.Where(x => x.Iduser == CurrentUser.Id).First();

                List<Sex> genders = new List<Sex>();
                genders = db.Sex.ToList();
                GenderComboBox.ItemsSource = genders;

                GenderComboBox.SelectedItem = genders.Where(x => x.Idsex == users.sexID).First();
            }

            DataContext = users;
            UserPasswordBox.Text = users.password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FIO.Text != null && Email.Text != null && PhoneNumber.Text != null && UserPasswordBox.Text != null && GenderComboBox.SelectedItem != null)
            {
                if (UserPasswordBox.Text == RepeatPassword.Text)
                {
                    using (lastprakEntities1 db = new lastprakEntities1())
                    {
                        User user = db.User.Where(x => x.Iduser == users.Iduser).First();
                        user.FIO = FIO.Text;
                        user.mail = Email.Text;
                        user.phone = PhoneNumber.Text;
                        user.password = UserPasswordBox.Text;
                        user.sexID = ((Sex)GenderComboBox.SelectedItem).Idsex;

                        db.SaveChanges();
                        MessageBox.Show("Данные изменены");
                    }
                }
                else
                {
                    MessageBox.Show("Пароль не совпадает");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Authorization back = new Authorization();
            back.Show();
            this.Close();
        }
    }
}
