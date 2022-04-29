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

namespace CafeWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTBox.Text != " " || PasswordTBox.Password == " ")
            {
                MessageBox.Show("Введите логин и пароль");

            }
            else
            {
                User user = Helper.db.Users.FirstOrDefault(q => q.Login == LoginTBox.Text && q.Password == PasswordTBox.Password);
                if (user != null)
                {
                     if (user.RoleId == 1)
                     {
                        new WaiterWindow().Show();
                        this.Close();
                     } 
                     else
                     {
                        new CookWindow().Show();
                        this.Close();
                     }
                }
                else
                {
                    MessageBox.Show("Неправильные логин или пароль");
                }
             }
        }
    }
}
