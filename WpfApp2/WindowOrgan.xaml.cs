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
    /// Логика взаимодействия для WindowOrgan.xaml
    /// </summary>
    public partial class WindowOrgan : Window
    {
        public WindowOrgan()
        {
            InitializeComponent();
            var CurrentTime = DateTime.Now;
            int hour = CurrentTime.Hour;
            if (hour >= 9 && hour < 11)
            {
                EnterLbl.Content = "Доброе утро";
            }
            else if (hour >= 12 && hour < 18)
            {
                EnterLbl.Content = "Добрый день";
            }
            else if (hour >= 19 && hour < 22)
            {
                EnterLbl.Content = "Добрый вечер";
            }
            else
            {
                EnterLbl.Content = "Доброй ночи";
            }
            using (lastprakEntities1 db = new lastprakEntities1())
            {
                User user = db.User.Where(x => x.Iduser == CurrentUser.Id).FirstOrDefault();
                if (user != null)
                {
                    Usernm.Content = user.FIO;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow prof = new ProfileWindow();
            prof.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Registration rewg = new Registration();
            rewg.Show();
            this.Close();
        }
    }
}
