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
    /// Логика взаимодействия для AddQuestion.xaml
    /// </summary>
    public partial class AddQuestion : Window
    {
        public int IDTest;
        public AddQuestion()
        {
            InitializeComponent();
            IDTest = DB.GetId("select top 1 * from Tests order by id desc");
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text.Length > 0 && Answer.Text.Length > 0 && Score.Text.Length > 0)
            {
                if (DB.Command($"insert into Questions values({IDTest}, '{Name.Text}', '{Answer.Text}', {Score.Text})"))
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Введите данные");
            }
        }

        private void Score_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
