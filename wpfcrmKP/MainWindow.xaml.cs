using System;
using System.Windows;

namespace wpfcrmKP
{
    public partial class MainWindow : Window
    {
        public MainWindow()  
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string correctUsername = "admin"; 
            string correctPassword = "12345"; 

            string enteredUsername = UsernameBox.Text;
            string enteredPassword = PasswordBox.Password;

            if (enteredUsername == correctUsername && enteredPassword == correctPassword)
            {
                Window1 window1 = new Window1();
                window1.Show();
                this.Close();  
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль! Попробуйте снова.");
            }
        }
    }
}
