﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestCursach
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        public bool RegexLogin(string login)
        {
            try
            {
                MailAddress m = new MailAddress(login);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public bool RegexPassword(string password)
        {
            return new Regex("[A-Za-z0-9]{8,20}").IsMatch(password);
        }
        public bool RegexAdmin(string login)
        {
            return new Regex(@"admin").IsMatch(login);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RegexAdmin(LoginBox.Text))
            {
                AdminWindow admin = new AdminWindow();
                admin.Show();
                Close();
            }
            else if (RegexLogin(LoginBox.Text))
            {
                DataTable find = DB.Select($"select * from [Users] where email='{LoginBox.Text}'");
                if (find.Rows.Count > 0)
                {
                    MainWindow mw = new MainWindow();
                    DB.UserID = Convert.ToInt32(find.Rows[0]["id"]);
                    DB.GetUserId(LoginBox.Text);
                    mw.Show();
                    Close();
                    MessageBox.Show("Пользователь авторизовался");
                }
                else
                {
                    DB.Command($"insert into [Users] values ('{LoginBox.Text}')");
                    MainWindow mw = new MainWindow();
                    find = DB.Select($"select * from [Users] where email='{LoginBox.Text}'");
                    DB.UserID = Convert.ToInt32(find.Rows[0]["id"]);
                    mw.Show();
                    Close();
                }
            }
            else MessageBox.Show("Введите E-mail");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            InfoWindow window = new InfoWindow();
            window.Show();
        }
    }
}
