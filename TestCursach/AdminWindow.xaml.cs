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
        
        private void AddTest_Click(object sender, RoutedEventArgs e)
        {
            AddTestWindow window = new AddTestWindow();
            window.Show();
            Close();
        }

        private void EditTest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddProfession_Click(object sender, RoutedEventArgs e)
        {
            AddProfessionWindow window = new AddProfessionWindow();
            window.Show();
            Close();
        }
    }
}
