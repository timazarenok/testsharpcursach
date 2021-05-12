using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    /// Логика взаимодействия для AddTestWindow.xaml
    /// </summary>
    public partial class AddTestWindow : Window
    {
        public AddTestWindow()
        {
            InitializeComponent();
            SetProfessions();
        }
        public void SetProfessions()
        {
            DataTable dt = DB.Select("select * from Professions");
            List<string> professions = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                professions.Add(dr["name"].ToString());
            }
            Professions.ItemsSource = professions;
        }

        private void Amount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex("[^0-9]+");
            e.Handled = reg.IsMatch(e.Text);
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            int id_p = DB.GetId($"select * from Professions where [name]='{Professions.SelectedItem}'");
            if (DB.Command($"insert into Tests values ({id_p}, '{Name.Text}')"))
            {
                AddQuestion add = new AddQuestion();
                add.Amount = Convert.ToInt32(Amount.Text);
                add.Show();
                Close();
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
