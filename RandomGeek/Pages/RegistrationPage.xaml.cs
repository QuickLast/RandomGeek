﻿using System;
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
using RandomGeek.Database;
using RandomGeek.Functions;

namespace RandomGeek.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EmailTb.Text == string.Empty || NameTb.Text == string.Empty || PasswordPb.Password == string.Empty)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                User user = new User()
                {
                    Email = EmailTb.Text,
                    Name = NameTb.Text,
                    Password = PasswordPb.Password
                };

                DbConnection.RandomGeekEntities.User.Add(user);
                DbConnection.RandomGeekEntities.SaveChanges();

                MessageBox.Show("Регистрация прошла успешно!");
                Auth.isAuth = true;
                Auth.user = user;

                NavigationService.Navigate(new MainPage(Auth.user));
            }
            
        }

        private void HaveAnAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
