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

namespace TestCursach
{
    /// <summary>
    /// Логика взаимодействия для AddProfessionWindow.xaml
    /// </summary>
    public partial class AddProfessionWindow : Window
    {
        public AddProfessionWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(DB.Command($"insert into Professions values('{Name.Text}')"))
            {
                MessageBox.Show("Добавлено успешно");
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow window = new AdminWindow();
            window.Show();
            Close();
        }
    }
}
