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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        int selectedCountryId;
        int selectedRoleId;
        int selectedSexId;
        int selectedTopicId;
        public Registration()
        {
            InitializeComponent();


            var db = new lastprakEntities1();
            List<ComboBoxItem> CountryList = new List<ComboBoxItem>();
            foreach (Country country in db.Country.ToList())
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = country.Name;
                cbi.Selected += (ss, ee) =>
                {
                    selectedCountryId = country.Idcountry;
                };
                CountryList.Add(cbi);//-------------------------------
            }
            CountryId.ItemsSource = CountryList;

            List<ComboBoxItem> RoleList = new List<ComboBoxItem>();
            foreach (Role role in db.Role.ToList())
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = role.Role1;
                cbi.Selected += (ss, ee) =>
                {
                    selectedRoleId = role.Idrole;
                };
                RoleList.Add(cbi);//-------------------------------
            }
            RoleId.ItemsSource = RoleList;

            List<ComboBoxItem> SexList = new List<ComboBoxItem>();
            foreach (Sex sex in db.Sex.ToList())
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = sex.SexName;
                cbi.Selected += (ss, ee) =>
                {
                    selectedSexId = sex.Idsex;
                };
                SexList.Add(cbi);//-------------------------------
            }
            SexId.ItemsSource = SexList;

            List<ComboBoxItem> TopicList = new List<ComboBoxItem>();
            foreach (Topic topic in db.Topic.ToList())
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = topic.topic1;
                cbi.Selected += (ss, ee) =>
                {
                    selectedTopicId = topic.Idtopic;
                };
                TopicList.Add(cbi);//-------------------------------
            }
            TopicId.ItemsSource = TopicList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowOrgan back = new WindowOrgan();
            back.Show();
            this.Close();
        }

        private void RegistrationUser(object sender, RoutedEventArgs e)
        {
            if (FIO.Text == "")
                return;
            if (Email.Text == "")
                return;
            if (DateOfBirth == null)
                return;
            if (selectedCountryId == 0)
                return;
            if (Phone.Text == "")
                return;
            if (Password.Text == "")
                return;
            if (Photo.Text == "")
                return;
            if (selectedRoleId == 0)
                return;
            if (selectedSexId == 0)
                return;
            if (selectedTopicId == 0)
                return;

            var db = new lastprakEntities1();

            User user = new User();
            user.FIO = FIO.Text;
            user.mail = Email.Text;
            user.dateofbirth = Convert.ToDateTime(DateOfBirth.Text);
            user.countryID = selectedCountryId;
            user.phone = Phone.Text;
            user.password = Password.Text;
            user.photo = Photo.Text;
            user.roleID = selectedRoleId;
            user.sexID = selectedSexId;
            user.topicID = selectedTopicId;
            db.User.Add(user);
            db.SaveChanges();

            MessageBox.Show($"Пользователь {FIO.Text} добавлен и может авторизовываться", "Успешно");
            db.Dispose();

        }
    }
}
