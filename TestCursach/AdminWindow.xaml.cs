using System;
using System.Collections.Generic;
using System.Data;
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

namespace TestCursach
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void EditTest_Click(object sender, RoutedEventArgs e)
        {
            editTest window = new editTest();
            window.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.Show();
            Close();
        }
    }
}
